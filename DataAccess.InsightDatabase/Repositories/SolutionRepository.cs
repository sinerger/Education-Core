using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Insight.Database;
using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Solutions;
using Domain.Interfaces.SolutionRepositoryInterfaces;
using Serilog;

namespace DataAccess.InsightDatabase.Repositories
{
    public class SolutionRepository : ISolutionRepository
    {
        private readonly ISolutionRepository _solutionRepository;
        public IDbConnection DBConnection { get; }

        public SolutionRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _solutionRepository = DBConnection.As<ISolutionRepository>();
        }

        public async Task CreateSolutionWithinHomeworkAsync(Guid studentID, Solution solution)
        {
            try
            {
                var homeworkID = solution.Homework.ID;

                await DBConnection.QueryAsync(nameof(CreateSolutionWithinHomeworkAsync).GetStoredProcedureName(),
                    parameters: new
                    {
                        solution.ID,
                        solution.Answer,
                        solution.Mark,
                        homeworkID,
                        studentID
                    });
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task DeleteSolutionAsync(Guid id)
        {
            try
            {
                await _solutionRepository.DeleteSolutionAsync(id);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<IEnumerable<Solution>> GetAllSolutionsByHomeworkIDAsync(Guid homeworkId)
        {
            try
            {
                return await _solutionRepository.GetAllSolutionsByHomeworkIDAsync(homeworkId);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<IEnumerable<Solution>> GetAllSolutionsByStudentIDAsync(Guid studentId)
        {
            try
            {
                return await _solutionRepository.GetAllSolutionsByStudentIDAsync(studentId);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task UpdateSolutionAsync(Solution solution)
        {
            try
            {
                var homeworkID = solution.Homework.ID;
                await DBConnection.QueryAsync(nameof(UpdateSolutionAsync).GetStoredProcedureName(),
                        parameters: new
                        {
                            solution.ID,
                            solution.Answer,
                            solution.Mark,
                            homeworkID
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
