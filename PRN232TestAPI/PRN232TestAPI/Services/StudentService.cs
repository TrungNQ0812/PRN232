using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRN232TestAPI.DTOs;

namespace PRN232TestAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentsContext _studentsContext;

        public StudentService(StudentsContext studentsContext)
        {
            _studentsContext = studentsContext;
        }
        public Task<ActionResult> createNewStudentAsync(CreateNewStudent student)
        {
            throw new NotImplementedException();
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

        public Task<bool> updateStudentAsync(int id, GetStudent student)
        {
            throw new NotImplementedException();
        }
    }
}
