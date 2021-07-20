using System.Data;
using Autofac;
using Domain.Interfaces;
using Insight.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using Serilog.Events;
using System.Data.Common;
using System.Text;
using DataAccess.InsightDatabase;
using Domain.Entities.Roles;
using WebApi.Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using WebApi.JWT;

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
            services.AddControllers();
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("PermissionJustForAdminRole",
                    policy => policy.RequireRole(TypeRole.Admin.ToString()));
                options.AddPolicy("PermissionForAdminAndTeacherRoles",
                    policy => policy.RequireRole(TypeRole.Teacher.ToString(), TypeRole.Admin.ToString()));

            });

           var serilog = new SerilogInitialize(LogEventLevel.Debug);
            

            var conStr = Configuration["ConnectionStrings:TestDB"];
            var mysqlCon = new MySqlConnectionStringBuilder(conStr);
            DbConnection connection = mysqlCon.Connection();

            services.AddTransient<IDbConnection>(conn => connection);
            services.AddTransient<IDBContext, DBContext>();
            services.AddTransient<ISessionService, SessionService>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}