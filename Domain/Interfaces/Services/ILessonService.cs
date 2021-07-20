using Domain.Entities.Lessons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ILessonService
    {
        Task<IServiceResponce<IEnumerable<Lesson>>> GetAllLessonsAsync();
        Task<IServiceResponce<Lesson>> GetLessonByIDAsync(Guid id);
        Task<IServiceResponce<bool>> CreateLessonWithinCourseAsync(Lesson lesson);
        Task<IServiceResponce<bool>> UpdateLessonAsync(Lesson lesson);
        Task<IServiceResponce<bool>> DeleteLessonAsync(Guid id);
    }
}
