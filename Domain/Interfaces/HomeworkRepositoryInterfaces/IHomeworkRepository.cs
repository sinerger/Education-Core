using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Homeworks;

namespace Domain.Interfaces.HomeworkRepositoryInterfaces
{
    public interface IHomeworkRepository : IRepository
    {
        Task<IEnumerable<Homework>> GetAllHomeworkByCourseIDAsync(Guid CourseID);
        Task<Homework> GetHomeworkByLessonIDAsync(Guid LessonID);
        Task CreateHomeworkWithinLessonAsync(Guid LessonID, Homework homework);
        Task UpdateHomeworkAsync(Homework homework);
        Task DeleteHomeworkAsync(Guid id);
    }
}
