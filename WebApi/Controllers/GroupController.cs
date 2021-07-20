using Domain.Entities.Groups;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Routes;

namespace WebApi.Controllers
{
    [Authorize(Policy = "PermissionForAdminAndTeacherRoles")]
    [Route(ApiRoutes.Api + ApiRoutes.Controller)]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet(ApiRoutes.Group.GetAllGroups)]
        public async Task<IActionResult> GetAllGroups()
        {
            var responce = await _groupService.GetAllGroupsAsync();

            return GetIActionResult(responce);
        }

        [HttpGet(ApiRoutes.Group.GetGroupByID)]
        public async Task<IActionResult> GetGroupByID(Guid id)
        {
            var responce = await _groupService.GetGroupByIDAsync(id);

            return GetIActionResult(responce);
        }

        [Authorize(Policy = "PermissionJustForAdminRole")]
        [HttpPost(ApiRoutes.Group.CreateGroupWithinCourse)]
        public async Task<IActionResult> CreateGroupWithinCourse(Group group)
        {
            var responce = await _groupService.CreateGroupWithinCourseAsync(group);

            return GetIActionResult(responce);
        }

        [HttpPut(ApiRoutes.Group.UpdateGroup)]
        public async Task<IActionResult> UpdateGroup(Group group)
        {
            var responce = await _groupService.UpdateGroupAsync(group);

            return GetIActionResult(responce);
        }

        [HttpDelete(ApiRoutes.Group.DeleteGroup)]
        public async Task<IActionResult> DeleteGroup(Guid id)
        {
            var responce = await _groupService.DeleteGroupAsync(id);

            return GetIActionResult(responce);
        }

        private IActionResult GetIActionResult(IServiceResponce<Group> responce)
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

        private IActionResult GetIActionResult(IServiceResponce<IEnumerable<Group>> responce)
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
