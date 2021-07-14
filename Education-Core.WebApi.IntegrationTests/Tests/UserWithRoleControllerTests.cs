using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Users;
using Education_Core.WebApi.IntegrationTests.Factories;
using Education_Core.WebApi.IntegrationTests.SourceData.TestData;
using FluentAssertions;
using Newtonsoft.Json;
using WebApi.Routes;
using Xunit;

namespace Education_Core.WebApi.IntegrationTests.Tests
{
    public class UserWithRoleControllerTests : IntegrationTestAbstract
    {
        public UserWithRoleControllerTests(ApiWebApplicationFactory fixture) : base(fixture)
        {

        }

        [Theory]
        [MemberData(nameof(UserWithRoleData.DataForCreate), MemberType = typeof(UserWithRoleData))]
        public async Task CreateUserWithRole_WhenValidTestPassed_ShouldReturnIEnumerableUsers(UserWithRole insertedUser,
            UserWithRole expected)
        {
            await TruncateAllTablesAsync();

            var postRoute = ApiRoutes.UserWIthRole.GetRouteForCreate();
            var createResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(insertedUser), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.UserWIthRole.GetRouteForGetByID(insertedUser.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<UserWithRole>(await getResponse.Content.ReadAsStringAsync());

            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(UserWithRoleData.DataForUpdate), MemberType = typeof(UserWithRoleData))]
        public async Task UpdateUserWithRole_WhenValidTestPassed_ShouldReturnUpdatetUser(UserWithRole user)
        {
            await TruncateAllTablesAsync();

            var postRoute = ApiRoutes.UserWIthRole.GetRouteForCreate();
            var createResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            user.FirstName = "Update First Name";
            user.LastName = "Update Last Name";
            var updateRoute = ApiRoutes.UserWIthRole.GetRouteForUpdate();
            var updateResponce = await _client.PutAsync(updateRoute,
                new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.UserWIthRole.GetRouteForGetByID(user.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<UserWithRole>(await getResponse.Content.ReadAsStringAsync());

            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            updateResponce.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(user);
        }

        [Theory]
        [MemberData(nameof(UserWithRoleData.DataForCreate), MemberType = typeof(UserWithRoleData))]
        public async Task GetUserWithRoleByLoginAndPassword_WhenValidTestPassed_ShouldReturnIEnumerableUsers(UserWithRole insertedUser,
            UserWithRole expected)
        {
            await TruncateAllTablesAsync();

            var postRoute = ApiRoutes.UserWIthRole.GetRouteForCreate();
            var response = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(insertedUser), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.UserWIthRole.GetRouteForGetByLoginAndPassword(insertedUser.Login, insertedUser.Password);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<UserWithRole>(await getResponse.Content.ReadAsStringAsync());

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(UserWithRoleData.DataForUpdate), MemberType = typeof(UserWithRoleData))]
        public async Task DeleteUserWithRole_WhenValidTestPassed_ShouldDelete(UserWithRole deletedUser)
        {
            await TruncateAllTablesAsync();

            var postRoute = ApiRoutes.UserWIthRole.GetRouteForCreate();
            var createResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(deletedUser), Encoding.UTF8, "application/json"));

            var deleteRoute = ApiRoutes.UserWIthRole.GetRouteForDelete(deletedUser.ID);
            var deleteResponse = await _client.DeleteAsync(deleteRoute);

            var getRoute = ApiRoutes.UserWIthRole.GetRouteForGetByID(deletedUser.ID);
            var getResponse = await _client.GetAsync(getRoute);

            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        protected async override Task InitializeData()
        {

        }
    }
}
