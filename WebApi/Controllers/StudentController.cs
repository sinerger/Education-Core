using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.CoursePrograms;
using Domain.Interfaces;
using Domain.Entities.Users;

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

        [HttpPost("{groupid}")]
        public async Task<bool> AddStudentToGroup(Guid groupId, Student student)
        {
            return await _dbContext.StudentRepository.AddStudentToGroupAsync(groupId, student);
        }

        [HttpPost]
        public async Task<bool> CreateStudent(Student student)
        {
            return await _dbContext.StudentRepository.CreateStudentAsync(student);
        }

        [HttpPut]
        public async Task<bool> UpdateStudent(Student student)
        {
            return await _dbContext.StudentRepository.UpdateStudentAsync(student);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteStudenD(Guid id)
        {
            return await _dbContext.StudentRepository.DeleteStudentAsync(id);
        }
    }
}
