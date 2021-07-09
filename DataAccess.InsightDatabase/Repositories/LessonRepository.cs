﻿using Domain.Entities.Lesson;
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
        public IDbConnection DBConnection { get; }
        private ILessonRepository _lessonRepository;

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
                // TODO: Работаем с Serilog
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
                // TODO: Работаем с Serilog
                throw e;
            }
        }

        public async Task<bool> CreateLessonWithinCourseAsync(Lesson lesson,Guid CoursID)
        {
            try
            {
                var TeacherID = lesson.Teacher.ID;
                var HomeworkID = lesson.Homework.ID;
                lesson.ID = Guid.NewGuid();

                await DBConnection.QueryAsync(nameof(CreateLessonWithinCourseAsync),
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
                return await _lessonRepository.DeleteLessonAsync(id);
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog
                throw e;
            }
        }
    }
}
