using DataAccess.InsightDatabase.Extensions;
using Education_Core.WebApi.IntegrationTests.Factories;
using Insight.Database;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Respawn;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi;
using Xunit;

namespace Education_Core.WebApi.IntegrationTests
{
    public abstract class IntegrationTestAbstract : IClassFixture<ApiWebApplicationFactory>
    {
        protected readonly string _connectionString;

        private readonly ApiWebApplicationFactory _factory;
        protected readonly HttpClient _client;

        public IntegrationTestAbstract(ApiWebApplicationFactory fixture)
        {
            _factory = fixture;
            _client = _factory.CreateClient();

            _connectionString = _factory.Configuration.GetConnectionString("TestDB");
            
        }

        protected abstract Task InitializeData();

        protected async Task TruncateAllTablesAsync()
        {
            using (DbConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.QueryAsync(nameof(TruncateAllTablesAsync).GetStoredProcedureName());
            }
        }
    }
}

