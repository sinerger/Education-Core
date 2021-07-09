using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Insight.Database;
using Domain.Entities.Users;
using Domain.Entities;

namespace Domain.Interfaces.UserRepositoryInterfaces
{
    public interface IUserDetailRepository : IRepository
    {
        [Recordset(typeof(UserDetail), typeof(Feedback))]
        Task<IEnumerable<UserDetail>> GetAllUsersDetailAsync();

        [Recordset(typeof(UserDetail), typeof(Feedback))]
        Task<UserDetail> GetUserDetailByIDAsync(Guid id);
        Task<bool> CreateDetailInfoForUserAsync(UserDetail user);
        Task<bool> UpdateUserDetailAsync(UserDetail user);
        Task<bool> DeleteUserDetailByIDAsync(int Id);
    }
}
