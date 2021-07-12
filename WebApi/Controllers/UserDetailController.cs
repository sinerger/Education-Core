using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.CoursePrograms;
using Domain.Entities.Users;
using Domain.Interfaces.UserRepositoryInterfaces;
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
        public async Task<UserDetail> GetUserDetailByID(Guid id)
        {
            return await _DBContext.UserDetailRepository.GetUserDetailByIDAsync(id);
        }

        [HttpPut]
        public async Task<bool> UpdateDetailInfoForUser(UserDetail user)
        {
            return await _DBContext.UserDetailRepository.UpdateDetailInfoForUserAsync(user);
        }
    }
}
