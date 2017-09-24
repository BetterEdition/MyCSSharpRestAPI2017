using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL.Entities
{
    public class Customer
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public List<CustomerAddress> Addresses { get; set; }

        public int Id { get; set; }

        public List<Order> Orders { get; set; }
        
    }
}
