﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Users;

namespace Domain.Interfaces.UserRepositoryInterfaces
{
    public interface IStudentRepository : IRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIDAsync(Guid id);
        Task<bool> AddStudentToGroupAsync(Guid groupId, Student student);
        Task<bool> CreateStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(Guid id);
    }
}
