using Domain.Entities.Users;
using Education_Core.WebApi.IntegrationTests.Factories;
using Education_Core.WebApi.IntegrationTests.SourceData.TestData;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
        [MemberData(nameof(UserWithRoleTData.DataForCreate), MemberType = typeof(UserWithRoleTData))]
        public async Task CreateUserWithRole_WhenValidTestPassed_ShouldReturnIEnumerableUsers(UserWithRole user,
            UserWithRole expected)
        {
            await TruncateAllTablesAsync();

            var postResponse = await SendRequesToCreate(user);

            var getResponse = await SendRequesToGetByID(user);
            var actual = JsonConvert.DeserializeObject<UserWithRole>(await getResponse.Content.ReadAsStringAsync());

            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(UserWithRoleTData.DataForUpdate), MemberType = typeof(UserWithRoleTData))]
        public async Task UpdateUserWithRole_WhenValidTestPassed_ShouldReturnUpdatetUser(UserWithRole user)
        {
            await TruncateAllTablesAsync();

            var postResponse = await SendRequesToCreate(user);

            user.FirstName = "Update First Name";
            user.LastName = "Update Last Name";
            var updateRoute = ApiRoutes.UserWIthRole.GetRouteForUpdate();
            var updateResponce = await _client.PutAsync(updateRoute,
                new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            var getResponse = await SendRequesToGetByID(user);
            var actual = JsonConvert.DeserializeObject<UserWithRole>(await getResponse.Content.ReadAsStringAsync());

            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            updateResponce.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(user);
        }

        [Theory]
        [MemberData(nameof(UserWithRoleTData.DataForCreate), MemberType = typeof(UserWithRoleTData))]
        public async Task GetUserWithRoleByLoginAndPassword_WhenValidTestPassed_ShouldReturnIEnumerableUsers(UserWithRole user,
            UserWithRole expected)
        {
            await TruncateAllTablesAsync();

            var postResponse = await SendRequesToCreate(user);

            var getResponse = await SendRequesToGetByID(user);
            var actual = JsonConvert.DeserializeObject<UserWithRole>(await getResponse.Content.ReadAsStringAsync());

            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(UserWithRoleTData.DataForUpdate), MemberType = typeof(UserWithRoleTData))]
        public async Task DeleteUserWithRole_WhenValidTestPassed_ShouldDelete(UserWithRole user)
        {
            await TruncateAllTablesAsync();

            var postResponse = await SendRequesToCreate(user);

            var deleteRoute = ApiRoutes.UserWIthRole.GetRouteForDelete(user.ID);
            var deleteResponse = await _client.DeleteAsync(deleteRoute);

            var getResponse = await SendRequesToGetByID(user);

            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        protected override async Task<HttpResponseMessage> SendRequesToCreate(object obj)
        {
            var userWithRole = (UserWithRole)obj;
            var postRoute = ApiRoutes.UserWIthRole.GetRouteForCreate();
            var postResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(userWithRole), Encoding.UTF8, "application/json"));

            return postResponse;
        }

        protected override async Task<HttpResponseMessage> SendRequesToGetByID(object obj)
        {
            var userWithRole = (UserWithRole)obj;
            var getRoute = ApiRoutes.UserWIthRole.GetRouteForGetByID(userWithRole.ID);
            var getResponse = await _client.GetAsync(getRoute);

            return getResponse;
        }

        protected override Task<HttpResponseMessage> SendRequesToGetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
