using Autofac;
using DataAccess.InsightDatabase;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Education_Core.BusinessLogic.Services.EntityServices;
using Serilog.Events;
using System.Data;
using System.Data.Common;
using WebApi.Serilog;

namespace WebApi
{
    public class AutofacConfig
    {
        public static void ConfigureContainer(DbConnection connection)
        {
            var builder = new ContainerBuilder();
            var serilog = new SerilogInitialize(LogEventLevel.Debug);

            builder.RegisterType<DBContext>().As<IDBContext>();
            builder.RegisterType<UserWithRoleService>().As<IUserWithRoleService>();
            builder.RegisterType<UserDetailService>().As<IUserDetailService>();
            builder.RegisterType<LessonService>().As<ILessonService>();
            builder.RegisterType<HomeworkService>().As<IHomeworkService>();
            builder.RegisterType<GroupService>().As<IGroupService>();
            builder.RegisterType<SolutionService>().As<ISolutionService>();
            builder.RegisterType<CourseService>().As<ICourseService>();
            builder.RegisterType<GroupWithStudentsService>().As<IGroupWithStudentsService>();
            builder.RegisterType<TeacherService>().As<ITeacherService>();
            builder.RegisterType<FeedbackServise>().As<IFeedbackServise>();

            builder.Register<IDbConnection>(conn => connection);
            builder.RegisterInstance(serilog).As<SerilogInitialize>();

            builder.Build();
        }
    }
}