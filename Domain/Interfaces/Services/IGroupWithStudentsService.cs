using Domain.Entities.GroupWithStudents;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IGroupWithStudentsService
    {
        Task<IServiceResponce<GroupWithStudents>> GetGroupWithStudentsByIDAsync(Guid id);
    }
}
