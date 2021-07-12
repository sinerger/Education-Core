using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.Lessons;
using Domain.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly IDBContext _dbContext;

        public LessonController(IDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Lesson>> GetAllLessons()
        {
            return await _dbContext.LessonRepository.GetAllLessonsAsync();
        }

        [HttpGet("{id}")]
        public async Task<Lesson> GetLessonByID(Guid id)
        {
            return await _dbContext.LessonRepository.GetLessonByIDAsync(id);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteLesson(Guid id)
        {
            return await _dbContext.LessonRepository.DeleteLessonAsync(id);
        }

        [HttpPost]
        public async Task<bool> CreateLessonWithinCourse(Guid courseID,Lesson lesson)
        {
            return await _dbContext.LessonRepository.CreateLessonWithinCourseAsync(courseID ,lesson );
        }

        [HttpPut]
        public async Task<bool> UpdateLesson(Lesson lesson)
        {
            return await _dbContext.LessonRepository.UpdateLessonAsync(lesson);
        }
    }
}
