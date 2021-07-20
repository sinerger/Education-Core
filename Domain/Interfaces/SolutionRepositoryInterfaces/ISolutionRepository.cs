using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Homeworks;
using Domain.Entities.Solutions;
using Insight.Database;

namespace Domain.Interfaces.SolutionRepositoryInterfaces
{
    public interface ISolutionRepository : IRepository
    {
        [Recordset(typeof(Solution),typeof(Homework))]
        Task<IEnumerable<Solution>> GetAllSolutionsByHomeworkIDAsync(Guid homeworkId);
        [Recordset(typeof(Solution), typeof(Homework))]
        Task<IEnumerable<Solution>> GetAllSolutionsByStudentIDAsync(Guid studentId);
        Task CreateSolutionWithinHomeworkAsync(Guid homeworkId, Solution solution);
        Task UpdateSolutionAsync(Solution solution);
        Task DeleteSolutionAsync(Guid id);
    }
}
