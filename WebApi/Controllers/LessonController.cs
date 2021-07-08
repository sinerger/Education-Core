using Domain.Entities.Lesson1;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<Lesson>> GetLessons()
        {
            return await _dbContext.LessonRepository.GetAllLessonAsync();
        }

        [HttpGet("id")]
        public async Task<Lesson> GetLessonById(Guid id)
        {
            return await _dbContext.LessonRepository.GetLessonByIdAsync(id);
        }

        [HttpDelete("id")]
        public async Task<bool> DeleteLesson(Guid id)
        {
            return await _dbContext.LessonRepository.DeleteLessonAsync(id);
        }

        [HttpPost]
        public async Task<bool> CreateLesson(Lesson lesson)
        {
            return await _dbContext.LessonRepository.CreateLessonAsync(lesson);
        }

        [HttpPut]
        public async Task<bool> UpdateLesson(Lesson lesson)
        {
            return await _dbContext.LessonRepository.UpdateLessonAsync(lesson);
        }
    }
}
