using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Courses;
using Domain.Entities.Groups;
using Insight.Database;

namespace Domain.Interfaces.GroupRepositoryInterfaces
{
    public interface IGroupRepository : IRepository
    {
        [Recordset(typeof(Group), typeof(Course))]
        Task<IEnumerable<Group>> GetAllGroupsAsync();
        [Recordset(1, typeof(Course), IsChild = true)]
        Task<Group> GetGroupByIDAsync(Guid id);
        Task<bool> CreateGroupWithinCourseAsync(Group group);
        Task<bool> UpdateGroupAsync(Group group);
        Task DeleteGroupAsync(Guid id);
    }
}
