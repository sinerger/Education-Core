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
        public IDbConnection DBConnection { get; set; }

        public CourseRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
        }

        public async Task<bool> CreateCourseAsync(Course course)
        {
            try
            {
                ICourseRepository courseRepository = DBConnection.As<ICourseRepository>();

                return await courseRepository.CreateCourseAsync(course);
            }
            catch (Exception e)
            {
                //Serilog
                throw e;
            }
        }

        public async Task<bool> DeleteCourseAsync(Guid id)
        {
            try
            {
                ICourseRepository courseRepository = DBConnection.As<ICourseRepository>();
                await courseRepository.DeleteCourseAsync(id);

                return true;
            }
            catch (Exception e)
            {
                //Serilog
                throw e;
            }
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            try
            {
                ICourseRepository courseRepository = DBConnection.As<ICourseRepository>();

                return await courseRepository.GetAllCoursesAsync();
            }
            catch (Exception e)
            {
                //Serilog
                throw e;
            }
        }

        public async Task<Course> GetCourseByIdAsync(Guid id)
        {
            try
            {
                ICourseRepository courseRepository = DBConnection.As<ICourseRepository>();

                return await courseRepository.GetCourseByIdAsync(id);
            }
            catch (Exception e)
            {
                //Serilog
                throw e;
            }
        }

        public async Task<bool> UpdateCourseAsync(Course course)
        {
            try
            {
                ICourseRepository courseRepository = DBConnection.As<ICourseRepository>();

                return await courseRepository.UpdateCourseAsync(course);
            }
            catch (Exception e)
            {
                //Serilog
                throw e;
            }
        }
    }
}
