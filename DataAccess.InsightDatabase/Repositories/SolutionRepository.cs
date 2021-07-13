using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Insight.Database;
using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Solutions;
using Domain.Interfaces.SolutionRepositoryInterfaces;

namespace DataAccess.InsightDatabase.Repositories
{
    public class SolutionRepository : ISolutionRepository
    {
        public IDbConnection DBConnection { get; }
        private readonly ISolutionRepository _solutionRepository;

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
                // TODO: Работаем с Serilog

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
                // TODO: Работаем с Serilog

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
                // TODO: Работаем с Serilog

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
                // TODO: Работаем с Serilog

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
                // TODO: Работаем с Serilog

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
                // TODO: Работаем с Serilog

                throw e;
            }
        }
    }
}
