using Domain.Entities.Solutions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ISolutionService
    {
        Task<IServiceResponce<IEnumerable<Solution>>> GetAllSolutionsByHomeworkIDAsync(Guid homeworkId);
        Task<IServiceResponce<IEnumerable<Solution>>> GetAllSolutionsByStudentIDAsync(Guid studentId);
        Task<IServiceResponce<bool>> CreateSolutionWithinHomeworkAsync(Guid homeworkId, Solution solution);
        Task<IServiceResponce<bool>> UpdateSolutionAsync(Solution solution);
        Task<IServiceResponce<bool>> DeleteSolutionAsync(Guid id);
    }
}
