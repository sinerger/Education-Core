using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
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
        public IDbConnection DBConnection { get; }

        public UserDetailRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
        }

        public async Task<IEnumerable<UserDetail>> GetAllUsersDetailAsync()
        {
            try
            {
                IUserDetailRepository userDetailRepository = DBConnection.As<IUserDetailRepository>();

                return await userDetailRepository.GetAllUsersDetailAsync();
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<bool> CreateDetailInfoForUserAsync(UserDetail user)
        {
            try
            {
                var FeedbackID = user.Feedback.ID;
                user.ID = Guid.NewGuid();

                await DBConnection.QueryAsync(nameof(CreateDetailInfoForUserAsync).GetStoredProcedureName(),
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
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<UserDetail> GetUserDetailByIDAsync(Guid id)
        {
            try
            {
                IUserDetailRepository userDetailRepository = DBConnection.As<IUserDetailRepository>();

                return await userDetailRepository.GetUserDetailByIDAsync(id);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<bool> UpdateUserDetailAsync(UserDetail user)
        {
            try
            {
                var FeedbackID = user.Feedback.ID;

                await DBConnection.QueryAsync(nameof(UpdateUserDetailAsync).GetStoredProcedureName(),
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
                Log.Logger.Error(e.ToString());

                throw;
            }
        }

        public async Task<bool> DeleteUserDetailByIDAsync(int id)
        {
            try
            {
                await DBConnection.QueryAsync(nameof(DeleteUserDetailByIDAsync).GetStoredProcedureName(), new { id });

                return true;
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }
    }
}
