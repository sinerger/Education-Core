using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Insight.Database;
using Domain.Entities.Homeworks;
using Domain.Entities.Lessons;
using Domain.Entities.Users;

namespace Domain.Interfaces.LessonRepositoryInterfaces
{
    public interface ILessonRepository : IRepository
    {
        [Recordset(typeof(Lesson), typeof(Teacher))]
        [Recordset(typeof(Lesson),typeof(Homework))]
        //TODO one to many
        Task<IEnumerable<Lesson>> GetAllLessonsAsync();
        [Recordset(typeof(Lesson), typeof(Teacher))]
        [Recordset(typeof(Lesson), typeof(Homework))]
        //TODO one to many
        Task<Lesson> GetLessonByIdAsync(Guid id);
        Task<bool> CreateLessonWithinCourseAsync(Lesson lesson, Guid CoursID);
        Task<bool> UpdateLessonAsync(Lesson lesson);
        Task<bool> DeleteLessonAsync(Guid id);
    }
}
