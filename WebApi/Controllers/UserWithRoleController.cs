using Domain.Entities.Users;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApi.Routes;

namespace WebApi.Controllers
{
    [Route(ApiRoutes.Api + ApiRoutes.Controller)]
    [ApiController]
    public class UserWithRoleController : ControllerBase
    {
        private readonly IDBContext _dbContext;

        public UserWithRoleController(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet(ApiRoutes.UserWIthRole.GetUserWithRoleByID)]
        public async Task<UserWithRole> GetUserWithRoleById(Guid id)
        {
            try
            {
            return await _dbContext.UserWithRoleRepository.GetUserWithRoleByIDAsync(id);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet(ApiRoutes.UserWIthRole.GetUserWithRoleByLoginAndPassword)]
        public async Task<UserWithRole> GetUserWithRoleByLoginAndPassword(string login, string password)
        {
            try
            {
                return await _dbContext.UserWithRoleRepository.GetUserWithRoleByLoginAndPasswordAsync(login, password);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost(ApiRoutes.UserWIthRole.CreateUserWithRole)]
        public async Task<Guid> CreateUserWithRole(UserWithRole user)
        {
            try
            {
                await _dbContext.UserWithRoleRepository.CreateUserWithRoleAsync(user);

                return user.ID;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpDelete(ApiRoutes.UserWIthRole.DeleteUserWithRoleByID)]
        public async Task<bool> DeleteUserWithRole(Guid id)
        {
            try
            {
                await _dbContext.UserWithRoleRepository.DeleteUserWithRoleAsync(id);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        [HttpPut(ApiRoutes.UserWIthRole.UpdateUserWithRole)]
        public async Task<bool> UpdateUserWithRole(UserWithRole user)
        {
            try
            {
                await _dbContext.UserWithRoleRepository.UpdateUserWithRoleAsync(user);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
