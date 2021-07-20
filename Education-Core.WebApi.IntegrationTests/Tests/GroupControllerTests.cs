using Domain.Entities.Groups;
using Education_Core.WebApi.IntegrationTests.Factories;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;
using Education_Core.WebApi.IntegrationTests.SourceData.TestData;
using FluentAssertions;
using Insight.Database;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
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
    public class GroupControllerTests : IntegrationTestAbstract
    {
        public GroupControllerTests(ApiWebApplicationFactory fixture) : base(fixture)
        {
        }

        [Theory]
        [MemberData(nameof(GroupTData.GetDataForCreate), MemberType = typeof(GroupTData))]
        public async Task CreateGroupWithinCourse_WhenValidTestPassed_ShouldReturnCreatedGroup(Group group,
            Group expected)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postResponse = await SendRequesToCreate(group);

            var getResponse = await SendRequesToGetByID(group);
            var actual = JsonConvert.DeserializeObject<Group>(await getResponse.Content.ReadAsStringAsync());

            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(GroupTData.GetDataForUpdate), MemberType = typeof(GroupTData))]
        public async Task UpdateGroup_WhenValidTestPassed_ShouldReturnUpdatedGroup(Group group)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postResponse = await SendRequesToCreate(group);

            group.Title = "UpdateGroup";
            group.StartDate = new DateTime(2021, 12, 10);
            var updateRoute = ApiRoutes.Group.GetRouteForUpdate();
            var putResponse = await _client.PutAsync(updateRoute,
                new StringContent(JsonConvert.SerializeObject(group), Encoding.UTF8, "application/json"));

            var getResponse = await SendRequesToGetByID(group);
            var actual = JsonConvert.DeserializeObject<Group>(await getResponse.Content.ReadAsStringAsync());

            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            putResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(group);
        }

        [Theory]
        [MemberData(nameof(GroupTData.GetDataForUpdate), MemberType = typeof(GroupTData))]
        public async Task DeleteGroup_WhenValidTestPassed_ShouldDeleteGroup(Group group)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postResponse = await SendRequesToCreate(group);

            var deleteRoute = ApiRoutes.Group.GetRouteForDelete(group.ID);
            var deleteResponse = await _client.DeleteAsync(deleteRoute);

            var getResponse = await SendRequesToGetByID(group);

            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Theory]
        [MemberData(nameof(GroupTData.GetDataForGetAllGroups), MemberType = typeof(GroupTData))]
        public async Task GetAllGroups_WhenValidTestPassed_ShouldReturnAllGroups(List<Group> insertedGroup, List<Group> expected)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            foreach (var group in insertedGroup)
            {
                var postResponse = await SendRequesToCreate(group);
                postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            }

            var getResponse = await SendRequesToGetAll();
            var actual = JsonConvert.DeserializeObject<List<Group>>(await getResponse.Content.ReadAsStringAsync());

            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        protected override async Task<HttpResponseMessage> SendRequesToCreate(object obj)
        {
            var group = (Group)obj;
            var postRoute = ApiRoutes.Group.GetRouteForCreate();
            var postResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(group), Encoding.UTF8, "application/json"));

            return postResponse;
        }

        protected override async Task<HttpResponseMessage> SendRequesToGetByID(object obj)
        {
            var group = (Group)obj;
            var getRoute = ApiRoutes.Group.GetRouteForGetByID(group.ID);
            var getResponse = await _client.GetAsync(getRoute);

            return getResponse;
        }

        protected async override Task InitializeData()
        {
            using (DbConnection connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                await connection.QueryAsync("CreateCourse", CourseInitData.Course);
            }
        }

        protected override async Task<HttpResponseMessage> SendRequesToGetAll()
        {
            var getRoute = ApiRoutes.Group.GetRouteForGetAllGroups();
            var getResponse = await _client.GetAsync(getRoute);

            return getResponse;
        }
    }
}
