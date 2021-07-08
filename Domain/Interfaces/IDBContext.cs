using Domain.Interfaces.HomeworkRepositoryInterfaces;
using Domain.Interfaces.UserRepositoryInterfaces;
﻿using Domain.Interfaces.CourseRepositoryIntarfaces;
﻿using Domain.Interfaces.CouseRepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain.Interfaces
{
    public interface IDBContext
    {
        IUserWithRoleRepository UserWithRoleRepository { get; }
        IHomeworkRepository HomeworkRepository { get; }
        ICourseProgramRepository CourseProgramRepository { get; }
        ICourseRepository CourseRepository { get; }
        IStudentRepository StudentRepository { get; }

        IDbConnection DBConnection { get; }

    }
}
