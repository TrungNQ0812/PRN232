using BusinessObject;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class UserDAO
    {
        private readonly EstoreContext _context;

        public UserDAO(EstoreContext context)
        {
            _context = context;
        }

        public List<AspNetUser> GetAll()
        {
            return _context.AspNetUsers.ToList();
        }

        public AspNetUser? GetById(string id)
        {
            return _context.AspNetUsers.FirstOrDefault(u => u.Id == id);
        }

        public void Add(AspNetUser user)
        {
            _context.AspNetUsers.Add(user);
            _context.SaveChanges();
        }

        public void Update(AspNetUser user)
        {
            _context.AspNetUsers.Update(user);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var user = _context.AspNetUsers.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.AspNetUsers.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
