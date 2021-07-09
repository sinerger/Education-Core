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

        [HttpGet("{id}")]
        public async Task<UserDetail> GetUserDetailByID (Guid id)
        {
            return await _DBContext.UserDetailRepository.GetUserDetailByIDAsync(id);
        }

        [HttpPut]
        public async Task<bool> UpdateDetailInfoForUserAsync(UserDetail user)
        {
            return _DBContext.UserDetailRepository.UpdateDetailInfoForUserAsync(user).Result;
        }
    }
}
