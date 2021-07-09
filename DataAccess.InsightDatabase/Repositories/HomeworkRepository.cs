using Domain.Entities.Homeworks;
using Domain.Interfaces.HomeworkRepositoryInterfaces;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

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

        public async Task<bool> CreateHomeworkWithinLessonAsync(Homework homework,Guid LessonID)
        {
            try
            {
                return await _homeworkRepository.CreateHomeworkWithinLessonAsync(homework,LessonID);
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
                return await _homeworkRepository.DeleteHomeworkAsync(id); 
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog
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
                // TODO: Работаем с Serilog
                throw e;
            }
        }

        public async Task<Homework> GetHomeworkByLessonIdAsync(Guid LessonID)
        {
            try
            {
                return await _homeworkRepository.GetHomeworkByLessonIdAsync(LessonID);
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
                return await _homeworkRepository.UpdateHomeworkAsync(homework);
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog
                throw e;
            }
        }
    }
}
