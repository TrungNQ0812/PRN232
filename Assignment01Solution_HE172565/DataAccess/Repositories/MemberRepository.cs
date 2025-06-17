using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public Task<bool> AddMemberAsync(Member member)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMemberAsync(Member member)
        {
            throw new NotImplementedException();
        }

        public Task<List<Member>> GetAllMembersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Member> GetMemberbyEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMemberAsync(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
