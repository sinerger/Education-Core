using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Solutions;

namespace Domain.Interfaces.SolutionRepositoryInterfaces
{
    public interface ISolutionRepository : IRepository
    {
        Task<IEnumerable<Solution>> GetAllSolutionsByHomeworkIDAsync(Guid homeworkId);
        Task<IEnumerable<Solution>> GetAllSolutionsByStudentIDAsync(Guid studentId);
        Task<bool> AddSolutionToStudentAsync(Guid studentId, Solution solution);
        Task<bool> CreateSolutionWithinHomeworkAsync(Guid homeworkId, Solution solution);
        Task<bool> UpdateSolutionAsync(Solution solution);
        Task<bool> DeleteSolutionAsync(Guid id);
    }
}
