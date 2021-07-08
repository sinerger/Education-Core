using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Domain.Interfaces.HomeworkRepositoryInterfaces;
using Domain.Interfaces.UserRepositoryInterfaces;
﻿using Domain.Interfaces.CourseRepositoryIntarfaces;
﻿using Domain.Interfaces.CouseRepositoryInterfaces;
using Domain.Interfaces.LessonRepositoryInterfaces;
using Domain.Interfaces.GroupRepositoryInterfaces;

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
        IStudentRepository StudentRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        IGroupRepository GroupRepository { get; }

        IDbConnection DBConnection { get; }
    }
}
