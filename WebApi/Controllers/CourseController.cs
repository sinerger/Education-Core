using Domain.Entities.Courses;
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
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet(ApiRoutes.Course.GetAllCourses)]
        public async Task<IActionResult> GetAllCourses()
        {
            var response = await _courseService.GetAllCoursesAsync();

            return GetIActionResult(response);
        }

        [HttpPost(ApiRoutes.Course.CreateCourse)]
        public async Task<IActionResult> CreateCourse(Course course)
        {
            var response = await _courseService.CreateCourseAsync(course);

            return GetIActionResult(response);
        }

        [HttpDelete(ApiRoutes.Course.DeleteCourse)]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            var response = await _courseService.DeleteCourseAsync(id);

            return GetIActionResult(response);
        }

        [HttpPut(ApiRoutes.Course.UpdateCourse)]
        public async Task<IActionResult> UpdateCourse(Course course)
        {
            var response = await _courseService.UpdateCourseAsync(course);

            return GetIActionResult(response);
        }

        private IActionResult GetIActionResult(IServiceResponce<Course> responce)
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

        private IActionResult GetIActionResult(IServiceResponce<IEnumerable<Course>> responce)
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
