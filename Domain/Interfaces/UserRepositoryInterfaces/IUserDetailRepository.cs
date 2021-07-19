using System;
using System.Threading.Tasks;
using Insight.Database;
using Domain.Entities.Users;
using Domain.Entities.Feedbacks;

namespace Domain.Interfaces.UserRepositoryInterfaces
{
    public interface IUserDetailRepository : IRepository
    {
        [Recordset(1, typeof(Feedback), IsChild = true, Into = nameof(UserDetail.Feedbacks))]
        Task<UserDetail> GetUserDetailByIDAsync(Guid id);
        Task UpdateDetailInfoForUserAsync(UserDetail user);
    }
}
