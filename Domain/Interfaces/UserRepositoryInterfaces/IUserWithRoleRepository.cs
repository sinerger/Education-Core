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
        IEnumerable<UserWithRole> GetUsersWithRole();

        [Recordset(typeof(UserWithRole), typeof(Role))]
        UserWithRole GetUserWithRoleByID(Guid id);

        [Recordset(typeof(UserWithRole), typeof(Role))]
        UserWithRole GetUserWithRoleByLoginAndPassword(string login, string password);
        Task<bool> CreateUserWithRole(UserWithRole user);
        Task<bool> UpdateUserWithRole(UserWithRole user);
        Task<bool> DeleteUserWithRole(Guid id);

        Task TestTransaction(UserWithRole user);
    }
}
