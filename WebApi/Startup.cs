using DataAccess.InsightDatabase;
using Domain.Interfaces;
using Insight.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Serilog;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var serilog = new SerilogInitialize(LogEventLevel.Debug);
            services.AddControllers();

            var conStr = Configuration["ConnectionStrings:TestDB"];
            var mysqlCon = new MySqlConnectionStringBuilder(conStr);
            DbConnection connection = mysqlCon.Connection();

            services.AddTransient<IDbConnection>(conn => connection);
            services.AddTransient<IDBContext, DBContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
