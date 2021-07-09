using Domain.Interfaces.HomeworkRepositoryInterfaces;
using Domain.Interfaces.UserRepositoryInterfaces;
﻿using Domain.Interfaces.CourseRepositoryIntarfaces;
using Domain.Interfaces.UserRepositoryInterfaces;
using Domain.Interfaces.UserRepositoryInterfaces;
﻿using Domain.Interfaces.CouseRepositoryInterfaces;
using System.Data;
using Domain.Interfaces.LessonRepositoryInterfaces;
using Domain.Interfaces.GroupWithStudentRepositoryInterfaces;

namespace Domain.Interfaces
{
    public interface IDBContext
    {
        IUserWithRoleRepository UserWithRoleRepository { get; }
        IHomeworkRepository HomeworkRepository { get; }
        ICourseRepository CourseRepository { get; }
        IGroupWithStudentRepository GroupWithStudentRepository { get; }

        IUserDetailRepository UserDetailRepository { get; }

        IDbConnection DBConnection { get; }

    }
}
