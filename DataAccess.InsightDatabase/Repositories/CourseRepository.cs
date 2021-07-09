using Domain.Entities.Courses;
using Domain.Interfaces.CouseRepositoryInterfaces;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess.InsightDatabase.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public IDbConnection DBConnection { get; }
        private ICourseRepository _courseRepository; 

        public CourseRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _courseRepository = DBConnection.As<ICourseRepository>();
        }

        public async Task<bool> CreateCourseAsync(Course course)
        {
            try
            {
                return await _courseRepository.CreateCourseAsync(course);
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog
                throw e;
            }
        }

        public async Task<bool> DeleteCourseAsync(Guid id)
        {
            try
            {
                return await _courseRepository.DeleteCourseAsync(id);
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog
                throw e;
            }
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            try
            {
                return await _courseRepository.GetAllCoursesAsync();
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog
                throw e;
            }
        }

        public async Task<bool> UpdateCourseAsync(Course course)
        {
            try
            {
                return await _courseRepository.UpdateCourseAsync(course);
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog
                throw e;
            }
        }
    }
}
