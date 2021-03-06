﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CustomerAppDAL.Entities;

namespace CustomerAppDAL.Repository
{
    class CustomerRepositoryFakeDB : ICustomerRepository
    {
        private static int Id = 1;
        private static List<Customer> Customers = new List<Customer>();
        public Customer Create(Customer cust)
        {
            Customer newCust;
            Customers.Add(newCust = new Customer()
            {
                Id = Id++,
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Addresses = cust.Addresses

            });
            return newCust;
        }

        public Customer Delete(int Id)
        {
            var cust = Get(Id);


            Customers.Remove(cust);
            return cust;
        }

        public Customer Get(int Id)
        {
            return Customers.FirstOrDefault(x => x.Id == Id);
        }

        public List<Customer> GetAll()
        {
            return new List<Customer>(Customers);
        }
    }
}
