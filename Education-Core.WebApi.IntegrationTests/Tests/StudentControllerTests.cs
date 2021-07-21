using Domain.Entities.Groups;
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
    public class StudentControllerTests : IntegrationTestAbstract
    {
        public StudentControllerTests(ApiWebApplicationFactory fixture) : base(fixture)
        {

        }

        [Theory]
        [MemberData(nameof(StudentTData.DataForCreate), MemberType = typeof(StudentTData))]
        public async Task CreateStudent_WhenValidTestPassed_ShouldReturnIEnumerableStudents(Student insertedStudent,
            Student expected)
        {
            await TruncateAllTablesAsync();

            var postRoute = ApiRoutes.Student.GetRouteForCreate();
            var postResponce = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(insertedStudent), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.Student.GetRouteForGetByID(insertedStudent.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<Student>(await getResponse.Content.ReadAsStringAsync());

            postResponce.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(StudentTData.DataForUpdate), MemberType = typeof(StudentTData))]
        public async Task UpdateStudent_WhenValidTestPassed_ShoulUpdateStudentInDB(Student insertedStudent,
            Student updatedStudent, Student expected)
        {
            await TruncateAllTablesAsync();

            var postRoute = ApiRoutes.Student.GetRouteForCreate();
            var postResponce = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(insertedStudent), Encoding.UTF8, "application/json"));

            var putRoute = ApiRoutes.Student.GetRouteForUpdate();
            var putResponse = await _client.PutAsync(putRoute,
                new StringContent(JsonConvert.SerializeObject(updatedStudent), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.Student.GetRouteForGetByID(insertedStudent.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<Student>(await getResponse.Content.ReadAsStringAsync());

            postResponce.StatusCode.Should().Be(HttpStatusCode.OK);
            putResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(StudentTData.DataForDelete), MemberType = typeof(StudentTData))]
        public async Task DeleteStudent_WhenValidTestPassed_ShouldDelete(Student deletedStudent)
        {
            await TruncateAllTablesAsync();

            var postRoute = ApiRoutes.Student.GetRouteForCreate();
            var postResponce = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(deletedStudent), Encoding.UTF8, "application/json"));

            var deleteRoute = ApiRoutes.Student.GetRouteForDelete(deletedStudent.ID);
            var deleteResponce = await _client.DeleteAsync(deleteRoute);

            var getRoute = ApiRoutes.Student.GetRouteForGetByID(deletedStudent.ID);
            var getResponse = await _client.GetAsync(getRoute);

            postResponce.StatusCode.Should().Be(HttpStatusCode.OK);
            deleteResponce.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Theory]
        [MemberData(nameof(StudentTData.DataForCreate), MemberType = typeof(StudentTData))]
        public async Task GetAllStudents_WhenValidTestPassed_ShouldReturnAllStudents(Student insertedStudent,
            Student expected)
        {
            await TruncateAllTablesAsync();

            var postRoute = ApiRoutes.Student.GetRouteForCreate();
            var postResponce = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(insertedStudent), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.Student.GetRouteForGetAllStudents();
            var getResponce = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<List<Student>>(await getResponce.Content.ReadAsStringAsync());

            postResponce.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponce.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(StudentTData.DataForAddStudentToGroup), MemberType = typeof(StudentTData))]
        public async Task AddStudentToGroup_WhenValidTestPassed_ShouldAddStudentToGroup(Student student, Group group)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Student.GetRouteForCreate();
            var postResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json"));

            var addStudentToGroupRoute = ApiRoutes.Student.GetRouteForAddStudentToGroup(student.ID, group.ID);
            var addStudentToGroupResponse = await _client.PostAsync(addStudentToGroupRoute,
                new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.Student.GetRouteForGetByID(student.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<Student>(await getResponse.Content.ReadAsStringAsync());

            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            addStudentToGroupResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(student);
        }

        protected async override Task InitializeData()
        {
            using (DbConnection connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                await connection.QueryAsync("CreateCourse", CourseInitData.Course);

                var courseID = CourseInitData.Course.ID;

                await connection.QueryAsync("CreateGroupWithinCourse", parameters: new
                {
                    GroupInitData.Group.ID,
                    GroupInitData.Group.Title,
                    GroupInitData.Group.StartDate,
                    GroupInitData.Group.FinishDate,
                    courseID
                });
            }
        }
    }
}
