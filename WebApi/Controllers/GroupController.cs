using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.Groups;
using Domain.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IDBContext _dbContext;

        public GroupController(IDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Group>> GetAllGroups()
        {
            return await _dbContext.GroupRepository.GetAllGroupsAsync();
        }

        [HttpGet("{id}")]
        public async Task<Group> GetGroupByID(Guid id)
        {
            return await _dbContext.GroupRepository.GetGroupByIDAsync(id);
        }

        [HttpPost]
        public async Task<bool> CreateGroupWithinCourse(Guid courseId, Group group)
        {
            return await _dbContext.GroupRepository.CreateGroupWithinCourseAsync(courseId, group);
        }

        [HttpPut]
        public async Task<bool> UpdateGroup(Group group)
        {
            return await _dbContext.GroupRepository.UpdateGroupAsync(group);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteGroup(Guid id)
        {
            return await _dbContext.GroupRepository.DeleteGroupAsync(id);
        }
    }
}
