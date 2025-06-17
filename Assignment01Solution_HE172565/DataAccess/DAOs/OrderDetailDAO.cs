using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class OrderDetailDAO
    {
        private readonly eStoreDbContext _dbContext;

        public OrderDetailDAO(eStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }



    }
}
