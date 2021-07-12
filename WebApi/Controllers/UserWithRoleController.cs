using Domain.Entities.Users;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        [HttpGet("{id}")]
        public async Task<UserWithRole> GetUserWithRoleById(Guid id)
        {
            return await _dbContext.UserWithRoleRepository.GetUserWithRoleByIDAsync(id);
        }

        [HttpGet("{login}")]
        public async Task<UserWithRole> GetUserWithRoleByLoginAndPassword(string login, string password)
        {
            return await _dbContext.UserWithRoleRepository.GetUserWithRoleByLoginAndPasswordAsync(login, password);
        }

        [HttpDelete("{id}")]
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
