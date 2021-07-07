using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Users;
using Domain.Interfaces.UserRepositoryInterfaces;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.InsightDatabase.Repositories
{
    public class UserWithRoleRepository : IUserWithRoleRepository
    {
        public IDbConnection DBConnection { get; }

        public UserWithRoleRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
        }

        public async Task<bool> CreateUserWithRoleAsync(UserWithRole user)
        {
            try
            {
                var RoleID = user.Role.ID;
                user.ID = Guid.NewGuid();

                await DBConnection.QueryAsync(nameof(CreateUserWithRoleAsync).GetStoredProcedureName(),
                        parameters: new
                        {
                            user.ID,
                            user.FirstName,
                            user.LastName,
                            user.Login,
                            user.Password,
                            RoleID
                        });

                return true;
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog

                throw e;
            }
        }

        public async Task<bool> DeleteUserWithRoleAsync(Guid id)
        {
            try
            {
                IUserWithRoleRepository userRepository = DBConnection.As<IUserWithRoleRepository>();
                
                return await userRepository.DeleteUserWithRoleAsync(id);
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog

                throw e;
            }
        }

        public async Task<IEnumerable<UserWithRole>> GetUsersWithRoleAsync()
        {
            try
            {
                IUserWithRoleRepository userRepository = DBConnection.As<IUserWithRoleRepository>();

                return await userRepository.GetUsersWithRoleAsync();
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog

                throw e;
            }
        }

        public async Task<UserWithRole> GetUserWithRoleByIDAsync(Guid id)
        {
            try
            {
                IUserWithRoleRepository userRepository = DBConnection.As<IUserWithRoleRepository>();

                return await userRepository.GetUserWithRoleByIDAsync(id);
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog

                throw e;
            }
        }

        public async Task<UserWithRole> GetUserWithRoleByLoginAndPasswordAsync(string login, string password)
        {
            try
            {
                IUserWithRoleRepository userRepository = DBConnection.As<IUserWithRoleRepository>();

                return await userRepository.GetUserWithRoleByLoginAndPasswordAsync(login, password);
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog

                throw e;
            }
        }

        public async Task<bool> UpdateUserWithRoleAsync(UserWithRole user)
        {
            try
            {
                var RoleID = user.Role.ID;

                await DBConnection.QueryAsync(nameof(UpdateUserWithRoleAsync).GetStoredProcedureName(),
                        parameters: new
                        {
                            user.ID,
                            user.FirstName,
                            user.LastName,
                            user.Login,
                            user.Password,
                            RoleID
                        });

                return true;
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog

                throw e;
            }
        }
    }
}
