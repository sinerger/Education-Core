using Domain.Entities.Users;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebApi.Routes;

namespace WebApi.Controllers
{
    [Authorize]
    [Route(ApiRoutes.Api + ApiRoutes.Controller)]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IDBContext _dbContext;

        public StudentController(IDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet(ApiRoutes.Student.GetAllStudents)]
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _dbContext.StudentRepository.GetAllStudentsAsync();
        }

        [HttpGet(ApiRoutes.Student.GetStudentByID)]
        public async Task<Student> GetStudentByID(Guid id)
        {
            return await _dbContext.StudentRepository.GetStudentByIDAsync(id);
        }

        [HttpPost(ApiRoutes.Student.AddStudentToGroup)]
        public async Task AddStudentToGroup(Guid studentID, Guid groupID)
        {
            await _dbContext.StudentRepository.AddStudentToGroupAsync(studentID, groupID);
        }

        [HttpPost(ApiRoutes.Student.CreateStudent)]
        public async Task CreateStudent(Student student)
        {
            await _dbContext.StudentRepository.CreateStudentAsync(student);
        }

        [HttpPut(ApiRoutes.Student.UpdateStudent)]
        public async Task UpdateStudent(Student student)
        {
            await _dbContext.StudentRepository.UpdateStudentAsync(student);
        }

        [HttpDelete(ApiRoutes.Student.DeleteStudent)]
        public async Task DeleteStudenD(Guid id)
        {
            await _dbContext.StudentRepository.DeleteStudentAsync(id);
        }
    }
}
