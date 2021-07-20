using Domain.Interfaces.AttendanceRepositoryInterfaces;
using Domain.Interfaces.CouseRepositoryInterfaces;
using Domain.Interfaces.FeedbackRepositoryInterfaces;
using Domain.Interfaces.GroupRepositoryInterfaces;
using Domain.Interfaces.GroupWithStudentRepositoryInterfaces;
using Domain.Interfaces.HomeworkRepositoryInterfaces;
using Domain.Interfaces.LessonRepositoryInterfaces;
using Domain.Interfaces.SolutionRepositoryInterfaces;
using Domain.Interfaces.UserRepositoryInterfaces;
using System.Data;

namespace Domain.Interfaces
{
    public interface IDBContext
    {
        IDbConnection DBConnection { get; }

        IUserWithRoleRepository UserWithRoleRepository { get; }
        IHomeworkRepository HomeworkRepository { get; }
        ICourseRepository CourseRepository { get; }
        IGroupWithStudentsRepository GroupWithStudentsRepository { get; }
        IStudentRepository StudentRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        IGroupRepository GroupRepository { get; }
        ISolutionRepository SolutionRepository { get; }
        IUserDetailRepository UserDetailRepository { get; }
        ILessonRepository LessonRepository { get; }
        IFeedbackRepository FeedbackRepository { get; }
        IAttendanceRepository AttendanceRepository { get; }
    }
}
