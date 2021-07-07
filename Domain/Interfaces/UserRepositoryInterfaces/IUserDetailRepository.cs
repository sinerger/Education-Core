using Domain.Entities.Users;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.UserRepositoryInterfaces
{
    public interface IUserDetailRepository : IRepository
    {
        [Recordset(typeof(UserDetail), typeof(Feedback))]
        Task<IEnumerable<UserDetail>> GetAllUsersDetailAsync();

        [Recordset(typeof(UserDetail), typeof(Feedback))]
        Task<UserDetail> GetUserDetailByIDAsync(Guid id);
        Task<bool> CreateUserDetailAsync(UserDetail user);
        Task<bool> UpdateUserDetailAsync(UserDetail user);
        Task<bool> DeleteUserDetailByIDAsync(int Id);
    }
}
