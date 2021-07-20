using DataAccess.InsightDatabase.Extensions;
using Education_Core.WebApi.IntegrationTests.Factories;
using Insight.Database;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Education_Core.WebApi.IntegrationTests
{
    public abstract class IntegrationTestAbstract : IClassFixture<ApiWebApplicationFactory>
    {
        protected readonly string _connectionString;
        protected readonly HttpClient _client;
        private readonly ApiWebApplicationFactory _factory;

        public IntegrationTestAbstract(ApiWebApplicationFactory fixture)
        {
            _factory = fixture;
            _client = _factory.CreateClient();

            _connectionString = _factory.Configuration.GetConnectionString("TestDB");
        }

        protected virtual Task InitializeData()
        {
            return null;
        }

        protected virtual Task<HttpResponseMessage> SendRequesToCreate(object obj)
        {
            return null;
        }

        protected virtual Task<HttpResponseMessage> SendRequesToGetByID(object obj)
        {
            return null;
        }

        protected virtual Task<HttpResponseMessage> SendRequesToGetAll()
        {
            return null;
        }

        protected async Task TruncateAllTablesAsync()
        {
            using (DbConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.QueryAsync(nameof(TruncateAllTablesAsync).GetStoredProcedureName());
            }
        }
    }
}