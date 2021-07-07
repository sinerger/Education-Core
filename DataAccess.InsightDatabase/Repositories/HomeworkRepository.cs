using Domain.Entities.Homeworks;
using Domain.Interfaces.HomeworkRepositoryInterfaces;
using Insight.Database;
using System;
using System.Data;
using System.Threading.Tasks;

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
                // TODO: Работаем с Serilog
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
                // TODO: Работаем с Serilog
                throw e;
            }
        }

        public async Task<IEquatable<Homework>> GetHomeworkAsync()
        {
            try
            {
                IHomeworkRepository homeworkRepository = DBConnection.As<IHomeworkRepository>();

                return await homeworkRepository.GetHomeworkAsync(); 
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog
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
                // TODO: Работаем с Serilog
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
                // TODO: Работаем с Serilog
                throw e;
            }
        }
    }
}
