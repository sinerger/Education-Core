using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.Users;
using Domain.Interfaces.UserRepositoryInterfaces;
using Domain.Interfaces;
using WebApi.Routes;

namespace WebApi.Controllers
{
    [Route(ApiRoutes.Api+ApiRoutes.Controller)]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        private readonly IDBContext _DBContext;

        public UserDetailController(IDBContext dbContext)
        {
            _DBContext = dbContext;
        }

        [HttpGet(ApiRoutes.UserDetail.GetUserDetailByID)]
        public async Task<UserDetail> GetUserDetailByID(Guid id)
        {
            return await _DBContext.UserDetailRepository.GetUserDetailByIDAsync(id);
        }

        [HttpPut(ApiRoutes.UserDetail.UpdateUserDetail)]
        public async Task UpdateDetailInfoForUser(UserDetail user)
        {
            await _DBContext.UserDetailRepository.UpdateDetailInfoForUserAsync(user);
        }
    }
}
