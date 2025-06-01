using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN232TestAPI.DTOs;
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
        [Route("GetStudent")]
        public async Task<ActionResult<GetStudent>> getStudentAsync(int id)
        {
            var student = await studentService.getStudentAsync(id);

            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
    }
}
