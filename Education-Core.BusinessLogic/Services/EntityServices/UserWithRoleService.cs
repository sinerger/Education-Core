using Domain.Entities.Users;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Interfaces.UserRepositoryInterfaces;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Education_Core.BusinessLogic.Services.EntityServices
{
    public class UserWithRoleService : IUserWithRoleService
    {
        private IUserWithRoleRepository _userWithRoleRepository;

        public UserWithRoleService(IDBContext dbContext)
        {
            _userWithRoleRepository = dbContext.UserWithRoleRepository;
        }

        public async Task<IServiceResponce<bool>> CreateUserWithRoleAsync(UserWithRole user)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _userWithRoleRepository.CreateUserWithRoleAsync(user);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(UserWithRoleService) + nameof(CreateUserWithRoleAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<bool>> DeleteUserWithRoleAsync(Guid id)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _userWithRoleRepository.DeleteUserWithRoleAsync(id);
                responce.SetValidResponce(true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(UserWithRoleService) + nameof(DeleteUserWithRoleAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<bool>> UpdateUserWithRoleAsync(UserWithRole user)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _userWithRoleRepository.UpdateUserWithRoleAsync(user);
                responce.SetValidResponce(true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(UserWithRoleService) + nameof(UpdateUserWithRoleAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<UserWithRole>> GetUserWithRoleByIDAsync(Guid id)
        {
            var responce = new ServiceResponce<UserWithRole>();

            try
            {
                responce.SetValidResponce(await _userWithRoleRepository.GetUserWithRoleByIDAsync(id));
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(UserWithRoleService) + nameof(GetUserWithRoleByIDAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<UserWithRole>> GetUserWithRoleByLoginAndPasswordAsync(string login, string password)
        {
            var responce = new ServiceResponce<UserWithRole>();

            try
            {
                responce.SetValidResponce(await _userWithRoleRepository.GetUserWithRoleByLoginAndPasswordAsync(login, password));
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(UserWithRoleService) + nameof(GetUserWithRoleByLoginAndPasswordAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }
    }
}
