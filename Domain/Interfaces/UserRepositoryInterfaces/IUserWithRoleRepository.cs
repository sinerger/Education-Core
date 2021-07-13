using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Insight.Database;
using Domain.Entities.Roles;
using Domain.Entities.Users;

namespace Domain.Interfaces.UserRepositoryInterfaces
{
    public interface IUserWithRoleRepository : IRepository
    {
        Task CreateUserWithRoleAsync(UserWithRole user);
        Task<UserWithRole> GetUserWithRoleByIDAsync(Guid id);
        Task<UserWithRole> GetUserWithRoleByLoginAndPasswordAsync(string login, string password);
        Task UpdateUserWithRoleAsync(UserWithRole user);
        Task DeleteUserWithRoleAsync(Guid id);
    }
}
