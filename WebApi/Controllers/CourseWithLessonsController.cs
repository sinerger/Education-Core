using Domain.Entities.Courses;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApi.Routes;

namespace WebApi.Controllers
{
    [Route(ApiRoutes.Api + ApiRoutes.Controller)]
    [ApiController]
    public class CourseWithLessonsController : ControllerBase
    {
        private readonly IDBContext _dbContext;

        public CourseWithLessonsController(IDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet(ApiRoutes.CourseWithLessons.GetCourceWithLessonsByID)]
        public async Task<CourseWithLessons> GetCourceWithLessonsByID(Guid id)
        {
            return await _dbContext.CourseWithLessonsRepository.GetCourseWithLessonsByIDAsync(id);
        }
    }
}
