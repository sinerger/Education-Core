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
        public IDbConnection DBConnection { get; set; }

        public UserWithRoleRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
        }

        public async Task<bool> CreateUserWithRole(UserWithRole user)
        {
            try
            {
                var RoleID = user.Role.ID;
                await DBConnection.QueryAsync(nameof(CreateUserWithRole),
                        parameters: new
                        {
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

                return false;
                throw e;
            }
        }

        public async Task<bool> DeleteUserWithRole(Guid id)
        {
            try
            {
                await DBConnection.QueryAsync(nameof(DeleteUserWithRole), new { id });

                return true;
            }
            catch (Exception e)
            {
                // TODO: Работаем с Serilog

                return false;
                throw e;
            }
        }

        public IEnumerable<UserWithRole> GetUsersWithRole()
        {
            IUserWithRoleRepository userRepository = DBConnection.As<IUserWithRoleRepository>();

            return userRepository.GetUsersWithRole();
        }

        public UserWithRole GetUserWithRoleByID(Guid id)
        {
            IUserWithRoleRepository userRepository = DBConnection.As<IUserWithRoleRepository>();

            return userRepository.GetUserWithRoleByID(id);
        }

        public UserWithRole GetUserWithRoleByLoginAndPassword(string login, string password)
        {
            IUserWithRoleRepository userRepository = DBConnection.As<IUserWithRoleRepository>();

            return userRepository.GetUserWithRoleByLoginAndPassword(login, password);
        }

        public async Task<bool> UpdateUserWithRole(UserWithRole user)
        {
            try
            {
                var RoleID = user.Role.ID;
                await DBConnection.QueryAsync(nameof(UpdateUserWithRole),
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

                return false;
                throw e;
            }
        }
    }
}
