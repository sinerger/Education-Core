using Domain.Interfaces.CouseRepositoryInterfaces;
using Domain.Interfaces.UserRepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain.Interfaces
{
    public interface IDBContext
    {
        IUserWithRoleRepository UserWithRoleRepository { get; }
        ICourseRepository CourseRepository { get; }

        IDbConnection DBConnection { get; }

    }
}
