using Autofac;
using DataAccess.InsightDatabase;
using DataAccess.InsightDatabase.Repositories;
using Domain.Entities.Lessons;
using Domain.Interfaces;
using Domain.Interfaces.LessonRepositoryInterfaces;
using Insight.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Domain.Interfaces.Services;
using Education_Core.BusinessLogic.Services.EntityServices;
using Serilog.Events;
using System.Data;
using System.Data.Common;
using WebApi.Controllers;
using WebApi.Serilog;
using WebApi.JWT;

namespace WebApi
{
    public class AutofacModule : Module
    {
        public IConfiguration Configuration { get; }

        public AutofacModule(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var serilog = new SerilogInitialize(LogEventLevel.Debug);

            var conStr = Configuration["ConnectionStrings:TestDB"];
            var mysqlCon = new MySqlConnectionStringBuilder(conStr);
            DbConnection connection = mysqlCon.Connection();

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
            builder.RegisterType<SessionService>().As<ISessionService>();

            builder.Register<IDbConnection>(conn => connection);
            builder.RegisterInstance(serilog).As<SerilogInitialize>();
        }
    }
}