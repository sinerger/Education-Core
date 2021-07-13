using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.Lessons;
using Domain.Interfaces;
using WebApi.Routes;

namespace WebApi.Controllers
{
    [Route(ApiRoutes.Api + ApiRoutes.Controller)]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly IDBContext _dbContext;

        public LessonController(IDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet(ApiRoutes.Lesson.GetAllLessons)]
        public async Task<IEnumerable<Lesson>> GetAllLessons()
        {
            return await _dbContext.LessonRepository.GetAllLessonsAsync();
        }

        [HttpGet(ApiRoutes.Lesson.GetLessonByID)]
        public async Task<Lesson> GetLessonByID(Guid id)
        {
            return await _dbContext.LessonRepository.GetLessonByIDAsync(id);
        }

        [HttpDelete(ApiRoutes.Lesson.DeleteLesson)]
        public async Task DeleteLesson(Guid id)
        {
            await _dbContext.LessonRepository.DeleteLessonAsync(id);
        }

        [HttpPost(ApiRoutes.Lesson.CreateLessonWithinCourse)]
        public async Task CreateLessonWithinCourse(Lesson lesson)
        {
            try
            {
                await _dbContext.LessonRepository.CreateLessonWithinCourseAsync(lesson);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPut(ApiRoutes.Lesson.UpdateLesson)]
        public async Task UpdateLesson(Lesson lesson)
        {
            await _dbContext.LessonRepository.UpdateLessonAsync(lesson);
        }
    }
}
