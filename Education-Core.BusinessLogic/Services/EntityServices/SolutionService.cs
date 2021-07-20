using Domain.Entities.Solutions;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Interfaces.SolutionRepositoryInterfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Education_Core.BusinessLogic.Services.EntityServices
{
    public class SolutionService : ISolutionService
    {
        private ISolutionRepository _solutionRepository;

        public SolutionService(IDBContext dbContext)
        {
            _solutionRepository = dbContext.SolutionRepository;
        }

        public async Task<IServiceResponce<bool>> CreateSolutionWithinHomeworkAsync(Guid homeworkId, Solution solution)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _solutionRepository.CreateSolutionWithinHomeworkAsync(homeworkId, solution);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(SolutionService) + nameof(CreateSolutionWithinHomeworkAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<bool>> DeleteSolutionAsync(Guid id)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _solutionRepository.DeleteSolutionAsync(id);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(SolutionService) + nameof(DeleteSolutionAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<IEnumerable<Solution>>> GetAllSolutionsByHomeworkIDAsync(Guid homeworkId)
        {
            var responce = new ServiceResponce<IEnumerable<Solution>>();

            try
            {
                responce.SetValidResponce(obj: await _solutionRepository.GetAllSolutionsByHomeworkIDAsync(homeworkId));
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(SolutionService) + nameof(GetAllSolutionsByHomeworkIDAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<IEnumerable<Solution>>> GetAllSolutionsByStudentIDAsync(Guid studentId)
        {
            var responce = new ServiceResponce<IEnumerable<Solution>>();

            try
            {
                responce.SetValidResponce(obj: await _solutionRepository.GetAllSolutionsByStudentIDAsync(studentId));
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(SolutionService) + nameof(GetAllSolutionsByStudentIDAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<bool>> UpdateSolutionAsync(Solution solution)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _solutionRepository.UpdateSolutionAsync(solution);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(SolutionService) + nameof(UpdateSolutionAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }
    }
}
