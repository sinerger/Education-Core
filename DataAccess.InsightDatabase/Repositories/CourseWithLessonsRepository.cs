using Domain.Entities.Courses;
using Domain.Interfaces.ICourseWithLessonsInterfaces;
using Insight.Database;
using Serilog;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess.InsightDatabase.Repositories
{
    public class CourseWithLessonsRepository : ICourseWithLessonsRepository
    {
        private readonly ICourseWithLessonsRepository _courseWithLessonsRepository;
        public IDbConnection DBConnection { get; }

        public CourseWithLessonsRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _courseWithLessonsRepository = DBConnection.As<ICourseWithLessonsRepository>();
        }

        public async Task<CourseWithLessons> GetCourseWithLessonsByIDAsync(Guid id)
        {
            try
            {
                return await _courseWithLessonsRepository.GetCourseWithLessonsByIDAsync(id);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }
    }
}
