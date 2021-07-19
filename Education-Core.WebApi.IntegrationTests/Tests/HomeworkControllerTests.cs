using Domain.Entities.Homeworks;
using Domain.Entities.Lessons;
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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.Routes;
using Xunit;

namespace Education_Core.WebApi.IntegrationTests.Tests
{
    public class HomeworkControllerTests : IntegrationTestAbstract
    {
        public HomeworkControllerTests(ApiWebApplicationFactory fixture) : base(fixture)
        {
        }

        [Theory]
        [MemberData(nameof(HomeworkTData.GetDataForCreate), MemberType = typeof(HomeworkTData))]
        public async Task CreateUserWithRole_WhenValidTestPassed_ShouldReturnIEnumerableUsers(Homework insertedHomework, Guid lessonID,
            Homework expected)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Homework.GetRouteForCreate();
            var postResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(insertedHomework), Encoding.UTF8, "application/json"));

            var putRoute = ApiRoutes.Homework.GetRouteForAddByLessonID(lessonID);
            var putResponse = await _client.PutAsync(putRoute,
                new StringContent(JsonConvert.SerializeObject(insertedHomework), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.Homework.GetRouteForGetByLessonID(lessonID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<Homework>(await getResponse.Content.ReadAsStringAsync());

            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            putResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(HomeworkTData.GetDataForDelete), MemberType = typeof(HomeworkTData))]
        public async Task DeleteHomework_WhenValidTestPassed_ShouldReturnStatusNoContent(Homework insertedHomework, Guid lessonID)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Homework.GetRouteForCreate();
            var postResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(insertedHomework), Encoding.UTF8, "application/json"));

            var putRoute = ApiRoutes.Homework.GetRouteForAddByLessonID(lessonID);
            var putResponse = await _client.PutAsync(putRoute,
                new StringContent(JsonConvert.SerializeObject(insertedHomework), Encoding.UTF8, "application/json"));

            var deleteRoute = ApiRoutes.Homework.GetRouteForDelete(insertedHomework.ID);
            var deleteResponse = await _client.DeleteAsync(deleteRoute);

            var getRoute = ApiRoutes.Homework.GetRouteForGetByLessonID(lessonID);
            var getResponse = await _client.GetAsync(getRoute);

            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            putResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Theory]
        [MemberData(nameof(HomeworkTData.GetDataForUpdate), MemberType = typeof(HomeworkTData))]
        public async Task UpdateHomework_WhenValidTestPassed_ShouldReturnUpdatedHomework(Homework updatedHomewrk, Guid lessonID)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Homework.GetRouteForCreate();
            var postResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(updatedHomewrk), Encoding.UTF8, "application/json"));

            var putRoute = ApiRoutes.Homework.GetRouteForAddByLessonID(lessonID);
            var putResponse = await _client.PutAsync(putRoute,
                new StringContent(JsonConvert.SerializeObject(updatedHomewrk), Encoding.UTF8, "application/json"));

            updatedHomewrk.Title = "Update title";
            updatedHomewrk.Description = "Update description";

            var updateRoute = ApiRoutes.Homework.GetRouteForUpdate();
            var updateResponse = await _client.PutAsync(updateRoute,
                new StringContent(JsonConvert.SerializeObject(updatedHomewrk), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.Homework.GetRouteForGetByLessonID(lessonID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<Homework>(await getResponse.Content.ReadAsStringAsync());

            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            putResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(updatedHomewrk);
        }

        [Theory]
        [MemberData(nameof(HomeworkTData.GetDataForGetAllByCourseID), MemberType = typeof(HomeworkTData))]
        public async Task GetAllHomeworkByCourseID_WhenValidTestPassed_ShouldReturnIEnumerableUsers(Homework insertedHomework, Guid lessonID,
            Guid courseID, Homework expected)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Homework.GetRouteForCreate();
            var postResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(insertedHomework), Encoding.UTF8, "application/json"));

            var putRoute = ApiRoutes.Homework.GetRouteForAddByLessonID(lessonID);
            var putResponse = await _client.PutAsync(putRoute,
                new StringContent(JsonConvert.SerializeObject(insertedHomework), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.Homework.GetRouteForGetAllByCourseID(courseID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<List<Homework>>(await getResponse.Content.ReadAsStringAsync());

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
                await conn.QueryAsync("CreateCourse", CourseInitData.Courses[0]);

                var lesson = LessonInitData.Lesson;
                var TeacherID = lesson.Teacher.ID;
                var courseID = lesson.Course.ID;
                lesson.ID = lesson.ID == Guid.Empty ? Guid.NewGuid() : lesson.ID;

                await conn.QueryAsync("CreateLessonWithinCourse",
                    parameters: new
                    {
                        lesson.ID,
                        lesson.Title,
                        lesson.Description,
                        lesson.DeadLine,
                        courseID
                    });
            }
        }
    }
}
