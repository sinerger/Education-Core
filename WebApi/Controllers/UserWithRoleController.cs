using Domain.Entities.Users;
using Domain.Interfaces.UserRepositoryInterfaces;
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
        private readonly IUserWithRoleUnitOfWork _userWithRoleUnitOfWork;

        public UserWithRoleController(IUserWithRoleUnitOfWork userWithRoleUnitOfWork)
        {
            _userWithRoleUnitOfWork = userWithRoleUnitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<UserWithRole>> GetUsersWithRole()
        {
            return _userWithRoleUnitOfWork.UserWithRoleRepository.GetUsersWithRole();
        }

        [HttpGet("id")]
        public async Task<UserWithRole> GetUserWithRoleById(Guid id)
        {
            return _userWithRoleUnitOfWork.UserWithRoleRepository.GetUserWithRoleByID(id);
        }

        [HttpGet("login")]
        public async Task<UserWithRole> GetUserWithRoleByLoginAndPassword(string login,string password)
        {
            return _userWithRoleUnitOfWork.UserWithRoleRepository.GetUserWithRoleByLoginAndPassword(login, password);
        }

        [HttpPost]
        public async Task<bool> CreateUserWithRole(UserWithRole user)
        {
            return _userWithRoleUnitOfWork.UserWithRoleRepository.CreateUserWithRole(user).Result;
        }

        [HttpDelete("id")]
        public async Task<bool> DeleteUserWithRole(Guid id)
        {
            return _userWithRoleUnitOfWork.UserWithRoleRepository.DeleteUserWithRole(id).Result;
        }

        [HttpPut]
        public async Task<bool> UpdateUserWithRole(UserWithRole user)
        {
            return _userWithRoleUnitOfWork.UserWithRoleRepository.UpdateUserWithRole(user).Result;
        }
    }
}
