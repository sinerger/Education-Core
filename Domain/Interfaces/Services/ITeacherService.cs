using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ITeacherService
    {
        Task<IServiceResponce<IEnumerable<Teacher>>> GetAllTeachersAsync();
        Task<IServiceResponce<Teacher>> GetTeacherByIDAsync(Guid id);
        Task<IServiceResponce<bool>> AddTeacherToGroupAsync(Guid groupId, Guid userID);
        Task<IServiceResponce<bool>> AddTeacherToLessonAsync(Guid LessonID, Guid TeacherID);
        Task<IServiceResponce<bool>> CreateTeacherAsync(Teacher teacher);
        Task<IServiceResponce<bool>> UpdateTeacherAsync(Teacher teacher);
        Task<IServiceResponce<bool>> DeleteTeacherAsync(Guid id);
    }
}
