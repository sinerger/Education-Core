using Domain.Entities.Users;
using Education_Core.WebApi.IntegrationTests.Factories;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;
using Education_Core.WebApi.IntegrationTests.SourceData.TestData;
using FluentAssertions;
using Insight.Database;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Data.Common;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.Routes;
using Xunit;

namespace Education_Core.WebApi.IntegrationTests.Tests
{
    public class UserDetailControllerTests : IntegrationTestAbstract
    {
        public UserDetailControllerTests(ApiWebApplicationFactory fixture) : base(fixture)
        {
        }

        [Theory]
        [MemberData(nameof(UserDetailTData.GetDataForUpdate), MemberType = typeof(UserDetailTData))]
        public async Task UpdateUserDetail_WhenValidTestPassed_ShoulUpdateUserDetailInDB(UserWithRole insertedUser,UserDetail updatedUser, UserDetail expected)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postResponse = await SendRequesToCreate(insertedUser);
            await InitializeFeedbackDataForUser(insertedUser.ID);

            var putRoute = ApiRoutes.UserDetail.GetRouteForUpdate();
            var putResponse = await _client.PutAsync(putRoute,
                new StringContent(JsonConvert.SerializeObject(updatedUser), Encoding.UTF8, "application/json"));

            var getResponse = await SendRequesToGetByID(updatedUser);
            var actual = JsonConvert.DeserializeObject<UserDetail>(await getResponse.Content.ReadAsStringAsync());

            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            putResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        protected async override Task InitializeData()
        {
            using (DbConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                await conn.QueryAsync("CreateTeacher", UserInitData.Teacher);
            }
        }

        protected override async Task<HttpResponseMessage> SendRequesToCreate(object obj)
        {
            var userDetail = (UserWithRole)obj;
            var postRoute = ApiRoutes.UserWIthRole.GetRouteForCreate();
            var postResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(userDetail), Encoding.UTF8, "application/json"));

            return postResponse;
        }

        protected override Task<HttpResponseMessage> SendRequesToGetAll()
        {
            throw new NotImplementedException();
        }

        protected override async Task<HttpResponseMessage> SendRequesToGetByID(object obj)
        {
            var userDetail = (UserDetail)obj;
            var getRoute = ApiRoutes.UserDetail.GetRouteForGetByID(userDetail.ID);
            var getResponse = await _client.GetAsync(getRoute);

            return getResponse;
        }

        private async Task InitializeFeedbackDataForUser(Guid userID)
        {
            using (DbConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                foreach (var feedback in FeedbackInitData.Feedbacks)
                {
                    var authorID = UserInitData.Teacher.ID;
                    await conn.QueryAsync("CreateFeedbackForUser",
                        new
                        {
                            feedback.ID,
                            feedback.Date,
                            feedback.Description,
                            userID,
                            authorID
                        });
                }
            }
        }
    }
}
