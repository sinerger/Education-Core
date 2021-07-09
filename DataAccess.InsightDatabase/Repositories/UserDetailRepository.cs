using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Users;
using Domain.Interfaces.UserRepositoryInterfaces;
using Insight.Database;

namespace DataAccess.InsightDatabase.Repositories
{
    public class UserDetailRepository : IUserDetailRepository
    {
        public IDbConnection DBConnection { get; }
        private IUserDetailRepository _userDetailRepository;

        public UserDetailRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _userDetailRepository = DBConnection.As<IUserDetailRepository>();
        }

        public async Task<UserDetail> GetUserDetailByIDAsync(Guid id)
        {
            try
            {
                return await _userDetailRepository.GetUserDetailByIDAsync(id);
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog
                throw e;
            }
        }

        public async Task<bool> UpdateDetailInfoForUserAsync(UserDetail user)
        {
            try
            {
                var FeedbackID = user.Feedback.ID;

                await DBConnection.QueryAsync(nameof(UpdateDetailInfoForUserAsync).GetStoredProcedureName(),
                    parameters: new
                    {
                        user.ID,
                        user.FirstName,
                        user.LastName,
                        user.Email,
                        user.City,
                        user.Phone,
                        user.DateOfBirth,
                        FeedbackID
                    });

                return true;
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog
                throw;
            }
        }
    }
}
