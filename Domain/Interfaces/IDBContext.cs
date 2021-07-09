using Domain.Interfaces.HomeworkRepositoryInterfaces;
using Domain.Interfaces.UserRepositoryInterfaces;
using Domain.Interfaces.CourseRepositoryIntarfaces;
using Domain.Interfaces.CouseRepositoryInterfaces;
using System.Data;
using Domain.Interfaces.LessonRepositoryInterfaces;
using Domain.Interfaces.FeedbackRepositoryInterfaces;

namespace Domain.Interfaces
{
    public interface IDBContext
    {
        IDbConnection DBConnection { get; }

        IUserWithRoleRepository UserWithRoleRepository { get; }
        IHomeworkRepository HomeworkRepository { get; }
        ICourseProgramRepository CourseProgramRepository { get; }
        ICourseRepository CourseRepository { get; }
        ILessonRepository LessonRepository { get; }
        IUserDetailRepository UserDetailRepository { get; }
        IFeedbackRepository FeedbackRepository { get; }
    }
}
