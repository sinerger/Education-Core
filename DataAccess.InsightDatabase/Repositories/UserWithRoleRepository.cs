using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Insight.Database;
using DataAccess.InsightDatabase.Extensions;
using Domain.Interfaces.UserRepositoryInterfaces;
using Domain.Entities.Users;

namespace DataAccess.InsightDatabase.Repositories
{
    public class UserWithRoleRepository : IUserWithRoleRepository
    {
        public IDbConnection DBConnection { get; }

        public UserWithRoleRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
        }

        public async Task CreateUserWithRoleAsync(UserWithRole user)
        {
            try
            {
                var TypeRole = user.Role.ToString();
                user.ID = user.ID == Guid.Empty ? Guid.NewGuid() : user.ID;

                await DBConnection.QueryAsync(nameof(CreateUserWithRoleAsync).GetStoredProcedureName(),
                        parameters: new
                        {
                            user.ID,
                            user.FirstName,
                            user.LastName,
                            user.Login,
                            user.Password,
                            TypeRole
                        });
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog

                throw e;
            }
        }

        public async Task DeleteUserWithRoleAsync(Guid id)
        {
            try
            {
                IUserWithRoleRepository userRepository = DBConnection.As<IUserWithRoleRepository>();

                await userRepository.DeleteUserWithRoleAsync(id);
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

        public async Task UpdateUserWithRoleAsync(UserWithRole user)
        {
            try
            {
                var TypeRole = user.Role.ToString();
                await DBConnection.QueryAsync(nameof(UpdateUserWithRoleAsync).GetStoredProcedureName(),
                        parameters: new
                        {
                            user.ID,
                            user.FirstName,
                            user.LastName,
                            user.Login,
                            user.Password,
                            TypeRole
                        });
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog

                throw e;
            }
        }
    }
}
