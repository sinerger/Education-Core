using Autofac;
using DataAccess.InsightDatabase;
using Domain.Interfaces;
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
            builder.Register<IDbConnection>(conn => connection);
            builder.RegisterInstance(serilog).As<SerilogInitialize>();

            builder.Build();
        }
    }
}