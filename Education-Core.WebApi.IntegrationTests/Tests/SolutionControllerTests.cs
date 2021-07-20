using Domain.Entities.Solutions;
using Domain.Entities.Users;
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
    public class SolutionControllerTests : IntegrationTestAbstract
    {
        public SolutionControllerTests(ApiWebApplicationFactory fixture) : base(fixture)
        {
        }

        [Theory]
        [MemberData(nameof(SolutionTData.GetDataForCreate), MemberType = typeof(SolutionTData))]
        public async Task CreateSolutionWithinHomework_WhenValidTestPassed_ShouldReturnIEnumerableUsers(Solution insertedSolution, Student student,
            Solution expected)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postResponse = await SendRequesToCreate(student.ID, insertedSolution);

            var getRoute = ApiRoutes.Solution.GetRouteForGetAllByHomeworkID(insertedSolution.Homework.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<IEnumerable<Solution>>(await getResponse.Content.ReadAsStringAsync());

            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(SolutionTData.GetDataForUpdate), MemberType = typeof(SolutionTData))]
        public async Task UpdateSolution_WhenValidTestPassed_ShouldReturnIEnumerableUsers(Solution solution, Student student)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postResponse = await SendRequesToCreate(student.ID, solution);

            solution.Answer = "Updated Answer";
            solution.Mark = 100;
            var putRoute = ApiRoutes.Solution.GetRouteForUpdate();
            var putResponce = await _client.PutAsync(putRoute,
                new StringContent(JsonConvert.SerializeObject(solution), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.Solution.GetRouteForGetAllByHomeworkID(solution.Homework.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<IEnumerable<Solution>>(await getResponse.Content.ReadAsStringAsync());

            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            putResponce.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(solution);
        }

        [Theory]
        [MemberData(nameof(SolutionTData.GetDataForDelete), MemberType = typeof(SolutionTData))]
        public async Task DeleteSolution_WhenValidTestPassed_ShouldReturnIEnumerableUsers(Solution solution, Student student)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postResponse = await SendRequesToCreate(student.ID, solution);

            var deleteRoute = ApiRoutes.Solution.GetRouteForDeletete(solution.ID);
            var deleteResponse = await _client.DeleteAsync(deleteRoute);

            var getResponse = await SendRequesToGetByID(student.ID);
            var actual = JsonConvert.DeserializeObject<IEnumerable<Solution>>(await getResponse.Content.ReadAsStringAsync());

            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().HaveCount(0);
        }

        protected async override Task InitializeData()
        {
            using (DbConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();

                await conn.QueryAsync("CreateCourse", CourseInitData.Course);
                var courseID = LessonInitData.Lesson.Course.ID;
                await conn.QueryAsync("CreateLessonWithinCourse", new
                {
                    LessonInitData.Lesson.ID,
                    LessonInitData.Lesson.Title,
                    LessonInitData.Lesson.Description,
                    LessonInitData.Lesson.DeadLine,
                    courseID
                });

                var lessonID = LessonInitData.Lesson;
                await conn.QueryAsync("CreateHomeworkWithinLesson", new
                {
                    HomeworkInitData.Homework.ID,
                    HomeworkInitData.Homework.Title,
                    HomeworkInitData.Homework.Description,
                    HomeworkInitData.Homework.Deadline,
                    lessonID
                });

                await conn.QueryAsync("CreateStudent", UserInitData.Students[0]);
            }
        }

        protected async Task<HttpResponseMessage> SendRequesToCreate(Guid studentID, Solution solution)
        {
            var postRoute = ApiRoutes.Solution.GetRouteForCreate(studentID);

            var postResponce = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(solution), Encoding.UTF8, "application/json"));

            return postResponce;
        }

        protected override async Task<HttpResponseMessage> SendRequesToCreate(object obj)
        {
            throw new NotImplementedException();
        }

        protected override async Task<HttpResponseMessage> SendRequesToGetByID(object obj)
        {
            var studentID = (Guid)obj;
            var getRoute = ApiRoutes.Solution.GetRouteForGetAllByStudentID(studentID);
            var getResponse = await _client.GetAsync(getRoute);

            return getResponse;
        }

        protected override Task<HttpResponseMessage> SendRequesToGetAll()
        {
            throw new NotImplementedException();
        }
    }
}
