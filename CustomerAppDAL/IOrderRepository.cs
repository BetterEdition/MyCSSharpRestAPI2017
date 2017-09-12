using CustomerAppDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL
{
    public interface IOrderRepository
    {
        //C
        Order Create(Order cust);

        //R
        List<Order> GetAll();
        Order Get(int Id);

        //No update for Repository, it will be a task for the unit of work 

        //D
        Order Delete(int Id);
    }
}
