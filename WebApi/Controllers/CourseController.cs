using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.Courses;
using Domain.Interfaces;
using WebApi.Routes;

namespace WebApi.Controllers
{
    [Route(ApiRoutes.Api + ApiRoutes.Controller)]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly IDBContext _dbContext;

        public CourseController(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet(ApiRoutes.Course.GetAllCourses)]
        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _dbContext.CourseRepository.GetAllCoursesAsync();
        }

        [HttpPost(ApiRoutes.Course.CreateCourse)]
        public async Task CreateCourse([FromBody] Course course)
        {
            await _dbContext.CourseRepository.CreateCourseAsync(course);
        }

        [HttpDelete(ApiRoutes.Course.DeleteCourse)]
        public async Task DeleteCourse(Guid id)
        {
            await _dbContext.CourseRepository.DeleteCourseAsync(id);
        }

        [HttpPut(ApiRoutes.Course.UpdateCourse)]
        public async Task UpdateCourse(Course course)
        {
            await _dbContext.CourseRepository.UpdateCourseAsync(course);
        }
    }
}
