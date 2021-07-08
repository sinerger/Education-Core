using Domain.Entities.Lesson1;
using Domain.Interfaces.LessonRepositoryiInterfaces;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess.InsightDatabase.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        public IDbConnection DBConnection { get; }

        public LessonRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonAsync()
        {
            try
            {
                ILessonRepository lessonRepository = DBConnection.As<ILessonRepository>();

                return await lessonRepository.GetAllLessonAsync();

            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog
                throw e;
            }
        }

        public async Task<Lesson> GetLessonByIdAsync(Guid id)
        {
            try
            {
                ILessonRepository lessonRepository = DBConnection.As<ILessonRepository>();

                return await lessonRepository.GetLessonByIdAsync(id);

            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog
                throw e;
            }
        }

        public async Task<bool> CreateLessonAsync(Lesson lesson)
        {
            try
            {
                var TeacherID = lesson.Teacher.ID;
                var HomeworkID = lesson.Homework.ID;
                lesson.ID = Guid.NewGuid();

                await DBConnection.QueryAsync(nameof(CreateLessonAsync),
                    parameters: new
                    {
                        lesson.ID,
                        lesson.Title,
                        lesson.Description,
                        lesson.Deadline,
                        lesson.Attendance,
                        TeacherID,
                        HomeworkID
                    });

                return true;
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog
                throw e;
            }
        }

        public async Task<bool> UpdateLessonAsync(Lesson lesson)
        {
            try
            {
                var TeacherID = lesson.Teacher.ID;
                var HomeworkID = lesson.Homework.ID;
                lesson.ID = Guid.NewGuid();

                await DBConnection.QueryAsync(nameof(UpdateLessonAsync),
                    parameters:new
                    { 
                        lesson.ID,
                        lesson.Title,
                        lesson.Description,
                        lesson.Deadline,
                        lesson.Attendance,
                        TeacherID,
                        HomeworkID
                    });

                return true;
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog
                throw e;
            }
        }

        public async Task<bool> DeleteLessonAsync(Guid id)
        {
            try
            {
                ILessonRepository lessonRepository = DBConnection.As<ILessonRepository>();

                return await lessonRepository.DeleteLessonAsync(id);

            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog
                throw e;
            }
        }
    }
}
