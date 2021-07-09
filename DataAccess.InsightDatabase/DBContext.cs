using DataAccess.InsightDatabase.Repositories;
using Domain.Interfaces;
using Domain.Interfaces.HomeworkRepositoryInterfaces;
using Domain.Interfaces.CourseRepositoryIntarfaces;
using Domain.Interfaces.CouseRepositoryInterfaces;
using Domain.Interfaces.UserRepositoryInterfaces;
using System.Data;
using Domain.Interfaces.LessonRepositoryInterfaces;
using Domain.Interfaces.GroupWithStudentRepositoryInterfaces;

namespace DataAccess.InsightDatabase
{
    public class DBContext : IDBContext
    {
        public IDbConnection DBConnection { get; }
        public IUserWithRoleRepository UserWithRoleRepository => new UserWithRoleRepository(DBConnection);
        public IHomeworkRepository HomeworkRepository => new HomeworkRepository(DBConnection);
        public ICourseProgramRepository CourseProgramRepository => new CourseProgramRepository(DBConnection);
        public ICourseRepository CourseRepository => new CourseRepository(DBConnection);
        public IUserDetailRepository UserDetailRepository => new UserDetailRepository(DBConnection);
        public IGroupWithStudentRepository GroupWithStudentRepository => new GroupWithStudentRepository(DBConnection);
        public ILessonRepository LessonRepository => new LessonRepository(DBConnection);

        public DBContext(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
        }
    }
}
