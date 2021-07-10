using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.Solutions;
using Domain.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionController : ControllerBase
    {
        private readonly IDBContext _dbContext;

        public SolutionController(IDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet("{homeworkid}")]
        public async Task<IEnumerable<Solution>> GetAllSolutionsByHomeworkID(Guid homeworkId)
        {
            return await _dbContext.SolutionRepository.GetAllSolutionsByHomeworkIDAsync(homeworkId);
        }

        [HttpGet("{studentid}")]
        public async Task<IEnumerable<Solution>> GetAllSolutionsByStudentID(Guid studentId)
        {
            return await _dbContext.SolutionRepository.GetAllSolutionsByStudentIDAsync(studentId);
        }

        [HttpPost]
        public async Task<bool> CreateSolutionWithinHomework(Guid homeworkId,Solution solution)
        {
            return await _dbContext.SolutionRepository.CreateSolutionWithinHomeworkAsync(homeworkId, solution);
        }

        [HttpPost("{studentid}")]
        public async Task<bool> AddSolutionToStudent(Guid studentId,Solution solution)
        {
            return await _dbContext.SolutionRepository.AddSolutionToStudentAsync(studentId, solution);
        }

        [HttpPut]
        public async Task<bool> UpdateSolution(Solution solution)
        {
            return await _dbContext.SolutionRepository.UpdateSolutionAsync(solution);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteSolution(Guid id)
        {
            return await _dbContext.SolutionRepository.DeleteSolutionAsync(id);
        }
    }
}
