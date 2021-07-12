using Domain.Entities.CourseProgram;
using Domain.Entities.Lesson;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.CourseRepositoryIntarfaces
{
    public interface ICourseProgramRepository : IRepository
    {
        //[Recordset(1, typeof(Course), typeof(Lesson), IsChild = true, Into = "Lesson")]
        Task<CourseProgram> GetCourseProgramByIDAsync(Guid id);

        //[Recordset(1, typeof(Course), typeof(Lesson), IsChild = true, Into = "Lesson")]
        Task<IEnumerable<CourseProgram>> GetAllCourseProgramAsync();

        Task<bool> CreateCourseProgramAsync(CourseProgram courseProgram);

        Task<bool> UpdateCourseProgramAsync(CourseProgram courseProgram);

        Task<bool> DeleteCourseProgramAsync(Guid id);
    }
}
