using Domain.Entities.Lessons;
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
    public class LessonControllerIntegrationTests : IntegrationTestAbstract
    {
        public LessonControllerIntegrationTests(ApiWebApplicationFactory fixture) : base(fixture)
        {
        }

        [Theory]
        [MemberData(nameof(LessonTData.DataForCreate), MemberType = typeof(LessonTData))]
        public async Task CreateLessonWithinCourse_WhenValidTestPassed_ShouldReturnIEnumerableUsers(
            Lesson lessonToInsert, Lesson expected)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Lesson.GetRouteForCreate();
            var postResponse = await _client.PostAsync(
                postRoute, new StringContent(JsonConvert.SerializeObject(lessonToInsert), Encoding.UTF8, "application/json"));
            await AddChildsWithinLesson(lessonToInsert);

            var getRoute = ApiRoutes.Lesson.GetRouteForGetByID(lessonToInsert.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<Lesson>(await getResponse.Content.ReadAsStringAsync());

            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(LessonTData.DataForGetAll), MemberType = typeof(LessonTData))]
        public async Task GetAllLessons_WhenValidDataPassed_ShouldReturnIEnumerableLessons
            (Lesson lessonToInsert, List<Lesson> expected)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Lesson.GetRouteForCreate();
            var postRespone = await _client.PostAsync(
                postRoute, new StringContent(JsonConvert.SerializeObject(lessonToInsert), Encoding.UTF8, "application/json"));
            await AddChildsWithinLesson(lessonToInsert);

            var getRoute = ApiRoutes.Lesson.GetRouteForAllLessons();
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<List<Lesson>>(await getResponse.Content.ReadAsStringAsync());

            postRespone.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(LessonTData.DataForCreate), MemberType = typeof(LessonTData))]
        public async Task GetLessonById_WhenValidDataPassed_ShouldReturnLessons
            (Lesson lessonToInsert, Lesson expected)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Lesson.GetRouteForCreate();
            var postRespone = await _client.PostAsync(
                postRoute, new StringContent(JsonConvert.SerializeObject(lessonToInsert), Encoding.UTF8, "application/json"));
            await AddChildsWithinLesson(lessonToInsert);

            var getRoute = ApiRoutes.Lesson.GetRouteForGetByID(lessonToInsert.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<Lesson>(await getResponse.Content.ReadAsStringAsync());

            postRespone.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(LessonTData.DataForUpdate), MemberType = typeof(LessonTData))]
        public async Task UpdateLesson_WhenValidDataPassed_ShouldUpdateLesson(Lesson lesson)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Lesson.GetRouteForCreate();
            var postRespone = await _client.PostAsync(
                postRoute, new StringContent(JsonConvert.SerializeObject(lesson), Encoding.UTF8, "application/json"));
            await AddChildsWithinLesson(lesson);

            lesson.Title = "Updated title";
            lesson.Description = "Updated description";
            var putRoute = ApiRoutes.Lesson.GetRouteForUpdate();
            var putResponce = await _client.PutAsync(putRoute,
                new StringContent(JsonConvert.SerializeObject(lesson), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.Lesson.GetRouteForGetByID(lesson.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<Lesson>(await getResponse.Content.ReadAsStringAsync());

            postRespone.StatusCode.Should().Be(HttpStatusCode.OK);
            putResponce.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(lesson);
        }

        [Theory]
        [MemberData(nameof(LessonTData.DataForUpdate), MemberType = typeof(LessonTData))]
        public async Task DeleteLesson_WhenValidDataPassed_ShouldDeleteLesson(Lesson lessonToDelete)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Lesson.GetRouteForCreate();
            var postRespone = await _client.PostAsync(
                postRoute, new StringContent(JsonConvert.SerializeObject(lessonToDelete), Encoding.UTF8, "application/json"));
            await AddChildsWithinLesson(lessonToDelete);

            var deleteRoute = ApiRoutes.Lesson.GetRouteForDelete(lessonToDelete.ID);
            var deleteResponce = await _client.DeleteAsync(deleteRoute);

            var getRoute = ApiRoutes.Lesson.GetRouteForGetByID(lessonToDelete.ID);
            var getResponse = await _client.GetAsync(getRoute);

            postRespone.StatusCode.Should().Be(HttpStatusCode.OK);
            deleteResponce.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        protected async override Task InitializeData()
        {
            using (DbConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                await conn.QueryAsync("CreateCourse", SourceData.InitializeData.CourseInitData.Courses[0]);
                await conn.QueryAsync("CreateHomework", HomeworkInitData.Homework);
                await conn.QueryAsync("CreateTeacher", UserInitData.Teacher);
            }
        }

        private async Task AddChildsWithinLesson(Lesson lesson)
        {
            using (DbConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                var lessonID = lesson.ID;
                var homeworkID = lesson.Homework.ID;
                await conn.QueryAsync("AddHomeworkWithinLesson", 
                    new
                    {
                        homeworkID,
                        lessonID
                    });
                var teacherID = lesson.Teacher.ID;
                await conn.QueryAsync("AddTeacherToLesson", new { teacherID, lessonID });
            }
        }
    }
}
