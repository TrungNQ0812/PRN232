using Microsoft.AspNetCore.Mvc;
using PRN232TestAPI.DTOs;
using PRN232TestAPI.Models;

namespace PRN232TestAPI.Services
{
    public interface IStudentService
    {
        Task<ActionResult<GetStudent>> getStudentAsync(int id);
        Task<bool> updateStudentAsync(int id,GetStudent student);
        Task<bool> deleteStudentAsync(int id);
        Task<ActionResult> createNewStudentAsync(CreateNewStudent student);
    }
}
