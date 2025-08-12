using BusinessObject;
using BusinessObject.Models;
using DataAccess.DAOs;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ImpRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDAO _userDAO;

        public UserRepository(EstoreContext context)
        {
            _userDAO = new UserDAO(context);
        }

        public List<AspNetUser> GetAll() => _userDAO.GetAll();
        public AspNetUser? GetById(string id) => _userDAO.GetById(id);
        public void Add(AspNetUser user) => _userDAO.Add(user);
        public void Update(AspNetUser user) => _userDAO.Update(user);
        public void Delete(string id) => _userDAO.Delete(id);
    }
}
