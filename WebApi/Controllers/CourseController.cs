using Domain.Entities.Courses;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<Course>> GetAllCourseById()
        {
            return await _dbContext.CourseRepository.GetAllCoursesAsync();
        }

        [HttpGet("{@!id}")]
        public async Task<Course> GetCourseById(Guid id)
        {
            return await _dbContext.CourseRepository.GetCourseByIdAsync(id);
        }

        [HttpPost]
        public async Task CreateCourse([FromBody]Course course)
        {
            await _dbContext.CourseRepository.CreateCourseAsync(course);
        }

        [HttpDelete]
        public async Task<bool> DeleteCourse(Guid id)
        {
            return await _dbContext.CourseRepository.DeleteCourseAsync(id);
        }

        [HttpPut]
        public async Task<bool> UpdateCourse(Course course)
        {
            return await _dbContext.CourseRepository.UpdateCourseAsync(course);
        }
    }
}
