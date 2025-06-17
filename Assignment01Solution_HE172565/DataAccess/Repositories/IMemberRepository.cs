using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IMemberRepository
    {
        Task<bool> CheckDuplicateMemberAsync(string email);
        Task<Member> GetMemberByEmailAsync(string email);
        Task<List<Member>> GetAllMembersAsync();
        Task<bool> AddMemberAsync(Member member);
        Task<bool> UpdateMemberAsync(Member member);
        Task<bool> DeleteMemberAsync(int memberId);
    }
}
