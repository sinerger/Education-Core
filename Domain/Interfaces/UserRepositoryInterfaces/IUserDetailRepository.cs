using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Insight.Database;
using Domain.Entities.Users;
using Domain.Entities;

namespace Domain.Interfaces.UserRepositoryInterfaces
{
    public interface IUserDetailRepository : IRepository
    {
        [Recordset(typeof(UserDetail), typeof(Feedback))]
        Task<UserDetail> GetUserDetailByIDAsync(Guid id);
        Task<bool> UpdateDetailInfoForUserAsync(UserDetail user);
    }
}
