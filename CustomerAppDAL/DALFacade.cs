
using CustomerAppDAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppDAL.Context;
using CustomerAppDAL.UOW;

namespace CustomerAppDAL
{
    public class DALFacade
    {
        public IUnitOfWork UnitOfWork
        {
            
            get
            {
                return new UnitOfWork();
            }

        }
    }
}
