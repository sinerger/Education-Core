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

        [HttpGet]
        public async Task<Student> GetStudentByID(Guid id)
        {
            return await _dbContext.StudentRepository.GetStudentByIDAsync(id);
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

        [HttpDelete]
        public async Task<bool> DeleteStudentByID(Guid id)
        {
            return await _dbContext.StudentRepository.DeleteStudentByIDAsync(id);
        }
    }
}
