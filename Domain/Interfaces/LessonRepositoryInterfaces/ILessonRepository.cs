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
        Task<Lesson> GetLessonByIDAsync(Guid id);
        Task<bool> CreateLessonWithinCourseAsync(Guid CoursID,Lesson lesson);
        Task<bool> UpdateLessonAsync(Lesson lesson);
        Task<bool> DeleteLessonAsync(Guid id);
    }
}
