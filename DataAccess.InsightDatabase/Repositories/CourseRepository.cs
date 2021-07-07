using Domain.Entities.Courses;
using Domain.Interfaces.CouseRepositoryInterfaces;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
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

        public Task<bool> CreateCourse(Course course)
        {
            ICourseRepository courseRepository = DBConnection.As<ICourseRepository>();

            return courseRepository.CreateCourse(course);
        }

        public async Task<bool> DeleteCourse(Guid id)
        {
            try
            {
                await DBConnection.QueryAsync(nameof(DeleteCourse), new { id });
                return true;
            }
            catch (Exception e)
            {
                //Serilog
                throw e;
            }
        }

        public List<Course> GetAllCourses()
        {
            ICourseRepository courseRepository = DBConnection.As<ICourseRepository>();
            
            return courseRepository.GetAllCourses();
        }

        public Course GetCourseById(Guid id)
        {
            ICourseRepository courseRepository = DBConnection.As<ICourseRepository>();
            
            return courseRepository.GetCourseById(id);
        }

        public Task<bool> UpdateCourse(Course course)
        {
            ICourseRepository courseRepository = DBConnection.As<ICourseRepository>();
            
            return courseRepository.UpdateCourse(course);
        }
    }
}
