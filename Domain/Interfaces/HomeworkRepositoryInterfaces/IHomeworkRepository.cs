using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Homeworks;

namespace Domain.Interfaces.HomeworkRepositoryInterfaces
{
    public interface IHomeworkRepository : IRepository
    {
        Task<IEnumerable<Homework>> GetAllHomeworkByCourseIDAsync(Guid CourseID);
        Task<Homework> GetHomeworkByLessonIDAsync(Guid LessonID);
        Task<bool> CreateHomeworkWithinLessonAsync(Guid LessonID ,Homework homework);
        Task<bool> UpdateHomeworkAsync(Homework homework);
        Task<bool> DeleteHomeworkAsync(Guid id);
    }
}
