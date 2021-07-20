using Domain.Entities.Users;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IDBContext _dbContext;

        public StudentController(IDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _dbContext.StudentRepository.GetAllStudentsAsync();
        }

        [HttpGet("{id}")]
        public async Task<Student> GetStudentByID(Guid id)
        {
            return await _dbContext.StudentRepository.GetStudentByIDAsync(id);
        }

        [HttpPost("groupid")]
        public async Task AddStudentToGroup(Student student)
        {
             await _dbContext.StudentRepository.AddStudentToGroupAsync(student);
        }

        [HttpPost]
        public async Task CreateStudent(Student student)
        {
             await _dbContext.StudentRepository.CreateStudentAsync(student);
        }

        [HttpPut]
        public async Task UpdateStudent(Student student)
        {
             await _dbContext.StudentRepository.UpdateStudentAsync(student);
        }

        [HttpDelete("{id}")]
        public async Task DeleteStudenD(Guid id)
        {
             await _dbContext.StudentRepository.DeleteStudentAsync(id);
        }
    }
}
