using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppBLL.BusinessObjects;
using CustomerAppBLL.Converters;
using CustomerAppDAL;
using System.Linq;

namespace CustomerAppBLL.Services
{
    public class AddressService : IAddressService
    {
        AddressConverter _conv;
        DALFacade _facade;

        public AddressService(DALFacade facade)
        {
            _facade = facade;
            _conv = new AddressConverter();
        }
        public AddressBO Create(AddressBO address)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newAddress = uow.AddressRepository.Create(_conv.Convert(address));
                uow.Complete();

                return _conv.Convert(newAddress);
            }
        }

        public AddressBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newAddress = uow.AddressRepository.Delete(Id);
                uow.Complete();
                return _conv.Convert(newAddress);
            }
        }

        public AddressBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return _conv.Convert(uow.AddressRepository.Get(Id));
            }
        }

        public List<AddressBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                //return uow.AddressRepository.GetAll();
                return uow.AddressRepository.GetAll().Select(a => _conv.Convert(a)).ToList();
            }
        }

        public AddressBO Update(AddressBO address)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var addressFromDB = uow.AddressRepository.Get(address.Id);
                if (addressFromDB == null)
                {
                    throw new InvalidOperationException("Address not found");
                }
                addressFromDB.Id = address.Id;
                addressFromDB.City = address.City;
                addressFromDB.Number = address.Number;
                addressFromDB.Street = address.Street;
                uow.Complete();
                return _conv.Convert(addressFromDB);
            }
        }
    }
}
