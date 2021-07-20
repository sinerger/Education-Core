using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Users;
using Domain.Interfaces.UserRepositoryInterfaces;
using Insight.Database;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess.InsightDatabase.Repositories
{
    public class UserWithRoleRepository : IUserWithRoleRepository
    {
        private readonly IUserWithRoleRepository _userWithRoleRepository;
        public IDbConnection DBConnection { get; }

        public UserWithRoleRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _userWithRoleRepository = DBConnection.As<IUserWithRoleRepository>();
        }

        public async Task CreateUserWithRoleAsync(UserWithRole user)
        {
            try
            {
                user.ID = user.ID == Guid.Empty ? Guid.NewGuid() : user.ID;
                var role = user.Role.ToString();

                await DBConnection.QueryAsync(nameof(CreateUserWithRoleAsync).GetStoredProcedureName(),
                        parameters: new
                        {
                            user.ID,
                            user.FirstName,
                            user.LastName,
                            user.Login,
                            user.Password, 
                            role
                        });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteUserWithRoleAsync(Guid id)
        {
            try
            {
                await _userWithRoleRepository.DeleteUserWithRoleAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<UserWithRole> GetUserWithRoleByIDAsync(Guid id)
        {
            try
            {
                return await _userWithRoleRepository.GetUserWithRoleByIDAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<UserWithRole> GetUserWithRoleByLoginAndPasswordAsync(string login, string password)
        {
            try
            { 
                var user = _userWithRoleRepository.GetUserWithRoleByLoginAndPasswordAsync(login, password);
                return await user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task UpdateUserWithRoleAsync(UserWithRole user)
        {
            try
            {
                var role = user.Role.ToString();

                await DBConnection.QueryAsync(nameof(UpdateUserWithRoleAsync).GetStoredProcedureName(),
                        parameters: new
                        {
                            user.ID,
                            user.FirstName,
                            user.LastName,
                            user.Login,
                            user.Password,
                            role
                        });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
