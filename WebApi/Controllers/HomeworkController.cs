using Domain.Entities.Homeworks;
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
    public class HomeworkController : ControllerBase
    {
        private readonly IHomeworkService _homeworkService;

        public HomeworkController(IHomeworkService homeworkService)
        {
            _homeworkService = homeworkService;
        }

        [HttpGet(ApiRoutes.Homework.GetAllHomeworkByCourseID)]
        public async Task<IActionResult> GetAllHomeworksByCourseID(Guid courseID)
        {
            var response = await _homeworkService.GetAllHomeworksByCourseIDAsync(courseID);

            return GetIActionResult(response);
        }

        [HttpPut(ApiRoutes.Homework.AddHomeworkWithinLesson)]
        public async Task<IActionResult> AddHomeworkWithinLesson(Guid lessonID, Homework homework)
        {
            var response = await _homeworkService.AddHomeworkWithinLessonAsync(lessonID, homework);

            return GetIActionResult(response);
        }

        [HttpGet(ApiRoutes.Homework.GetHomeworkByLessonID)]
        public async Task<IActionResult> GetHomeworkByLessonID(Guid lessonID)
        {
            var response = await _homeworkService.GetHomeworkByLessonIDAsync(lessonID);

            return GetIActionResult(response);
        }

        [HttpPost(ApiRoutes.Homework.CreateHomework)]
        public async Task<IActionResult> CreateHomework(Homework homework)
        {
            var response = await _homeworkService.CreateHomeworkAsync(homework);

            return GetIActionResult(response);
        }

        [HttpDelete(ApiRoutes.Homework.DeleteHomework)]
        public async Task<IActionResult> DeleteHomework(Guid id)
        {
            var response = await _homeworkService.DeleteHomeworkAsync(id);

            return GetIActionResult(response);
        }

        [HttpPut(ApiRoutes.Homework.UpdateHomework)]
        public async Task<IActionResult> UpdateHomework(Homework homework)
        {
            var response = await _homeworkService.UpdateHomeworkAsync(homework);

            return GetIActionResult(response);
        }

        private IActionResult GetIActionResult(IServiceResponce<Homework> responce)
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

        private IActionResult GetIActionResult(IServiceResponce<IEnumerable<Homework>> responce)
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
