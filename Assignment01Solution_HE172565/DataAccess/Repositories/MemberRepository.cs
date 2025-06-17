using BusinessObject;
using DataAccess.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly MemberDAO _memberDAO;

        // Constructor to inject the MemberDAO
        public MemberRepository(MemberDAO memberDAO)
        {
            _memberDAO = memberDAO;
        }

        // Check if a member already exists by email
        public async Task<bool> CheckDuplicateMemberAsync(string email)
        {
            return await _memberDAO.CheckDuplicateMemberAsync(email);
        }

        // Get a member by email
        public async Task<Member> GetMemberByEmailAsync(string email)
        {
            return await _memberDAO.GetMemberByEmailAsync(email);
        }

        // Get all members
        public async Task<List<Member>> GetAllMembersAsync()
        {
            return await _memberDAO.GetAllMembersAsync();
        }

        // Add a new member
        public async Task<bool> AddMemberAsync(Member member)
        {
            return await _memberDAO.AddMemberAsync(member);
        }

        // Update an existing member
        public async Task<bool> UpdateMemberAsync(Member member)
        {
            return await _memberDAO.UpdateMemberAsync(member);
        }

        // Delete a member by ID
        public async Task<bool> DeleteMemberAsync(int memberId)
        {
            return await _memberDAO.DeleteMemberAsync(memberId);
        }
    }
}
