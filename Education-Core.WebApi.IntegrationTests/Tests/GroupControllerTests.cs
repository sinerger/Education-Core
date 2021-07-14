﻿using System;
using System.Collections.Generic;
using Domain.Entities.Groups;
using Education_Core.WebApi.IntegrationTests.Factories;
using Education_Core.WebApi.IntegrationTests.SourceData.TestData;
using FluentAssertions;
using Insight.Database;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data.Common;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Education_Core.WebApi.IntegrationTests.SourceData;
using WebApi.Routes;
using Xunit;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;

namespace Education_Core.WebApi.IntegrationTests.Tests
{
    public class GroupControllerTests : IntegrationTestAbstract
    {
        public GroupControllerTests(ApiWebApplicationFactory fixture) : base(fixture)
        {
        }

        [Theory]
        [MemberData(nameof(GroupData.DataForCreate), MemberType = typeof(GroupData))]
        public async Task CreateGroupWithinCourse_WhenValidTestPassed_ShouldReturnCreatedGroup(Group insertedGroup,
            Group expected)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Group.GetRouteForCreate();
            var response = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(insertedGroup), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.Group.GetRouteForGetByID(insertedGroup.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<Group>(await getResponse.Content.ReadAsStringAsync());
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(GroupData.DataForUpdate), MemberType = typeof(GroupData))]
        public async Task UpdateGroup_WhenValidTestPassed_ShouldReturnUpdatedGroup(Group group)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Group.GetRouteForCreate();
            var createResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(group), Encoding.UTF8, "application/json"));

            group.Title = "UpdateGroup";
            group.StartDate = new DateTime(2021, 12, 10);
            var updateRoute = ApiRoutes.Group.GetRouteForUpdate();
            var updateResponse = await _client.PutAsync(updateRoute,
                new StringContent(JsonConvert.SerializeObject(group), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.Group.GetRouteForGetByID(group.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<Group>(await getResponse.Content.ReadAsStringAsync());

            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(group);
        }

        [Theory]
        [MemberData(nameof(GroupData.DataForUpdate), MemberType = typeof(GroupData))]
        public async Task DeleteGroup_WhenValidTestPassed_ShouldDeleteGroup(Group group)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Group.GetRouteForCreate();
            var createResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(group), Encoding.UTF8, "application/json"));

            var deleteRoute = ApiRoutes.Group.GetRouteForDelete(group.ID);
            var deleteResponse = await _client.DeleteAsync(deleteRoute);

            var getRoute = ApiRoutes.Group.GetRouteForGetByID(group.ID);
            var getResponse = await _client.GetAsync(getRoute);

            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Theory]
        [MemberData(nameof(GroupData.DataForGetAllGroups), MemberType = typeof(GroupData))]
        public async Task GetAllGroups_WhenValidTestPassed_ShouldReturnAllGroups(List<Group> insertedGroup, List<Group> expected)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            HttpResponseMessage createResponse = new HttpResponseMessage();

            foreach (var group in insertedGroup)
            {
                var postRoute = ApiRoutes.Group.GetRouteForCreate();
                createResponse = await _client.PostAsync(postRoute,
                    new StringContent(JsonConvert.SerializeObject(group), Encoding.UTF8, "application/json"));
            }

            var getRoute = ApiRoutes.Group.GetRouteForGetAllGroups();
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<List<Group>>(await getResponse.Content.ReadAsStringAsync());

            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }
        protected async override Task InitializeData()
        {
            using (DbConnection connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                await connection.QueryAsync("CreateCourse", SourceData.InitializeData.CourseData.Courses[0]);
            }
        }
    }
}
