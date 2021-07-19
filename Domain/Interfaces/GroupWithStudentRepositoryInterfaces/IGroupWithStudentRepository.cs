using Domain.Entities.GroupWithStudents;
using Domain.Entities.Users;
using Insight.Database;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.GroupWithStudentRepositoryInterfaces
{
    public interface IGroupWithStudentRepository : IRepository
    {
        [Recordset(1, typeof(Student), IsChild = true, Into = nameof(GroupWithStudent.Students))]
        Task<GroupWithStudent> GetGroupWithStudentByIDAsync(Guid id);
    }
}
