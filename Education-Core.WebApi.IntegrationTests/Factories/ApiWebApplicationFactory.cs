using DataAccess.InsightDatabase;
using Domain.Interfaces;
using Insight.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi;

namespace Education_Core.WebApi.IntegrationTests.Factories
{
    public class ApiWebApplicationFactory : WebApplicationFactory<Startup>
    {
        public IConfiguration Configuration { get; private set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config =>
            {
                Configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

                config.AddConfiguration(Configuration);
            });

            builder.ConfigureTestServices(services =>
            {
                var connectionString = Configuration["ConnectionStrings:TestDB"];
                var mysqlCon = new MySqlConnectionStringBuilder(connectionString);
                DbConnection connection = mysqlCon.Connection();
                services.AddTransient<IDbConnection>(conn => connection);

                services.AddTransient<IDBContext, DBContext>();
            });
        }
    }
}
