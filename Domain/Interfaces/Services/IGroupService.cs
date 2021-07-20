using Domain.Entities.Groups;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IGroupService
    {
        Task<IServiceResponce<IEnumerable<Group>>> GetAllGroupsAsync();
        Task<IServiceResponce<Group>> GetGroupByIDAsync(Guid id);
        Task<IServiceResponce<bool>> CreateGroupWithinCourseAsync(Group group);
        Task<IServiceResponce<bool>> UpdateGroupAsync(Group group);
        Task<IServiceResponce<bool>> DeleteGroupAsync(Guid id);
    }
}
