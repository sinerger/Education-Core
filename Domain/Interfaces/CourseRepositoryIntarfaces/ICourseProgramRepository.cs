using Domain.Entities.CourseProgram;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.CourseRepositoryIntarfaces
{
    public interface ICourseProgramRepository : IRepository
    {
        [Recordset(typeof(Course), typeof(Lesson), typeof(CourseProgram))]
        Task<CourseProgram> GetCourseProgramByIDAsync(Guid id);

        [Recordset(typeof(Course), typeof(Lesson), typeof(CourseProgram))]
        Task<IEnumerable<CourseProgram>> GetAllCourseProgramAsync();

        [Recordset(typeof(Course), typeof(Lesson), typeof(CourseProgram))]
        Task<bool> CreateCourseProgramAsync(CourseProgram courseProgram);

        [Recordset(typeof(Course), typeof(Lesson), typeof(CourseProgram))]
        Task<bool> UpdateCourseProgramAsync(CourseProgram courseProgram);

        [Recordset(typeof(Course), typeof(Lesson), typeof(CourseProgram))]
        Task<bool> DeleteCourseProgramAsync(Guid id);
    }
}
