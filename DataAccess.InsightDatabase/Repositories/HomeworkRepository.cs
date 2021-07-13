using System;
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
        private IHomeworkRepository _homeworkRepository;

        public HomeworkRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _homeworkRepository = DBConnection.As<IHomeworkRepository>();
        }

        public async Task<bool> CreateHomeworkAsync(Homework homework)
        {
            try
            {
                return await _homeworkRepository.CreateHomeworkAsync(homework);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteHomeworkAsync(Guid id)
        {
            try
            {
                return await _homeworkRepository.DeleteHomeworkAsync(id); 
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Homework>> GetHomeworkAsync()
        {
            try
            {
                return await _homeworkRepository.GetHomeworkAsync(); 
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Homework> GetHomeworkByIdAsync(Guid id)
        {
            try
            {
                return await _homeworkRepository.GetHomeworkByIdAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdateHomeworkAsync(Homework homework)
        {
            try
            {
                return await _homeworkRepository.UpdateHomeworkAsync(homework);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
