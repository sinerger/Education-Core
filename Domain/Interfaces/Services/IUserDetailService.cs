using Domain.Entities.Users;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IUserDetailService 
    {
        Task<IServiceResponce<UserDetail>> GetUserDetailByIDAsync(Guid id);
        Task<IServiceResponce<UserDetail>> UpdateDetailInfoForUserAsync(UserDetail user);
    }
}
