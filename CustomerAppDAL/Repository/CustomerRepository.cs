using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppDAL.Context;
using System.Linq;
using CustomerAppDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerAppDAL.Repository
{
    class CustomerRepository : ICustomerRepository
    {

        CustomerAppContext _context;

        public CustomerRepository(CustomerAppContext context)
        {
            _context = context;
        }
        public Customer Create(Customer cust)
        {
            
            _context.Customers.Add(cust);
            
            return cust;
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.
                Include(c => c.Addresses).
                ToList();
        }

        public Customer Get(int Id)
        {
            return _context.Customers.FirstOrDefault(x => x.Id == Id);
        }

        public Customer Delete(int Id)
        {
            var cust = Get(Id);
            _context.Customers.Remove(cust);
           
            return cust;
        }
    }
}
