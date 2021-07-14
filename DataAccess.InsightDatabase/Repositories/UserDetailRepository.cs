using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Users;
using Domain.Interfaces.UserRepositoryInterfaces;
using Insight.Database;
using Serilog;

namespace DataAccess.InsightDatabase.Repositories
{
    public class UserDetailRepository : IUserDetailRepository
    {
        private readonly IUserDetailRepository _userDetailRepository;
        public IDbConnection DBConnection { get; }

        public UserDetailRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _userDetailRepository = DBConnection.As<IUserDetailRepository>();
        }

        public async Task<UserDetail> GetUserDetailByIDAsync(Guid id)
        {
            return await _userDetailRepository.GetUserDetailByIDAsync(id);
        }

        public async Task UpdateDetailInfoForUserAsync(UserDetail user)
        {
            try
            {
                await DBConnection.QueryAsync(nameof(UpdateDetailInfoForUserAsync).GetStoredProcedureName(),
                    parameters: new
                    {
                        user.ID,
                        user.Email,
                        user.Phone,
                        user.City,
                        user.DateOfBirth
                    });
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw;
            }
        }
    }
}
