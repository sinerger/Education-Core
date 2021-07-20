using Domain.Entities.GroupWithStudents;
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
    public class GroupsWithStudentControllerTests : IntegrationTestAbstract
    {
        public GroupsWithStudentControllerTests(ApiWebApplicationFactory fixture) : base(fixture)
        {

        }

        [Theory]
        [MemberData(nameof(GroupWithStudentsTData.GetDataForGetGroupWithStudent), MemberType = typeof(GroupWithStudentsTData))]
        public async Task GetGroupWithStudent_WhenValidTestPassed_ShouldReturnGroupWithAllStudent(
             GroupWithStudents groupWithStudents)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postResponse = await SendRequesToCreate(groupWithStudents);

            await InitializeStudentToGroup(groupWithStudents);

            var getResponse = await SendRequesToGetByID(groupWithStudents);
            var actual = JsonConvert.DeserializeObject<GroupWithStudents>(await getResponse.Content.ReadAsStringAsync());

            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(groupWithStudents);
        }

        protected async override Task InitializeData()
        {
            using (DbConnection connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                await connection.QueryAsync("CreateCourse", CourseInitData.Course);

                foreach (var student in UserInitData.Students)
                {
                    await connection.QueryAsync("CreateStudent", student);
                }
            }
        }

        protected override async Task<HttpResponseMessage> SendRequesToCreate(object obj)
        {
            var groupWithStudents = (GroupWithStudents)obj;
            var postRoute = ApiRoutes.Group.GetRouteForCreate();
            var postResponce = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(groupWithStudents), Encoding.UTF8, "application/json"));

            return postResponce;
        }

        protected override async Task<HttpResponseMessage> SendRequesToGetAll()
        {
            throw new NotImplementedException();
        }

        protected override async Task<HttpResponseMessage> SendRequesToGetByID(object obj)
        {
            var groupWithStudents = (GroupWithStudents)obj;
            var getRoute = ApiRoutes.GroupWithStudents.GetRouteForGetByID(groupWithStudents.ID);
            var getResponse = await _client.GetAsync(getRoute);

            return getResponse;
        }

        private async Task InitializeStudentToGroup(GroupWithStudents groupWithStudents)
        {
            using (DbConnection connection = new MySqlConnection(_connectionString))
            {
                foreach (var student in groupWithStudents.Students)
                {
                    var GroupID = groupWithStudents.ID;
                    var UserID = student.ID;

                    await connection.QueryAsync("AddStudentToGroup", parameters: new
                    {
                        GroupID,
                        UserID
                    });
                }
            }
        }
    }
}
