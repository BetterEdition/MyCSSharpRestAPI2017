﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            
            bool checkText = File.Exists(@"C:\Program Files\DBPassword.txt");
            bool checkText2 = File.Exists(@"C:\Users\Jespe\OneDrive\Dokumenter\DBPassword.txt");
            
            
            if (!optionsBuilder.IsConfigured)

            {
                
                    //if (checkText)
                    //{
                    //        string readText = File.ReadAllText(@"C:\Program Files\DBPassword.txt");

                            //optionsBuilder.UseSqlServer(
                            //$@"Server=tcp:jesp6058server.database.windows.net,1433;Initial Catalog=CustomerAppDB;Persist Security Info=False;User ID=jesp6058;Password=
                            //" + readText + @";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                    //}
                    //else if (checkText2)
                    //{
                    //        string readText2 = File.ReadAllText(@"C:\Users\Jespe\OneDrive\Dokumenter\DBPassword.txt");

                            optionsBuilder.UseSqlServer(
                            $@"Server=tcp:jesp6058server.database.windows.net,1433;Initial Catalog=CustomerAppDB;Persist Security Info=False;User ID=jesp6058;Password=
                            S1234567!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                //}


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
