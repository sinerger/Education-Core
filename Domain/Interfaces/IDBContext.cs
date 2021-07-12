using Domain.Interfaces.HomeworkRepositoryInterfaces;
using Domain.Interfaces.UserRepositoryInterfaces;
﻿using Domain.Interfaces.CourseRepositoryIntarfaces;
using Domain.Interfaces.UserRepositoryInterfaces;
﻿using Domain.Interfaces.CouseRepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Domain.Interfaces.LessonRepositoryInterfaces;

namespace Domain.Interfaces
{
    public interface IDBContext
    {
        IUserWithRoleRepository UserWithRoleRepository { get; }
        IHomeworkRepository HomeworkRepository { get; }
        ICourseProgramRepository CourseProgramRepository { get; }
        ICourseRepository CourseRepository { get; }
        ILessonRepository LessonRepository { get; }
        IUserDetailRepository UserDetailRepository { get; }

        IDbConnection DBConnection { get; }

    }
}
