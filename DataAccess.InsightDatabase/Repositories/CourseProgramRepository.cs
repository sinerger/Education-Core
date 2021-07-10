using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Insight.Database;
using Domain.Entities.CoursePrograms;
using Domain.Interfaces.CourseRepositoryIntarfaces;

namespace DataAccess.InsightDatabase.Repositories
{
    public class CourseProgramRepository : ICourseProgramRepository
    {
        public IDbConnection DBConnection { get; }

        public CourseProgramRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
        }

        public async Task<bool> DeleteCourseProgramAsync(Guid id)
        {
            try
            {
                ICourseProgramRepository courseProgramRepository = DBConnection.As<ICourseProgramRepository>();
                
                return await courseProgramRepository.DeleteCourseProgramAsync(id);
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog
                throw e;
            }
        }

        public async Task<IEnumerable<CourseProgram>> GetAllCourseProgramAsync()
        {
            try
            {
                ICourseProgramRepository courseProgramRepository = DBConnection.As<ICourseProgramRepository>();

                return await courseProgramRepository.GetAllCourseProgramAsync();

            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog
                throw e;
            }
        }

        public async Task<CourseProgram> GetCourseProgramByIDAsync(Guid id)
        {
            try
            {
                ICourseProgramRepository courseProgramRepository = DBConnection.As<ICourseProgramRepository>();

                return await courseProgramRepository.GetCourseProgramByIDAsync(id);

            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog
                throw e;
            }
        }

        public async Task<bool> CreateCourseProgramAsync(CourseProgram courseProgram)
        {
            try
            {
                var LessonID = courseProgram.Lesson.ID;
                var CourseID = courseProgram.Course.ID;
                courseProgram.ID = Guid.NewGuid();

                await DBConnection.QueryAsync(nameof(CreateCourseProgramAsync),
                    parameters: new
                    {
                        courseProgram.ID,
                        LessonID,
                        CourseID
                    });

                return true;
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog
                throw e;
            }
        }

        public async Task<bool> UpdateCourseProgramAsync(CourseProgram courseProgram)
        {
            try
            {
                var LessonID = courseProgram.Lesson.ID;
                var CourseID = courseProgram.Course.ID;
                courseProgram.ID = Guid.NewGuid();

                await DBConnection.QueryAsync(nameof(UpdateCourseProgramAsync),
                    parameters: new
                    {
                        courseProgram.ID,
                        LessonID,
                        CourseID
                    });

                return true;
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog
                throw e;
            }
        }
    }
}
