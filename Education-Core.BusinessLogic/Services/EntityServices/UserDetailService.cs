using Domain.Entities.Users;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Interfaces.UserRepositoryInterfaces;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Education_Core.BusinessLogic.Services.EntityServices
{
    public class UserDetailService : IUserDetailService
    {
        public IUserDetailRepository _userDetailRepository;
        public IDBContext DBContext { get; }

        public UserDetailService(IDBContext dbContext)
        {
            _userDetailRepository = dbContext.UserDetailRepository;
        }

        public async Task<IServiceResponce<UserDetail>> GetUserDetailByIDAsync(Guid id)
        {
            var responce = new ServiceResponce<UserDetail>();

            try
            {
                responce.SetValidResponce(await _userDetailRepository.GetUserDetailByIDAsync(id));
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(UserDetailService) + nameof(GetUserDetailByIDAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<UserDetail>> UpdateDetailInfoForUserAsync(UserDetail user)
        {
            var responce = new ServiceResponce<UserDetail>();

            try
            {
                await _userDetailRepository.UpdateDetailInfoForUserAsync(user);
                responce.SetValidResponce(user);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(UserDetailService) + nameof(UpdateDetailInfoForUserAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }
    }
}
