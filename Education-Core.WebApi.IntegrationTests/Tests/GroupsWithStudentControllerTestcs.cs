using Domain.Entities.GroupWithStudents;
using Education_Core.WebApi.IntegrationTests.Factories;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;
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
        [MemberData(nameof(GroupWithStudentsTData.DataForGetGroupWithStudent), MemberType = typeof(GroupWithStudentsTData))]
        public async Task GetGroupWithStudent_WhenValidTestPassed_ShouldReturnGroupWithAllStudent(
             GroupWithStudents groupWithStudents)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Group.GetRouteForCreate();
            var response = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(groupWithStudents), Encoding.UTF8, "application/json"));

            await InitializeStudent(groupWithStudents);

            var getRoute = ApiRoutes.GroupWithStudents.GetRouteForGetByID(groupWithStudents.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<GroupWithStudents>(await getResponse.Content.ReadAsStringAsync());

            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(groupWithStudents);
        }

        protected async override Task InitializeData()
        {
            using (DbConnection connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                await connection.QueryAsync("CreateCourse", CourseInitData.Courses[0]);

                foreach (var student in UserInitData.Students)
                {
                    await connection.QueryAsync("CreateStudent", student);
                }
            }
        }

        private async Task InitializeStudent(GroupWithStudents groupWithStudents)
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
