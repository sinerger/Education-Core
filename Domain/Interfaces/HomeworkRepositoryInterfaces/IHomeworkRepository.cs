using Domain.Entities.Homeworks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.HomeworkRepositoryInterfaces
{
    public interface IHomeworkRepository : IRepository
    {
        Task<IEnumerable<Homework>> GetAllHomeworkByCourseIDAsync(Guid CourseID);
        Task<Homework> GetHomeworkByLessonIdAsync(Guid LessonID);
        Task<bool> CreateHomeworkWithinLessonAsync(Homework homework, Guid LessonID);
        Task<bool> UpdateHomeworkAsync(Homework homework);
        Task<bool> DeleteHomeworkAsync(Guid id);
    }
}
