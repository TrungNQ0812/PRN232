using Microsoft.AspNetCore.Mvc;
using PRN232_PT1_TrungNQHE172565.Models;

namespace PRN232_PT1_TrungNQHE172565.Services
{
    public interface IEmployeeServices
    {
        Task<ActionResult<IEnumerable<Employee>>> GetAllInformationOfEmployeeAsync();
        Task<ActionResult<IEnumerable<Employee>>> SearchEmployeeByNameAsync(string name);
        Task<ActionResult<Employee>> UpdateEmployeeAddressAsync(int id, string newAddress);
    }
}
