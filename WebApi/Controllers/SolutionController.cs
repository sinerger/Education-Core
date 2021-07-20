using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.Solutions;
using Domain.Interfaces;
using WebApi.Routes;

namespace WebApi.Controllers
{
    [Route(ApiRoutes.Api + ApiRoutes.Controller)]
    [ApiController]
    public class SolutionController : ControllerBase
    {
        private readonly IDBContext _dbContext;

        public SolutionController(IDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet(ApiRoutes.Solution.GetAllSolutionsByHomeworkID)]
        public async Task<IEnumerable<Solution>> GetAllSolutionsByHomeworkID(Guid homeworkId)
        {
            return await _dbContext.SolutionRepository.GetAllSolutionsByHomeworkIDAsync(homeworkId);
        }

        [HttpGet(ApiRoutes.Solution.GetAllSolutionsByStudentID)]
        public async Task<IEnumerable<Solution>> GetAllSolutionsByStudentID(Guid studentId)
        {
            return await _dbContext.SolutionRepository.GetAllSolutionsByStudentIDAsync(studentId);
        }

        [HttpPost(ApiRoutes.Solution.CreateSolutionWithinHomework)]
        public async Task CreateSolutionWithinHomework(Guid studentID, Solution solution)
        {
            await _dbContext.SolutionRepository.CreateSolutionWithinHomeworkAsync(studentID, solution);
        }

        [HttpPut(ApiRoutes.Solution.UpdateSolution)]
        public async Task UpdateSolution(Solution solution)
        {
            await _dbContext.SolutionRepository.UpdateSolutionAsync(solution);
        }

        [HttpDelete(ApiRoutes.Solution.DeleteSolution)]
        public async Task DeleteSolution(Guid id)
        {
            await _dbContext.SolutionRepository.DeleteSolutionAsync(id);
        }
    }
}
