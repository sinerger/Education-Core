using Domain.Entities.Lessons;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Routes;

namespace WebApi.Controllers
{
    [Route(ApiRoutes.Api + ApiRoutes.Controller)]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet(ApiRoutes.Lesson.GetAllLessons)]
        public async Task<IActionResult> GetAllLessons()
        {
            var responce = await _lessonService.GetAllLessonsAsync();

            return GetIActionResult(responce);
        }

        [HttpGet(ApiRoutes.Lesson.GetLessonByID)]
        public async Task<IActionResult> GetLessonByID(Guid id)
        {
            var responce = await _lessonService.GetLessonByIDAsync(id);

            return GetIActionResult(responce);
        }

        [HttpDelete(ApiRoutes.Lesson.DeleteLesson)]
        public async Task<IActionResult> DeleteLesson(Guid id)
        {
            var responce = await _lessonService.DeleteLessonAsync(id);

            return GetIActionResult(responce);
        }

        [HttpPost(ApiRoutes.Lesson.CreateLessonWithinCourse)]
        public async Task<IActionResult> CreateLessonWithinCourse(Lesson lesson)
        {
            var responce = await _lessonService.CreateLessonWithinCourseAsync(lesson);

            return GetIActionResult(responce);
        }

        [HttpPut(ApiRoutes.Lesson.UpdateLesson)]
        public async Task<IActionResult> UpdateLesson(Lesson lesson)
        {
            var responce = await _lessonService.UpdateLessonAsync(lesson);

            return GetIActionResult(responce);
        }

        private IActionResult GetIActionResult(IServiceResponce<Lesson> responce)
        {
            IActionResult result = null;

            if (responce.IsSuccessfully)
            {
                result = Ok(responce.Result);
            }
            else
            {
                result = BadRequest(responce.Message);
            }

            return result;
        }

        private IActionResult GetIActionResult(IServiceResponce<IEnumerable<Lesson>> responce)
        {
            IActionResult result = null;

            if (responce.IsSuccessfully)
            {
                result = Ok(responce.Result);
            }
            else
            {
                result = BadRequest(responce.Message);
            }

            return result;
        }

        private IActionResult GetIActionResult(IServiceResponce<bool> responce)
        {
            IActionResult result = null;

            if (responce.IsSuccessfully)
            {
                result = Ok(responce.Result);
            }
            else
            {
                result = BadRequest(responce.Message);
            }

            return result;
        }
    }
}
