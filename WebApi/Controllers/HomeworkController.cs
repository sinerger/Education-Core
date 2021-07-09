using Domain.Entities.Homeworks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly IDBContext _dbContext;

        public HomeworkController(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{courseid}")]
        public async Task<IEnumerable<Homework>> GetAllHomeworkByCourseIDAsync(Guid CourseID)
        {
            return await _dbContext.HomeworkRepository.GetAllHomeworkByCourseIDAsync(CourseID);
        }

        [HttpGet("lessonid")]
        public async Task<Homework> GetHomeworkByLessonIdAsync(Guid LessonID)
        {
            return await _dbContext.HomeworkRepository.GetHomeworkByLessonIdAsync(LessonID);
        }

        [HttpPost]
        public async Task<bool> CreateHomeworkWithinLessonAsync(Homework homework, Guid LessonID)
        {
            return await _dbContext.HomeworkRepository.CreateHomeworkWithinLessonAsync(homework,LessonID);
        }

        [HttpDelete("id")]
        public async Task<bool> DeleteHomework(Guid id)
        {
            return await _dbContext.HomeworkRepository.DeleteHomeworkAsync(id);
        }

        [HttpPut]
        public async Task<bool> UpdateHomework(Homework homework)
        {
            return await _dbContext.HomeworkRepository.UpdateHomeworkAsync(homework);
        }
    }
}
