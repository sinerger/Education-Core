using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.Groups;
using Domain.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IDBContext _dBContext;

        public GroupController(IDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Group>> GetAllGroups()
        {
            return await _dBContext.GroupRepository.GetAllGroupsAsync();
        }

        [HttpGet]
        public async Task<Group> GetGroupByID(Guid id)
        {
            return await _dBContext.GroupRepository.GetGroupByIDAsync(id);
        }

        [HttpPost]
        public async Task<bool> CreateGroup(Group group)
        {
            return await _dBContext.GroupRepository.CreateGroupAsync(group);
        }

        [HttpPut]
        public async Task<bool> UpdateGroup(Group group)
        {
            return await _dBContext.GroupRepository.UpdateGroupAsync(group);
        }

        [HttpDelete]
        public async Task<bool> DeleteGroupByID(Guid id)
        {
            return await _dBContext.GroupRepository.DeleteGroupByIDAsync(id);
        }
    }
}
