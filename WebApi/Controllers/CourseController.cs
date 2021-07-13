using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.Courses;
using Domain.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly IDBContext _dbContext;

        public CourseController(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Course>> GetAllCoursesById()
        {
            return await _dbContext.CourseRepository.GetAllCoursesAsync();
        }

        [HttpPost]
        public async Task CreateCourse([FromBody]Course course)
        {
            await _dbContext.CourseRepository.CreateCourseAsync(course);
        }

        [HttpDelete("{id}")]
        public async Task DeleteCourse(Guid id)
        {
            await _dbContext.CourseRepository.DeleteCourseAsync(id);
        }

        [HttpPut]
        public async Task UpdateCourse(Course course)
        {
            await _dbContext.CourseRepository.UpdateCourseAsync(course);
        }
    }
}
