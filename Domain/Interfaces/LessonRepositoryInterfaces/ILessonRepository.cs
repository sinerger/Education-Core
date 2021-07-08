using Domain.Entities.Homeworks;
using Domain.Entities.Lesson;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.LessonRepositoryInterfaces
{
    public interface ILessonRepository : IRepository
    {
        [Recordset(typeof(Lesson), typeof(Teacher))]
        [Recordset(typeof(Lesson),typeof(Homework))]
        //TODO one to many
        Task<IEnumerable<Lesson>> GetAllLessonAsync();
        [Recordset(typeof(Lesson), typeof(Teacher))]
        [Recordset(typeof(Lesson), typeof(Homework))]
        //TODO one to many
        Task<Lesson> GetLessonByIdAsync(Guid id);
        Task<bool> CreateLessonAsync(Lesson lesson);
        Task<bool> UpdateLessonAsync(Lesson lesson);
        Task<bool> DeleteLessonAsync(Guid id);
    }
}
