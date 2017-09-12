using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerAppDAL.Context
{
    class CustomerAppContext : DbContext
    {
        static DbContextOptions<CustomerAppContext> options = 
            new DbContextOptionsBuilder<CustomerAppContext>()
            .UseInMemoryDatabase("TheDB").Options;

        //Options that we want in memory
        public CustomerAppContext() : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
