using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Groups;

namespace Domain.Interfaces.GroupRepositoryInterfaces
{
    public interface IGroupRepository : IRepository
    {
        Task<IEnumerable<Group>> GetAllGroupsAsync();
        Task<Group> GetGroupByIDAsync(Guid id);
        Task<bool> CreateGroupWithinCourseAsync(Guid courseId, Group group);
        Task<bool> UpdateGroupAsync(Group group);
        Task<bool> DeleteGroupAsync(Guid id);
    }
}
