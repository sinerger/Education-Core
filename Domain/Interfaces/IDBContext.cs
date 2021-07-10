using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Domain.Interfaces.HomeworkRepositoryInterfaces;
using Domain.Interfaces.UserRepositoryInterfaces;
﻿using Domain.Interfaces.CourseRepositoryIntarfaces;
﻿using Domain.Interfaces.CouseRepositoryInterfaces;
using Domain.Interfaces.LessonRepositoryInterfaces;
using Domain.Interfaces.GroupWithStudentRepositoryInterfaces;
using Domain.Interfaces.GroupRepositoryInterfaces;
using Domain.Interfaces.SolutionRepositoryInterfaces;

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
        IGroupWithStudentRepository GroupWithStudentRepository { get; }
        IStudentRepository StudentRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        IGroupRepository GroupRepository { get; }
        ISolutionRepository SolutionRepository { get; }

        IDbConnection DBConnection { get; }
    }
}
