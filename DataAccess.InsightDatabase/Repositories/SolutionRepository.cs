using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Insight.Database;
using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Solutions;
using Domain.Interfaces.SolutionRepositoryInterfaces;
using Serilog;

namespace DataAccess.InsightDatabase.Repositories
{
    class SolutionRepository : ISolutionRepository
    {
        private readonly ISolutionRepository _solutionRepository;
        public IDbConnection DBConnection { get; }

        public SolutionRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _solutionRepository = DBConnection.As<ISolutionRepository>();
        }

        public async Task<bool> CreateSolutionWithinHomeworkAsync(Guid homeworkId, Solution solution)
        {
            try
            {
                using (var transaction = DBConnection.OpenWithTransaction())
                {
                    await DBConnection.QueryAsync(nameof(CreateSolutionWithinHomeworkAsync).GetStoredProcedureName(),
                        parameters: new
                        {
                            solution.ID,
                            solution.Answer,
                            solution.Mark,
                            homeworkId
                        });
                }

                return true;
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<bool> AddSolutionToStudentAsync(Guid studentId, Solution solution)
        {
            try
            {
                using (var transaction = DBConnection.OpenWithTransaction())
                {
                    await DBConnection.QueryAsync(nameof(AddSolutionToStudentAsync).GetStoredProcedureName(),
                        parameters: new
                        {
                            solution.ID,
                            solution.Answer,
                            solution.Mark,
                            studentId
                        });
                }

                return true;
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<bool> DeleteSolutionAsync(Guid id)
        {
            try
            {
                return await _solutionRepository.DeleteSolutionAsync(id);
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

        public async Task<bool> UpdateSolutionAsync(Solution solution)
        {
            try
            {
                await DBConnection.QueryAsync(nameof(UpdateSolutionAsync).GetStoredProcedureName(),
                        parameters: new
                        {
                            solution.ID,
                            solution.Answer,
                            solution.Mark
                        });

                return true;
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }
    }
}
