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
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.Routes;
using Xunit;

namespace Education_Core.WebApi.IntegrationTests.Tests
{
    public class AttendanceControllerTests : IntegrationTestAbstract
    {
        public AttendanceControllerTests(ApiWebApplicationFactory fixture) : base(fixture)
        {
        }

        [Theory]
        [MemberData(nameof(AttendanceTData.DataForCreate), MemberType = typeof(AttendanceTData))]
        public async Task CreateAttendanceWithinLesson_WhenValidTestPassed_ShouldCreateRecordInDB(
            Attendance attendanceToInsert, Attendance expected)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Attendance.GetRouteForCreate(LessonInitData.Lesson.ID);
            var createResponse = await _client.PostAsync(
                postRoute, new StringContent(JsonConvert.SerializeObject(attendanceToInsert), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.Attendance.GetRouteForGetAllAttendanceByLessonID(LessonInitData.Lesson.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<List<Attendance>>(await getResponse.Content.ReadAsStringAsync());

            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        protected async override Task InitializeData()
        {
            using (DbConnection conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                await conn.QueryAsync("CreateStudent", UserInitData.Students[0]);
                await conn.QueryAsync("CreateCourse", CourseInitData.Courses[0]);
                await conn.QueryAsync("CreateHomework", HomeworkInitData.Homework);
                await conn.QueryAsync("CreateTeacher", UserInitData.Teacher);

                var TeacherID = LessonInitData.Lesson.Teacher.ID;
                var courseID = LessonInitData.Lesson.Course.ID;

                await conn.QueryAsync("CreateLessonWithinCourse", new
                {
                    LessonInitData.Lesson.ID,
                    LessonInitData.Lesson.Title,
                    LessonInitData.Lesson.Description,
                    LessonInitData.Lesson.DeadLine,
                    courseID
                });
            }
        }
    }
}
