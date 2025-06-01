using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PRN232TestAPI.DTOs;
using PRN232TestAPI.Models;
using PRN232TestAPI.Services;

namespace PRN232TestAPI.Controllers
{
    [Route("Student")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService _studentService)
        {
            studentService = _studentService;
        }

        [HttpGet]
        [Route("GetStudent/{id}")]
        public async Task<ActionResult<GetStudent>> getStudentAsync(int id)
        {
            var student = await studentService.getStudentAsync(id);

            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        [Route("CreateStudent")]
        public async Task<ActionResult> createNewStudent([FromBody] CreateNewStudent createNewStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = await studentService.createNewStudentAsync(createNewStudent);

            return CreatedAtAction(nameof(getStudentAsync), student);
        }



        [HttpPut]
        [Route("Update/{id}")]
        public async Task<ActionResult> UpdateStudentAsync(int id, [FromBody]Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await studentService.updateStudentAsync(id, student);

            if (!result)
            {
                return NotFound(new { message = "Student not found" });
            }
            return Ok(new { message = "Student updated successfully" });

        }
    }
}
