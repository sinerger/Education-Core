using Domain.Entities.Users;

using Domain.Interfaces.UserRepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        private readonly IDBContext _DBContext;

        public UserDetailController(IDBContext dbContext)
        {
            _DBContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDetail>> GetAllUsersDetail()
        {
            return await _DBContext.UserDetailRepository.GetAllUsersDetail();
        }
        
        [HttpGet("{id}")]
        public async Task<UserDetail> GetUserDetailByID (Guid id)
        {
            return await _DBContext.UserDetailRepository.GetUserDetailByID(id);
        }

        [HttpPost]
        public async Task<bool> CreateUserDetail(UserDetail user)
        {
            return _DBContext.UserDetailRepository.CreateUserDetail(user).Result;
        }

        [HttpPut]
        public async Task<bool> UpdateUserDetail(UserDetail user)
        {
            return _DBContext.UserDetailRepository.UpdateUserDetail(user).Result;
        }
        
        [HttpDelete]
        public async Task<bool> DeleteUserDetailByID(int id)
        {
            return _DBContext.UserDetailRepository.DeleteUserDetailByID(id).Result;
        }
    }
}
