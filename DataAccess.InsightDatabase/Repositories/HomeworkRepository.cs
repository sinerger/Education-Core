using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Homeworks;
using Domain.Interfaces.HomeworkRepositoryInterfaces;
using Insight.Database;

namespace DataAccess.InsightDatabase.Repositories
{
    public class HomeworkRepository : IHomeworkRepository
    {
        private readonly IHomeworkRepository _homeworkRepository;
        public IDbConnection DBConnection { get; }

        public HomeworkRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _homeworkRepository = DBConnection.As<IHomeworkRepository>();
        }

        public async Task CreateHomeworkAsync(Homework homework)
        {
            try
            {
                homework.ID = homework.ID == Guid.Empty ? Guid.NewGuid() : homework.ID;
                await _homeworkRepository.CreateHomeworkAsync(homework);
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

        public async Task<IEnumerable<Homework>> GetAllHomeworksByCourseIDAsync(Guid courseID)
        {
            try
            {
                return await _homeworkRepository.GetAllHomeworksByCourseIDAsync(courseID);

            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<Homework> GetHomeworkByLessonIDAsync(Guid lessonID)
        {
            try
            {
                return await _homeworkRepository.GetHomeworkByLessonIDAsync(lessonID);
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

        public async Task AddHomeworkWithinLessonAsync(Guid lessonID, Homework homework)
        {
            try
            {
                var homeworkID = homework.ID;
                await DBConnection.QueryAsync(nameof(AddHomeworkWithinLessonAsync).GetStoredProcedureName(),
                    new
                    {
                        homeworkID,
                        lessonID
                    });

            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }
    }
}
