using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Insight.Database;
using Domain.Entities.Lessons;
using Domain.Interfaces.LessonRepositoryInterfaces;
using DataAccess.InsightDatabase.Extensions;

namespace DataAccess.InsightDatabase.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        public IDbConnection DBConnection { get; }
        private readonly ILessonRepository _lessonRepository;

        public LessonRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _lessonRepository = DBConnection.As<ILessonRepository>();
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonsAsync()
        {
            try
            {
                return await _lessonRepository.GetAllLessonsAsync();
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<Lesson> GetLessonByIDAsync(Guid id)
        {
            try
            {
                return await _lessonRepository.GetLessonByIDAsync(id);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task CreateLessonWithinCourseAsync(Lesson lesson)
        {
            try
            {
                var TeacherID = lesson.Teacher.ID;
                var courseID = lesson.Course.ID;
                lesson.ID = lesson.ID == Guid.Empty ? Guid.NewGuid() : lesson.ID;

                await DBConnection.QueryAsync(nameof(CreateLessonWithinCourseAsync).GetStoredProcedureName(),
                    parameters: new
                    {
                        lesson.ID,
                        lesson.Title,
                        lesson.Description,
                        lesson.DeadLine,
                        courseID
                    });
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task UpdateLessonAsync(Lesson lesson)
        {
            try
            {
                var HomeworkID = lesson.Homework.ID;

                await DBConnection.QueryAsync(nameof(UpdateLessonAsync).GetStoredProcedureName(),
                    parameters: new
                    {
                        lesson.ID,
                        lesson.Title,
                        lesson.Description,
                        lesson.DeadLine,
                        HomeworkID
                    });
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task DeleteLessonAsync(Guid id)
        {
            try
            {
                await _lessonRepository.DeleteLessonAsync(id);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }
    }
}
