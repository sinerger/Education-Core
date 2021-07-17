using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.Homeworks;
using Domain.Interfaces;
using WebApi.Routes;

namespace WebApi.Controllers
{
    [Route(ApiRoutes.Api + ApiRoutes.Controller)]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly IDBContext _dbContext;

        public HomeworkController(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet(ApiRoutes.Homework.GetAllHomeworkByCourseID)]
        public async Task<IEnumerable<Homework>> GetAllHomeworksByCourseID(Guid courseID)
        {
            return await _dbContext.HomeworkRepository.GetAllHomeworksByCourseIDAsync(courseID);
        }

        [HttpPut(ApiRoutes.Homework.AddHomeworkWithinLesson)]
        public async Task AddHomeworkWithinLesson(Guid lessonID, Homework homework)
        {
            await _dbContext.HomeworkRepository.AddHomeworkWithinLessonAsync(lessonID, homework);
        }

        [HttpGet(ApiRoutes.Homework.GetHomeworkByLessonID)]
        public async Task<Homework> GetHomeworkByLessonID(Guid lessonID)
        {
            return await _dbContext.HomeworkRepository.GetHomeworkByLessonIDAsync(lessonID);
        }

        [HttpPost(ApiRoutes.Homework.CreateHomework)]
        public async Task CreateHomework(Homework homework)
        {
            await _dbContext.HomeworkRepository.CreateHomeworkAsync(homework);
        }

        [HttpDelete(ApiRoutes.Homework.DeleteHomework)]
        public async Task DeleteHomework(Guid id)
        {
            await _dbContext.HomeworkRepository.DeleteHomeworkAsync(id);
        }

        [HttpPut(ApiRoutes.Homework.UpdateHomework)]
        public async Task UpdateHomework(Homework homework)
        {
            await _dbContext.HomeworkRepository.UpdateHomeworkAsync(homework);
        }
    }
}
