using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IUserRepository
    {
        List<AspNetUser> GetAll();
        AspNetUser? GetById(string id);
        void Add(AspNetUser user);
        void Update(AspNetUser user);
        void Delete(string id);
    }
}
