using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class RoleDAO
    {
        private readonly EstoreContext context;

        public RoleDAO(EstoreContext _context)
        {
            context = _context;
        }
    }
}
