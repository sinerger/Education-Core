using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;
using Insight.Database;
using Domain.Entities.Roles;
using System.Threading.Tasks;

namespace Domain.Interfaces.UserRepositoryInterfaces
{
    public interface IUserWithRoleRepository : IRepository
    {
        [Recordset(typeof(UserWithRole), typeof(Role))]
        Task<UserWithRole> GetUserWithRoleByIDAsync(Guid id);

        [Recordset(typeof(UserWithRole), typeof(Role))]
        Task<UserWithRole> GetUserWithRoleByLoginAndPasswordAsync(string login, string password);

        Task<bool> UpdateUserWithRoleAsync(UserWithRole user);
        Task<bool> DeleteUserWithRoleAsync(Guid id);
    }
}
