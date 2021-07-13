using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.Groups;
using Domain.Interfaces;
using WebApi.Routes;

namespace WebApi.Controllers
{
    [Route(ApiRoutes.Api + ApiRoutes.Controller)]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IDBContext _dbContext;

        public GroupController(IDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet(ApiRoutes.Group.GetAllGroups)]
        public async Task<IEnumerable<Group>> GetAllGroups()
        {
            return await _dbContext.GroupRepository.GetAllGroupsAsync();
        }

        [HttpGet("{id}")]
        public async Task<Group> GetGroupByID(Guid id)
        {
            return await _dbContext.GroupRepository.GetGroupByIDAsync(id);
        }

        [HttpPost(ApiRoutes.Group.CreateGroupWithinCourse)]
        public async Task<bool> CreateGroupWithinCourse(Guid courseId, Group group)
        {
            return await _dbContext.GroupRepository.CreateGroupWithinCourseAsync( group);
        }

        [HttpPut]
        public async Task<bool> UpdateGroup(Group group)
        {
            return await _dbContext.GroupRepository.UpdateGroupAsync(group);
        }

        [HttpDelete("{id}")]
        public async Task DeleteGroup(Guid id)
        {
            await _dbContext.GroupRepository.DeleteGroupAsync(id);
        }
    }
}
