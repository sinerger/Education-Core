using Domain.Entities.Courses;
using Domain.Entities.GroupWithStudents;
using Domain.Entities.Users;
using Insight.Database;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.GroupWithStudentRepositoryInterfaces
{
    public interface IGroupWithStudentsRepository : IRepository
    {
        [Recordset(1, typeof(Course), IsChild = true)]
        [Recordset(2, typeof(Student), IsChild = true, Into = nameof(GroupWithStudents.Students))]
        Task<GroupWithStudents> GetGroupWithStudentsByIDAsync(Guid id);
    }
}
