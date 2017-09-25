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
        //public CustomerAppContext() : base(options)
        //{
            
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Jesper Enemark\Desktop\DBPassword.txt");
            
            if (!optionsBuilder.IsConfigured)

            {
                optionsBuilder.UseSqlServer(
                    $@"Server=tcp:jesp6058server.database.windows.net,1433;Initial Catalog=CustomerAppDB;Persist Security Info=False;User ID=jesp6058;Password={text};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                    Console.WriteLine(text);
                Console.ReadLine();
            }
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAddress>()
                .HasKey(ca => new { ca.AddressId, ca.CustomerId });
            modelBuilder.Entity<CustomerAddress>()
                .HasOne(ca => ca.Address)
                .WithMany(a => a.Customers)
                .HasForeignKey(ca => ca.AddressId);

            modelBuilder.Entity<CustomerAddress>()
                .HasOne(ca => ca.Customer)
                .WithMany(c => c.Addresses)
                .HasForeignKey(ca => ca.CustomerId);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
