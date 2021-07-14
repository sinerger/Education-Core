using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Insight.Database;
using Domain.Entities.Homeworks;
using Domain.Entities.Lessons;
using Domain.Entities.Users;
using Domain.Entities.Courses;

namespace Domain.Interfaces.LessonRepositoryInterfaces
{
    public interface ILessonRepository : IRepository
    {
        [Recordset(typeof(Lesson), typeof(Homework), typeof(Course), typeof(Teacher))]
        Task<IEnumerable<Lesson>> GetAllLessonsAsync();
        [Recordset(typeof(Lesson), typeof(Homework), typeof(Course), typeof(Teacher))]
        Task<Lesson> GetLessonByIDAsync(Guid id);
        Task CreateLessonWithinCourseAsync(Lesson lesson);
        Task UpdateLessonAsync(Lesson lesson);
        Task DeleteLessonAsync(Guid id);
    }
}
