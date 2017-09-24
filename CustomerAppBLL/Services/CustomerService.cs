using System;
using System.Collections.Generic;
using System.Linq;
using CustomerAppBLL.BusinessObjects;
using CustomerAppBLL.Converters;
using CustomerAppDAL;

namespace CustomerAppBLL.Services
{
    internal class CustomerService : ICustomerService
    {
        private readonly AddressConverter aConv = new AddressConverter();
        private readonly CustomerConverter conv = new CustomerConverter();
        private readonly DALFacade facade;

        public CustomerService(DALFacade facade)
        {
            this.facade = facade;
        }

        public CustomerBO Create(CustomerBO cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newCust = uow.CustomerRepository.Create(conv.Convert(cust));
                uow.Complete();

                return conv.Convert(newCust);
            }
        }


        public CustomerBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newCust = uow.CustomerRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newCust);
            }
        }

        public CustomerBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var cust = conv.Convert(uow.CustomerRepository.Get(Id));

                //cust.Addresses =
                //    cust.AddressIds?
                //        .Select(id => aConv.Convert(uow.AddressRepository.Get(id)))
                //        .ToList();
                cust.Addresses = uow.AddressRepository.GetAllById(cust.AddressIds)
                    .Select(a => aConv.Convert(a))
                    .ToList();

                return cust;
            }
        }

        public List<CustomerBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                //return uow.CustomerRepository.GetAll();
                return uow.CustomerRepository.GetAll().Select(c => conv.Convert(c)).ToList();
            }
        }

        public CustomerBO Update(CustomerBO cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                var customerFromDb = uow.CustomerRepository.Get(cust.Id);
                if (customerFromDb == null)
                    throw new InvalidOperationException("Customer not found");
                var customerUpdated = conv.Convert(cust);
                customerFromDb.FirstName = customerUpdated.FirstName;
                customerFromDb.LastName = customerUpdated.LastName;

                customerFromDb.Addresses.RemoveAll(
                    ca => !customerUpdated.Addresses.Exists(
                          a => a.AddressId == ca.AddressId
                          && a.CustomerId == ca.CustomerId));

                customerUpdated.Addresses.RemoveAll(
                    ca => customerFromDb.Addresses.Exists(
                        a => a.AddressId == ca.AddressId
                                  && a.CustomerId == ca.CustomerId));

                customerFromDb.Addresses.AddRange(
                    customerUpdated.Addresses);

                uow.Complete();
                return conv.Convert(customerFromDb);
            }
        }
    }
}