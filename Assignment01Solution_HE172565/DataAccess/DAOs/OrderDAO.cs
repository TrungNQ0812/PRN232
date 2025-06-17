using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class OrderDAO
    {
        private readonly eStoreDbContext _dbContext;

        public OrderDAO(eStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }



    }
}
