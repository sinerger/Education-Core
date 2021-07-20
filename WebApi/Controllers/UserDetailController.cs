using Domain.Entities.Users;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebApi.Routes;

namespace WebApi.Controllers
{
    [Authorize]
    [Route(ApiRoutes.Api + ApiRoutes.Controller)]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        private readonly IUserDetailService _userDetailService;

        public UserDetailController(IUserDetailService userDetailService)
        {
            _userDetailService = userDetailService;
        }

        [HttpGet(ApiRoutes.UserDetail.GetUserDetailByID)]
        public async Task<IActionResult> GetUserDetailByID(Guid id)
        {
            var responce = await _userDetailService.GetUserDetailByIDAsync(id);

            return GetObjectInIActionResult(responce);
        }

        [HttpPut(ApiRoutes.UserDetail.UpdateUserDetail)]
        public async Task<IActionResult> UpdateDetailInfoForUser(UserDetail user)
        {
            var responce = await _userDetailService.UpdateDetailInfoForUserAsync(user);

            return GetIActionResult(responce);
        }

        private IActionResult GetObjectInIActionResult(IServiceResponce<UserDetail> responce)
        {
            IActionResult result = null;

            if (responce.IsSuccessfully)
            {
                result = Ok(responce.Result);
            }
            else
            {
                result = BadRequest(responce.Message);
            }

            return result;
        }

        private IActionResult GetIActionResult(IServiceResponce<UserDetail> responce)
        {
            IActionResult result = null;

            if (responce.IsSuccessfully)
            {
                result = Ok(responce.IsSuccessfully);
            }
            else
            {
                result = BadRequest(responce.Message);
            }

            return result;
        }
    }
}
