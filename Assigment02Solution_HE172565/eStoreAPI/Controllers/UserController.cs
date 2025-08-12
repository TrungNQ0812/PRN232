using BusinessObject;
using BusinessObject.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AspNetUser>> GetAll()
        {
            return Ok(_userRepo.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<AspNetUser> GetById(string id)
        {
            var user = _userRepo.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AspNetUser user)
        {
            _userRepo.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] AspNetUser user)
        {
            if (id != user.Id) return BadRequest();
            _userRepo.Update(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _userRepo.Delete(id);
            return NoContent();
        }
    }
}
