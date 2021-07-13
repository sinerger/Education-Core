using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.Homeworks;
using Domain.Interfaces;

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
        public async Task<IEnumerable<Homework>> GetAllHomeworkByCourseID(Guid CourseID)
        {
            return await _dbContext.HomeworkRepository.GetAllHomeworkByCourseIDAsync(CourseID);
        }

        [HttpGet("lessonid")]
        public async Task<Homework> GetHomeworkByLessonID(Guid LessonID)
        {
            return await _dbContext.HomeworkRepository.GetHomeworkByLessonIDAsync(LessonID);
        }

        [HttpPost]
        public async Task CreateHomeworkWithinLesson(Guid LessonID, Homework homework)
        {
            await _dbContext.HomeworkRepository.CreateHomeworkWithinLessonAsync(LessonID, homework);
        }

        [HttpDelete("{id}")]
        public async Task DeleteHomework(Guid id)
        {
            await _dbContext.HomeworkRepository.DeleteHomeworkAsync(id);
        }

        [HttpPut]
        public async Task UpdateHomework(Homework homework)
        {
            await _dbContext.HomeworkRepository.UpdateHomeworkAsync(homework);
        }
    }
}
