using Domain.Entities.Users;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.UserRepositoryInterfaces
{
    public interface IUserWithRoleRepository : IRepository
    {
        Task<UserWithRole> GetUserWithRoleByIDAsync(Guid id);
        Task<UserWithRole> GetUserWithRoleByLoginAndPasswordAsync(string login, string password);
        Task CreateUserWithRoleAsync(UserWithRole user);
        Task UpdateUserWithRoleAsync(UserWithRole user);
        Task DeleteUserWithRoleAsync(Guid id);
    }
}
