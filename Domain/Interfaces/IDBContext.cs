using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Domain.Interfaces.HomeworkRepositoryInterfaces;
using Domain.Interfaces.UserRepositoryInterfaces;
using Domain.Interfaces.LessonRepositoryInterfaces;
using Domain.Interfaces.GroupWithStudentRepositoryInterfaces;
using Domain.Interfaces.GroupRepositoryInterfaces;
using Domain.Interfaces.SolutionRepositoryInterfaces;
using Domain.Interfaces.FeedbackRepositoryInterfaces;
using Domain.Interfaces.CouseRepositoryInterfaces;

namespace Domain.Interfaces
{
    public interface IDBContext
    {
        IDbConnection DBConnection { get; }

        IUserWithRoleRepository UserWithRoleRepository { get; }
        IHomeworkRepository HomeworkRepository { get; }
        ICourseRepository CourseRepository { get; }
        IGroupWithStudentRepository GroupWithStudentRepository { get; }
        IStudentRepository StudentRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        IGroupRepository GroupRepository { get; }
        ISolutionRepository SolutionRepository { get; }
        IUserDetailRepository UserDetailRepository { get; }
        ILessonRepository LessonRepository { get; }
        IFeedbackRepository FeedbackRepository { get; }
    }
}
