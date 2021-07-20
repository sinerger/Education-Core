using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.Users;
using Domain.Interfaces;
using WebApi.Routes;

namespace WebApi.Controllers
{
    [Route(ApiRoutes.Api+ApiRoutes.Controller)]
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

        [HttpGet(ApiRoutes.Teacher.GetTeacherByID)]
        public async Task<Teacher> GetTeacherByID(Guid id)
        {
            return await _dbContext.TeacherRepository.GetTeacherByIDAsync(id);
        }
        
        [HttpPost(ApiRoutes.Teacher.AddTeacherToGroup)]
        public async Task<bool> AddTeacherToGroup(Guid groupID, Guid userID)
        {
            return await _dbContext.TeacherRepository.AddTeacherToGroupAsync(groupID, userID);
        }

        [HttpPost(ApiRoutes.Teacher.AddTeacherToLesson)]
        public async Task<bool> AddTeacherToLesson(Guid groupID, Guid teacherID)
        {
            return await _dbContext.TeacherRepository.AddTeacherToLessonAsync(groupID, teacherID);
        }

        [HttpPost]
        public async Task<bool> CreateTeacher(Teacher teacher)
        {
            return await _dbContext.TeacherRepository.CreateTeacherAsync(teacher);
        }

        [HttpPut]
        public async Task<bool> UpdateTeacher(Teacher teacher)
        {
            return await _dbContext.TeacherRepository.UpdateTeacherAsync(teacher);
        }

        [HttpDelete("{id}")]
        public async Task DeleteTeacher(Guid id)
        { 
            await _dbContext.TeacherRepository.DeleteTeacherAsync(id);
        }
    }
}
