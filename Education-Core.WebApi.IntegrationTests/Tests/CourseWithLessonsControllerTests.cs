using Domain.Entities.Courses;
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
using System.Threading.Tasks;
using WebApi.Routes;
using Xunit;

namespace Education_Core.WebApi.IntegrationTests.Tests
{
    public class CourseWithLessonsControllerTests : IntegrationTestAbstract
    {
        public CourseWithLessonsControllerTests(ApiWebApplicationFactory fixture) : base(fixture)
        {
        }

        [Theory]
        [MemberData(nameof(CourseWithLessonsTData.GetDataForGetById), MemberType = typeof(CourseWithLessonsTData))]
        public async Task GetCourseWithLessons_WhenValidTestPassed_ShouldReturnIEnumerableLessons
            (CourseWithLessons expected)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var getRout = ApiRoutes.CourseWithLessons.GetRouteForGetById(expected.ID);
            var getResponse = await _client.GetAsync(getRout);
            var actual = JsonConvert.DeserializeObject<CourseWithLessons>(await getResponse.Content.ReadAsStringAsync());

            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }
        protected async override Task InitializeData()
        {
            using (DbConnection connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                await connection.QueryAsync("CreateCourse", LessonInitData.Lesson.Course);
                await connection.QueryAsync("CreateTeacher", LessonInitData.Lesson.Teacher);
                var courseID = LessonInitData.Lesson.Course.ID;
                await connection.QueryAsync("CreateLessonWithinCourse", new
                {
                    LessonInitData.Lesson.ID,
                    LessonInitData.Lesson.Title,
                    LessonInitData.Lesson.Description,
                    LessonInitData.Lesson.DeadLine,
                    courseID
                });
                await connection.QueryAsync("CreateHomework", LessonInitData.Lesson.Homework);
                var lessonID = LessonInitData.Lesson.ID;
                var homeworkID = LessonInitData.Lesson.Homework.ID;
                await connection.QueryAsync("AddHomeworkWithinLesson",
                    new
                    {
                        homeworkID,
                        lessonID
                    });
                var teacherID = LessonInitData.Lesson.Teacher.ID;
                await connection.QueryAsync("AddTeacherToLesson", new { teacherID, lessonID });
            }
        }
    }
}
