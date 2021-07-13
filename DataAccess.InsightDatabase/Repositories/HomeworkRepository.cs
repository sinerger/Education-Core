using Serilog;
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Domain.Entities.Homeworks;
using Domain.Interfaces.HomeworkRepositoryInterfaces;
using Insight.Database;

namespace DataAccess.InsightDatabase.Repositories
{
    public class HomeworkRepository : IHomeworkRepository
    {
        public IDbConnection DBConnection { get; }
        private readonly IHomeworkRepository _homeworkRepository;

        public HomeworkRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _homeworkRepository = DBConnection.As<IHomeworkRepository>();
        }

        public async Task CreateHomeworkWithinLessonAsync(Guid LessonID ,Homework homework)
        {
            try
            {
                await _homeworkRepository.CreateHomeworkWithinLessonAsync(LessonID , homework);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task DeleteHomeworkAsync(Guid id)
        {
            try
            {
                await _homeworkRepository.DeleteHomeworkAsync(id); 
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<IEnumerable<Homework>> GetAllHomeworkByCourseIDAsync(Guid CourseID)
        {
            try
            {
                return await _homeworkRepository.GetAllHomeworkByCourseIDAsync(CourseID); 
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<Homework> GetHomeworkByLessonIDAsync(Guid LessonID)
        {
            try
            {
                return await _homeworkRepository.GetHomeworkByLessonIDAsync(LessonID);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task UpdateHomeworkAsync(Homework homework)
        {
            try
            {
                await _homeworkRepository.UpdateHomeworkAsync(homework);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }
    }
}
