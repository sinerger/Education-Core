using Domain.Entities.Courses;
using Domain.Entities.Groups;
using Domain.Entities.Users;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.UserRepositoryInterfaces
{
    public interface ITeacherRepository : IRepository
    {
        [Recordset(1, typeof(Group), typeof(Course), IsChild = true, Into = nameof(Teacher.Groups))]
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();
        [Recordset(1, typeof(Group), typeof(Course), IsChild = true, Into = nameof(Teacher.Groups))]
        Task<Teacher> GetTeacherByIDAsync(Guid id);
        Task AddTeacherToGroupAsync(Guid groupID, Guid userID);
        Task AddTeacherToLessonAsync(Guid lessonID, Guid teacherID);
        Task CreateTeacherAsync(Teacher teacher);
        Task UpdateTeacherAsync(Teacher teacher);
        Task DeleteTeacherAsync(Guid id);
    }
}
