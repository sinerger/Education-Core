using Serilog;
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Insight.Database;
using Domain.Entities.Homeworks;
using Domain.Interfaces.HomeworkRepositoryInterfaces;

namespace DataAccess.InsightDatabase.Repositories
{
    public class HomeworkRepository : IHomeworkRepository
    {

        public IDbConnection DBConnection { get; }

        public HomeworkRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
        }

        public async Task<bool> CreateHomeworkAsync(Homework homework)
        {
            try
            {
                IHomeworkRepository homeworkRepository = DBConnection.As<IHomeworkRepository>();

                return await homeworkRepository.CreateHomeworkAsync(homework);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<bool> DeleteHomeworkAsync(Guid id)
        {
            try
            {
                IHomeworkRepository homeworkRepository = DBConnection.As<IHomeworkRepository>();

                return await homeworkRepository.DeleteHomeworkAsync(id); 
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<IEnumerable<Homework>> GetHomeworkAsync()
        {
            try
            {
                IHomeworkRepository homeworkRepository = DBConnection.As<IHomeworkRepository>();

                return await homeworkRepository.GetHomeworkAsync(); 
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<Homework> GetHomeworkByIdAsync(Guid id)
        {
            try
            {
                IHomeworkRepository homeworkRepository = DBConnection.As<IHomeworkRepository>();

                return await homeworkRepository.GetHomeworkByIdAsync(id);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<bool> UpdateHomeworkAsync(Homework homework)
        {
            try
            {
                IHomeworkRepository homeworkRepository = DBConnection.As<IHomeworkRepository>();

                return await homeworkRepository.UpdateHomeworkAsync(homework);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }
    }
}
