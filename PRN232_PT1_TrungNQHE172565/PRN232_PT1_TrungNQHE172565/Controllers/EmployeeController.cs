using Microsoft.AspNetCore.Mvc;
using PRN232_PT1_TrungNQHE172565.DTOs;
using PRN232_PT1_TrungNQHE172565.Models;
using PRN232_PT1_TrungNQHE172565.Services;

namespace PRN232_PT1_TrungNQHE172565.Controllers
{
    [ApiController]
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices employeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {
            this.employeeServices = employeeServices;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAllEmployees()
        {
            var employees = await employeeServices.GetAllInformationOfEmployeeAsync();
            return Ok(employees.Value);
        }

        [HttpGet("Search")]
        public async Task<ActionResult> SearchByName([FromQuery] string name)
        {
            var result = await employeeServices.SearchEmployeeByNameAsync(name);
            return Ok(result.Value);
        }

        [HttpPut("{id}/UpdateAddress")]
        public async Task<ActionResult> UpdateAddress(int id, [FromBody] EditEmployeeAddress dto)
        {
            var result = await employeeServices.UpdateEmployeeAddressAsync(id, dto.Address);
            if (result.Result is NotFoundResult) return NotFound();
            return Ok(result.Value);
        }
    }
}
