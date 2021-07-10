using System.Data;
using DataAccess.InsightDatabase.Repositories;
using Domain.Interfaces;
using Domain.Interfaces.HomeworkRepositoryInterfaces;
using Domain.Interfaces.CouseRepositoryInterfaces;
using Domain.Interfaces.UserRepositoryInterfaces;
using Domain.Interfaces.LessonRepositoryInterfaces;
using Domain.Interfaces.GroupWithStudentRepositoryInterfaces;
using Domain.Interfaces.GroupRepositoryInterfaces;
using Domain.Interfaces.SolutionRepositoryInterfaces;

namespace DataAccess.InsightDatabase
{
    public class DBContext : IDBContext
    {
        public IDbConnection DBConnection { get; }
        public IUserWithRoleRepository UserWithRoleRepository => new UserWithRoleRepository(DBConnection);
        public IHomeworkRepository HomeworkRepository => new HomeworkRepository(DBConnection);
        public ICourseRepository CourseRepository => new CourseRepository(DBConnection);
        public IUserDetailRepository UserDetailRepository => new UserDetailRepository(DBConnection);
        public IGroupWithStudentRepository GroupWithStudentRepository => new GroupWithStudentRepository(DBConnection);
        public IStudentRepository StudentRepository => new StudentRepository(DBConnection);
        public ILessonRepository LessonRepository => new LessonRepository(DBConnection);
        public ITeacherRepository TeacherRepository => new TeacherRepository(DBConnection);
        public IGroupRepository GroupRepository => new GroupRepository(DBConnection);
        public ISolutionRepository SolutionRepository => new SolutionRepository(DBConnection);

        public DBContext(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
        }
    }
}
