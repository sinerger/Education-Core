using Domain.Entities.Homeworks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IHomeworkService
    {
        Task<IServiceResponce<IEnumerable<Homework>>> GetAllHomeworksByCourseIDAsync(Guid courseID);
        Task<IServiceResponce<Homework>> GetHomeworkByLessonIDAsync(Guid lessonID);
        Task<IServiceResponce<bool>> AddHomeworkWithinLessonAsync(Guid lessonID, Homework homework);
        Task<IServiceResponce<bool>> CreateHomeworkAsync(Homework homework);
        Task<IServiceResponce<bool>> UpdateHomeworkAsync(Homework homework);
        Task<IServiceResponce<bool>> DeleteHomeworkAsync(Guid id);
    }
}
