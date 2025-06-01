using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRN232TestAPI.DTOs;
using PRN232TestAPI.Models;

namespace PRN232TestAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentsContext _studentsContext;

        public StudentService(StudentsContext studentsContext)
        {
            _studentsContext = studentsContext;
        }
        public async Task<ActionResult> createNewStudentAsync(CreateNewStudent student)
        {
            var newStudent = new  Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                BirthDate = student.BirthDate,
                Gender = student.Gender,
                Email = student.Email,
                Phone = student.Phone
            };

            _studentsContext.Students.Add(newStudent);
            await _studentsContext.SaveChangesAsync();
        
            return new OkObjectResult(new { message = "Student create successfully!" });
        }

        public Task<bool> deleteStudentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<GetStudent>> getStudentAsync(int id)
        {
            var student =  await _studentsContext.Students.FirstOrDefaultAsync(x => x.StudentId == id);

            if (student == null)
            {
                return null;
            }

            var getStudent = new GetStudent
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName
            };

            return getStudent;
        }

        public async Task<bool> updateStudentAsync(int id, Student student)
        {
            var existingStudent = await _studentsContext.Students.FindAsync(id);
            if (existingStudent == null)
            {
                return false;
            }

            // Cập nhật thông tin từ DTO
            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.BirthDate = student.BirthDate;
            existingStudent.Gender = student.Gender;
            existingStudent.Email = student.Email;
            existingStudent.Phone = student.Phone;

            await _studentsContext.SaveChangesAsync();
            return true;
        }
    }
}
