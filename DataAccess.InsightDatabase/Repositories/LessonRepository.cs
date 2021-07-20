using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Lessons;
using Domain.Interfaces.LessonRepositoryInterfaces;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess.InsightDatabase.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly ILessonRepository _lessonRepository;
        public IDbConnection DBConnection { get; }

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
                throw e;
            }
        }

        public async Task UpdateLessonAsync(Lesson lesson)
        {
            try
            {
                var homeworkID = lesson.Homework.ID;

                await DBConnection.QueryAsync(nameof(UpdateLessonAsync).GetStoredProcedureName(),
                    parameters: new
                    {
                        lesson.ID,
                        lesson.Title,
                        lesson.Description,
                        lesson.DeadLine,
                        homeworkID
                    });
            }
            catch (Exception e)
            {
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
                throw e;
            }
        }
    }
}
