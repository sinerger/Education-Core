using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Homeworks;

namespace Domain.Interfaces.HomeworkRepositoryInterfaces
{
    public interface IHomeworkRepository : IRepository
    {
        Task<IEnumerable<Homework>> GetAllHomeworksByCourseIDAsync(Guid courseID);
        Task<Homework> GetHomeworkByLessonIDAsync(Guid lessonID);
        Task AddHomeworkWithinLessonAsync(Guid lessonID, Homework homework);
        Task CreateHomeworkAsync(Homework homework);
        Task UpdateHomeworkAsync(Homework homework);
        Task DeleteHomeworkAsync(Guid id);
    }
}
