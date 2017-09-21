using CustomerAppDAL.Context;
using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppDAL.Entities;
using System.Linq;

namespace CustomerAppDAL.Repository
{
    class AddressRepository : IAddressRepository
    {
        CustomerAppContext _context;

        public AddressRepository(CustomerAppContext context)
        {
            _context = context;
        }
        
        public Address Create(Address address)
        {
            _context.Addresses.Add(address);
            return address;
        }
        public Address Delete(int Id)
        {
            var address = Get(Id);
            _context.Addresses.Remove(address);
            return address;
        }

        public Address Get(int Id)
        {
            return _context.Addresses.FirstOrDefault(a => a.Id == Id);
        }

        public List<Address> GetAll()
        {
            return _context.Addresses.ToList();
        }

        
    }
}
