using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class ProductDAO
    {
        private readonly EstoreContext context;

        public ProductDAO(EstoreContext _context)
        {
            context = _context;
        }
    }
}
