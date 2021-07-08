using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Users;

namespace Domain.Interfaces.UserRepositoryInterfaces
{
    public interface ITeacherRepository : IRepository
    {
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();
        Task<Teacher> GetTeacherByIDAsync(Guid id);
        Task<bool> CreateTeacherAsync(Teacher teacher);
        Task<bool> UpdateTeacherAsync(Teacher teacher);
        Task<bool> DeleteTeacherByIDAsync(Guid id);
    }
}
