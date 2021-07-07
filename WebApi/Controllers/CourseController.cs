using Domain.Entities.Courses;
using Domain.Interfaces.CourseRepositoryInterfaces1;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controler]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourseUnitOfWork _courseUnitOfWork;

        public CourseController(ICourseUnitOfWork courseUnitOfWork)
        {
            _courseUnitOfWork = courseUnitOfWork;
        }

        [HttpGet]
        public async Task<List<Course>> GetAllCourseById()
        {
            return await _courseUnitOfWork.CourseRepository.GetAllCoursesAsync();
        }

        [HttpGet("id")]
        public async Task<Course> GetCourseById(Guid id)
        {
            return await _courseUnitOfWork.CourseRepository.GetCourseByIdAsync(id);
        }

        [HttpPost]
        public async Task<bool> CreateCourse(Course course)
        {
            return await _courseUnitOfWork.CourseRepository.CreateCourseAsync(course);
        }

        [HttpDelete]
        public async Task<bool> DeleteCourse(Guid id)
        {
            return await _courseUnitOfWork.CourseRepository.DeleteCourseAsync(id);
        }

        [HttpPut]
        public async Task<bool> UpdateCourse(Course course)
        {
            return await _courseUnitOfWork.CourseRepository.UpdateCourseAsync(course);
        }
    }
}
