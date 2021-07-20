using Domain.Entities.Courses;
using Domain.Interfaces;
using Domain.Interfaces.CouseRepositoryInterfaces;
using Domain.Interfaces.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Education_Core.BusinessLogic.Services.EntityServices
{
    public class CourseService : ICourseService
    {
        private ICourseRepository _courseRepository;

        public CourseService(IDBContext dbContext)
        {
            _courseRepository = dbContext.CourseRepository;
        }

        public async Task<IServiceResponce<bool>> CreateCourseAsync(Course course)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _courseRepository.CreateCourseAsync(course);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(CourseService) + nameof(CreateCourseAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<bool>> DeleteCourseAsync(Guid id)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _courseRepository.DeleteCourseAsync(id);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(CourseService) + nameof(DeleteCourseAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<IEnumerable<Course>>> GetAllCoursesAsync()
        {
            var responce = new ServiceResponce<IEnumerable<Course>>();

            try
            {

                responce.SetValidResponce(obj: await _courseRepository.GetAllCoursesAsync());
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(CourseService) + nameof(GetAllCoursesAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<bool>> UpdateCourseAsync(Course course)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _courseRepository.UpdateCourseAsync(course);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(CourseService) + nameof(UpdateCourseAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }
    }
}
