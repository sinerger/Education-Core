using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.UserRepositoryInterfaces
{
    public interface IStudentRepository : IRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIDAsync(Guid id);
        Task AddStudentToGroupAsync(Student student);
        Task CreateStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(Guid id);
    }
}
