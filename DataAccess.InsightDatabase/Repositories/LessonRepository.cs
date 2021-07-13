using Serilog;
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Insight.Database;
using Domain.Entities.Lessons;
using Domain.Interfaces.LessonRepositoryInterfaces;

namespace DataAccess.InsightDatabase.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        public IDbConnection DBConnection { get; }
        private ILessonRepository _lessonRepository;
        public LessonRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _lessonRepository = DBConnection.As<ILessonRepository>();
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonAsync()
        {
            try
            {
                return await _lessonRepository.GetAllLessonAsync();
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<Lesson> GetLessonByIdAsync(Guid id)
        {
            try
            {
                return await _lessonRepository.GetLessonByIdAsync(id);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

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
                Log.Logger.Error(e.ToString());

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
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<bool> DeleteLessonAsync(Guid id)
        {
            try
            {
                return await _lessonRepository.DeleteLessonAsync(id);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }
    }
}
