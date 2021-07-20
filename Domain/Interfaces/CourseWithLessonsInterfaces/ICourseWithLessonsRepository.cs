using Domain.Entities.Courses;
using Domain.Entities.Homeworks;
using Domain.Entities.Lessons;
using Domain.Entities.Users;
using Insight.Database;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.ICourseWithLessonsInterfaces
{
    public interface ICourseWithLessonsRepository : IRepository
    {
        [Recordset(1, typeof(Lesson),typeof(Homework),typeof(Course),typeof(Teacher), IsChild = true, Into = nameof(CourseWithLessons.Lessons))]
        Task<CourseWithLessons> GetCourseWithLessonsByIDAsync(Guid id);
    }
}
