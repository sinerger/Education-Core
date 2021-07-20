using Domain.Entities.Feedbacks;
using Domain.Entities.Users;
using Education_Core.WebApi.IntegrationTests.Factories;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;
using Education_Core.WebApi.IntegrationTests.SourceData.TestData;
using FluentAssertions;
using Insight.Database;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Common;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.Routes;
using Xunit;

namespace Education_Core.WebApi.IntegrationTests.Tests
{
    public class FeedbackControllerTests : IntegrationTestAbstract
    {
        public FeedbackControllerTests(ApiWebApplicationFactory fixture) : base(fixture)
        {

        }

        [Theory]
        [MemberData(nameof(FeedbackTData.DataForCreate), MemberType = typeof(FeedbackTData))]
        public async Task CreateFeedbackForUser_WhenValidTestPassed_ShouldReturnIEnumerableFeedbacksWithUser(List<Feedback> insertedFeedbacks,
            UserWithRole userWithRole, List<Feedback> expected)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Feedback.GetRouteForCreateForUser(userWithRole.ID, userWithRole.ID);
            foreach (var feedback in insertedFeedbacks)
            {
                var createResponse = await _client.PostAsync(postRoute,
                    new StringContent(JsonConvert.SerializeObject(feedback), Encoding.UTF8, "application/json"));
                createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            }

            var getRoute = ApiRoutes.Feedback.GetRouteForGetAllByUserID(userWithRole.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<IEnumerable<Feedback>>(await getResponse.Content.ReadAsStringAsync());

            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(FeedbackTData.DataForUpdate), MemberType = typeof(FeedbackTData))]
        public async Task UpdateFeedback_WhenValidTestPassed_ShoulUpdateFeedbackWithUserInDB(Feedback updatedFeedback,
            UserWithRole userWithRole, Feedback expected)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Feedback.GetRouteForCreateForUser(userWithRole.ID, userWithRole.ID);
            var createResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(updatedFeedback), Encoding.UTF8, "application/json"));

            var putRoute = ApiRoutes.Feedback.GetRouteForUpdate();
            var putResponse = await _client.PutAsync(putRoute,
                new StringContent(JsonConvert.SerializeObject(updatedFeedback), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.Feedback.GetRouteForGetAllByUserID(userWithRole.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<IEnumerable<Feedback>>(await getResponse.Content.ReadAsStringAsync());

            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            putResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(FeedbackTData.DataForDelete), MemberType = typeof(FeedbackTData))]
        public async Task GetAuthorByFeedbackID_WhenValidTestPassed_ShouldUserWithRole(Feedback feedback, UserWithRole userWithRole)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Feedback.GetRouteForCreateForUser(userWithRole.ID, userWithRole.ID);
            var createResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(feedback), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.Feedback.GetRouteForGetAuthorByFeedbackID(feedback.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<UserWithRole>(await getResponse.Content.ReadAsStringAsync());

            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(userWithRole);
        }

        [Theory]
        [MemberData(nameof(FeedbackTData.DataForDelete), MemberType = typeof(FeedbackTData))]
        public async Task DeleteFeedback_WhenValidTestPassed_ShouldDelete(Feedback deletedFeedback, UserWithRole userWithRole)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Feedback.GetRouteForCreateForUser(userWithRole.ID, userWithRole.ID);
            var createResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(deletedFeedback), Encoding.UTF8, "application/json"));

            var deleteRoute = ApiRoutes.Feedback.GetRouteForDelete(deletedFeedback.ID);
            var deleteResponse = await _client.DeleteAsync(deleteRoute);

            var getRoute = ApiRoutes.Feedback.GetRouteForGetAllByUserID(userWithRole.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<IEnumerable<Feedback>>(await getResponse.Content.ReadAsStringAsync());
            actual.Should().HaveCount(0);

            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        protected async override Task InitializeData()
        {
            using (DbConnection connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                await connection.QueryAsync("CreateUserWithRole", UserInitData.UserWithRole);
            }
        }
    }
}
