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
        public async Task<IEnumerable<Lesson>> GetAllLessonsAsync()
        {
            return await _dbContext.LessonRepository.GetAllLessonsAsync();
        }

        [HttpGet("{id}")]
        public async Task<Lesson> GetLessonByIdAsync(Guid id)
        {
            return await _dbContext.LessonRepository.GetLessonByIdAsync(id);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteLessonAsync(Guid id)
        {
            return await _dbContext.LessonRepository.DeleteLessonAsync(id);
        }

        [HttpPost]
        public async Task<bool> CreateLessonWithinCourseAsync(Lesson lesson,Guid courseID)
        {
            return await _dbContext.LessonRepository.CreateLessonWithinCourseAsync(lesson, courseID);
        }

        [HttpPut]
        public async Task<bool> UpdateLessonAsync(Lesson lesson)
        {
            return await _dbContext.LessonRepository.UpdateLessonAsync(lesson);
        }
    }
}
