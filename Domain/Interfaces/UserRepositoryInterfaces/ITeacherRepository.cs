using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Courses;
using Domain.Entities.Groups;
using Domain.Entities.Users;
using Insight.Database;

namespace Domain.Interfaces.UserRepositoryInterfaces
{
    public interface ITeacherRepository : IRepository
    {
        [Recordset(1, typeof(Group), typeof(Course), IsChild = true, Into = nameof(Teacher.Groups))]
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();

        [Recordset(1, typeof(Group), typeof(Course), IsChild = true, Into = nameof(Teacher.Groups))]
        Task<Teacher> GetTeacherByIDAsync(Guid id);
        Task<bool> AddTeacherToGroupAsync(Guid groupId, Guid userID);
        Task<bool> AddTeacherToLessonAsync(Guid LessonID, Guid TeacherID);
        Task<bool> CreateTeacherAsync(Teacher teacher);
        Task<bool> UpdateTeacherAsync(Teacher teacher);
        Task DeleteTeacherAsync(Guid id);
    }
}
