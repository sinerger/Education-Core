using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Groups;

namespace Domain.Interfaces.GroupRepositoryInterfaces
{
    public interface IGroupRepository : IRepository
    {
        Task<IEnumerable<Group>> GetAllGroupsAsync();
        Task<Group> GetGroupByIDAsync(Guid id);
        Task<bool> CreateGroupAsync(Group group);
        Task<bool> UpdateGroupAsync(Group group);
        Task<bool> DeleteGroupByIDAsync(Guid id);
    }
}
