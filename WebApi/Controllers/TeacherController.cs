using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.Users;
using Domain.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IDBContext _dbContext;

        public TeacherController(IDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return await _dbContext.TeacherRepository.GetAllTeachersAsync();
        }

        [HttpGet("{id}")]
        public async Task<Teacher> GetTeacherByID(Guid id)
        {
            return await _dbContext.TeacherRepository.GetTeacherByIDAsync(id);
        }
        
        [HttpPost("{groupid}")]
        public async Task<bool> AddTeacherToGroup(Guid groupId, Teacher teacher)
        {
            return await _dbContext.TeacherRepository.AddTeacherToGroupAsync(groupId, teacher);
        }

        [HttpPost]
        public async Task<bool> CreateTeacher(Teacher teacher)
        {
            return await _dbContext.TeacherRepository.CreateTeacherAsync(teacher);
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateTeacher(Teacher teacher)
        {
            return await _dbContext.TeacherRepository.UpdateTeacherAsync(teacher);
        }

        [HttpDelete]
        public async Task<bool> DeleteTeacher(Guid id)
        {
            return await _dbContext.TeacherRepository.DeleteTeacherAsync(id);
        }
    }
}
