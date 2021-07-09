using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Insight.Database;
using Domain.Entities.Roles;
using Domain.Entities.Users;

namespace Domain.Interfaces.UserRepositoryInterfaces
{
    public interface IUserWithRoleRepository : IRepository
    {
        [Recordset(typeof(UserWithRole), typeof(Role))]
        Task<IEnumerable<UserWithRole>> GetUsersWithRoleAsync();

        [Recordset(typeof(UserWithRole), typeof(Role))]
        Task<UserWithRole> GetUserWithRoleByIDAsync(Guid id);

        [Recordset(typeof(UserWithRole), typeof(Role))]
        Task<UserWithRole> GetUserWithRoleByLoginAndPasswordAsync(string login, string password);

        Task<bool> CreateUserWithRoleAsync(UserWithRole user);
        Task<bool> UpdateUserWithRoleAsync(UserWithRole user);
        Task<bool> DeleteUserWithRoleAsync(Guid id);
    }
}
