using BusinessObject;
using Microsoft.EntityFrameworkCore;
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

        // Get all members
        public async Task<List<Member>> GetAllMembersAsync()
        {
            return await _dbContext.Members.ToListAsync();
        }

        // Get member by email
        public async Task<Member> GetMemberByEmailAsync(string email)
        {
            return await _dbContext.Members
                .FirstOrDefaultAsync(m => m.Email == email);
        }

        // Add a new member
        public async Task<bool> AddMemberAsync(Member member)
        {
            _dbContext.Members.Add(member);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        // Update an existing member
        public async Task<bool> UpdateMemberAsync(Member member)
        {
            _dbContext.Members.Update(member);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        // Delete a member
        public async Task<bool> DeleteMemberAsync(int memberId)
        {
            var member = await _dbContext.Members.FindAsync(memberId);
            if (member != null)
            {
                _dbContext.Members.Remove(member);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        // Check if a member already exists by email
        public async Task<bool> CheckDuplicateMemberAsync(string email)
        {
            var member = await _dbContext.Members
                .FirstOrDefaultAsync(m => m.Email == email);
            return member != null;
        }


    }
}
