using Domain.Entities.Users;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWithRoleController : ControllerBase
    {
        private readonly IDBContext _dbContext;

        public UserWithRoleController(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<UserWithRole>> GetUsersWithRole()
        {
            return await _dbContext.UserWithRoleRepository.GetUsersWithRoleAsync();
        }

        [HttpGet("id")]
        public async Task<UserWithRole> GetUserWithRoleById(Guid id)
        {
            return await _dbContext.UserWithRoleRepository.GetUserWithRoleByIDAsync(id);
        }

        [HttpGet("login")]
        public async Task<UserWithRole> GetUserWithRoleByLoginAndPassword(string login, string password)
        {
            return await _dbContext.UserWithRoleRepository.GetUserWithRoleByLoginAndPasswordAsync(login, password);
        }

        [HttpPost]
        public async Task<bool> CreateUserWithRole(UserWithRole user)
        {
            return await _dbContext.UserWithRoleRepository.CreateUserWithRoleAsync(user);
        }

        [HttpDelete("id")]
        public async Task<bool> DeleteUserWithRole(Guid id)
        {
            return await _dbContext.UserWithRoleRepository.DeleteUserWithRoleAsync(id);
        }

        [HttpPut]
        public async Task<bool> UpdateUserWithRole(UserWithRole user)
        {
            return await _dbContext.UserWithRoleRepository.UpdateUserWithRoleAsync(user);
        }
    }
}
