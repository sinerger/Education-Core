using Domain.Interfaces.CourseRepositoryIntarfaces;
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
        ICourseProgramRepository CourseProgramRepository { get; }

        IDbConnection DBConnection { get; }

    }
}
