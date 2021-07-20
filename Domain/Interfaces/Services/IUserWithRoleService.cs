using Domain.Entities.Users;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IUserWithRoleService 
    {
        Task<IServiceResponce<UserWithRole>> GetUserWithRoleByIDAsync(Guid id);
        Task<IServiceResponce<UserWithRole>> GetUserWithRoleByLoginAndPasswordAsync(string login, string password);
        Task<IServiceResponce<bool>> CreateUserWithRoleAsync(UserWithRole user);
        Task<IServiceResponce<bool>> UpdateUserWithRoleAsync(UserWithRole user);
        Task<IServiceResponce<bool>> DeleteUserWithRoleAsync(Guid id);
    }
}
