using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRN232_PT1_TrungNQHE172565.Models;

namespace PRN232_PT1_TrungNQHE172565.Services
{
    public class EmployeeService : IEmployeeServices
    {
        private readonly Prn232dbContext dbContext;

        public EmployeeService(Prn232dbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllInformationOfEmployeeAsync()
        {
            return await dbContext.Employees.Include(e => e.Orders).ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployeeByNameAsync(string name)
        {
            var result = await dbContext.Employees
                .Where(e => e.EmpName.Contains(name))
                .ToListAsync();

            return result;
        }

        public async Task<ActionResult<Employee>> UpdateEmployeeAddressAsync(int id, string newAddress)
        {
            var employee = await dbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return new NotFoundResult();
            }

            employee.Address = newAddress;
            await dbContext.SaveChangesAsync();
            return employee;
        }
    }
}
