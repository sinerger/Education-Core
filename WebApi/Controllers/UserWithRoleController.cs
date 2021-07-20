using Domain.Entities.Users;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebApi.Routes;

namespace WebApi.Controllers
{
    [Authorize(Policy = "PermissionForAdminAndTeacherRoles")]
    [Route(ApiRoutes.Api + ApiRoutes.Controller)]
    [ApiController]
    public class UserWithRoleController : ControllerBase
    {
        private readonly IUserWithRoleService _userWithRoleService;

        public UserWithRoleController(IUserWithRoleService userWithRoleService)
        {
            _userWithRoleService = userWithRoleService;
        }

        [HttpGet(ApiRoutes.UserWIthRole.GetUserWithRoleByID)]
        public async Task<IActionResult> GetUserWithRoleById(Guid id)
        {
            var responce = await _userWithRoleService.GetUserWithRoleByIDAsync(id);

            return GetIActionResult(responce);
        }

        
        [HttpGet(ApiRoutes.UserWIthRole.GetUserWithRoleByLoginAndPassword)]
        public async Task<IActionResult> GetUserWithRoleByLoginAndPassword(string login, string password)
        {
            var responce = await _userWithRoleService.GetUserWithRoleByLoginAndPasswordAsync(login, password);

            return GetIActionResult(responce);
        }

        [Authorize(Policy = "PermissionJustForAdminRole")]
        [HttpPost(ApiRoutes.UserWIthRole.CreateUserWithRole)]
        public async Task<IActionResult> CreateUserWithRole(UserWithRole user)
        {
            var responce = await _userWithRoleService.CreateUserWithRoleAsync(user);

            return GetIActionResult(responce);
        }

        [HttpDelete(ApiRoutes.UserWIthRole.DeleteUserWithRole)]
        public async Task<IActionResult> DeleteUserWithRole(Guid id)
        {
            var responce = await _userWithRoleService.DeleteUserWithRoleAsync(id);

            return GetIActionResult(responce);
        }

        [HttpPut(ApiRoutes.UserWIthRole.UpdateUserWithRole)]
        public async Task<IActionResult> UpdateUserWithRole(UserWithRole user)
        {
            var responce = await _userWithRoleService.UpdateUserWithRoleAsync(user);

            return GetIActionResult(responce);
        }

        private IActionResult GetIActionResult(IServiceResponce<UserWithRole> responce)
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

        private IActionResult GetIActionResult(IServiceResponce<bool> responce)
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
    }
}
