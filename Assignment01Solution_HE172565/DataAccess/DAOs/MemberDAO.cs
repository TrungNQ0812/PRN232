using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class MemberDAO
    {
        private readonly eStoreDbContext _dbContext;

        public MemberDAO(eStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Member>> GetAllMemberAsync()
        {
            var memberList = _dbContext.Members.ToList();
            return memberList;
        }

   
    }
}
