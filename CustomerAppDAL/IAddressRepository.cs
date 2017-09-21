using CustomerAppDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL
{
    public interface IAddressRepository
    {
        //C
        Address Create(Address address);

        //R
        List<Address> GetAll();
        Address Get(int Id);

        //No update for Repository, it will be a task for the unit of work 

        //D
        Address Delete(int Id);
    }
}
