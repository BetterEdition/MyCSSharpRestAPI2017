﻿using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppBLL.BusinessObjects;
using CustomerAppDAL.Entities;
using System.Linq;

namespace CustomerAppBLL.Converters
{
    class CustomerConverter
    {
        public AddressConverter aConv;

        public CustomerConverter()
        {
            aConv = new AddressConverter();
        }

        internal Customer Convert(CustomerBO cust)
        {
            if(cust == null) { return null;}

            return new Customer()
            {
                Id = cust.Id,
                Addresses = cust.Addresses.Select(aConv.Convert).ToList(),
                FirstName = cust.FirstName,
                LastName = cust.LastName
            };
        }

        internal CustomerBO Convert(Customer cust)
        {
            if (cust == null) { return null; }
            return new CustomerBO()
            {
                Id = cust.Id,
                Addresses = cust.Addresses.Select(aConv.Convert).ToList(),
                FirstName = cust.FirstName,
                LastName = cust.LastName
            };
        }
    }
}
