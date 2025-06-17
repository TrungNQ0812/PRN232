using BusinessObject;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberAPI : ControllerBase
    {

        private readonly IMemberRepository _memberRepository;

        // Inject the MemberRepository into the controller
        public MemberAPI(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateMember([FromBody] Member member)
        {
            // Check if the member already exists
            if (await _memberRepository.CheckDuplicateMemberAsync(member.Email))
            {
                return BadRequest("A member with this email already exists.");
            }

            bool result = await _memberRepository.AddMemberAsync(member);
            if (result)
            {
                return CreatedAtAction(nameof(GetMemberByEmail), new { email = member.Email }, member);
            }
            return BadRequest("Failed to create member.");
        }

        // 2. Get all members
        [HttpGet]
        [Route("get_all_members")]
        public async Task<ActionResult<List<Member>>> GetAllMembers()
        {
            var members = await _memberRepository.GetAllMembersAsync();
            return Ok(members);
        }

        // 3. Get member by email
        [HttpGet]
        [Route("{email}")]
        public async Task<ActionResult<Member>> GetMemberByEmail(string email)
        {
            var member = await _memberRepository.GetMemberByEmailAsync(email);
            if (member == null)
            {
                return NotFound("Member not found.");
            }
            return Ok(member);
        }

        // 4. Update member
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateMember(int id, [FromBody] Member member)
        {
            if (id != member.MemberId)
            {
                return BadRequest("Member ID mismatch.");
            }

            bool result = await _memberRepository.UpdateMemberAsync(member);
            if (result)
            {
                return NoContent();
            }
            return NotFound("Member not found.");
        }

        // 5. Delete member
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            bool result = await _memberRepository.DeleteMemberAsync(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound("Member not found.");
        }
    }
}
