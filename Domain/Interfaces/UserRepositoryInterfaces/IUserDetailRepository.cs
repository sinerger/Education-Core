using Domain.Entities.Feedbacks;
using Domain.Entities.Users;
using Insight.Database;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.UserRepositoryInterfaces
{
    public interface IUserDetailRepository : IRepository
    {
        [Recordset(1, typeof(Feedback), IsChild = true, Into = "Feedbacks")]
        Task<UserDetail> GetUserDetailByIDAsync(Guid id);
        Task UpdateDetailInfoForUserAsync(UserDetail user);
    }
}
