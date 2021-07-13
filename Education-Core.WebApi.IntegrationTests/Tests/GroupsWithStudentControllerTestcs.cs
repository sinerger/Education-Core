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
        [MemberData(nameof(GroupWithStudentsData.DataForGetGroupWithStudent), MemberType = typeof(GroupWithStudentsData))]
        public async Task GetGroupWithStudent_WhenValidTestPassed_ShouldReturnGroupWithAllStudent(
             GroupWithStudents groupWithStudents)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            using (DbConnection connection = new MySqlConnection(_connectionString))
            {
                var courseID = groupWithStudents.Course.ID;
                await connection.QueryAsync("CreateGroupWithinCourse",
                   parameters: new
                   {
                       groupWithStudents.ID,
                       groupWithStudents.Title,
                       groupWithStudents.StartDate,
                       groupWithStudents.FinishDate,
                       courseID

                   });

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
                await connection.QueryAsync("CreateCourse", CoursesData.Courses[0]);

                foreach (var student in UserData.Students)
                {
                    await connection.QueryAsync("CreateStudent", student);
                }

            }
        }
    }
}
