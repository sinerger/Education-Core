using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Users;
using Education_Core.WebApi.IntegrationTests.Factories;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;
using Education_Core.WebApi.IntegrationTests.SourceData.TestData;
using FluentAssertions;
using Insight.Database;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using WebApi.Routes;
using Xunit;

namespace Education_Core.WebApi.IntegrationTests.Tests
{
    public class TeacherControllerTest : IntegrationTestAbstract
    {
        public TeacherControllerTest(ApiWebApplicationFactory fixture) : base(fixture)
        {
        }

        [Theory]
        [MemberData(nameof(TeacherTData.DataForCreate), MemberType = typeof(TeacherTData))]
        public async Task CreateTeacher_WhenValidTestPassed_ShouldReturnTeacher(Teacher insertedTeacher,
            Teacher expected)
        {
            await TruncateAllTablesAsync();

            var postRoute = ApiRoutes.Teacher.GetRouteForCreate();
            var createResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(insertedTeacher), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.Teacher.GetRouteForGetByID(insertedTeacher.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<Teacher>(await getResponse.Content.ReadAsStringAsync());

            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(TeacherTData.DataForGetAll), MemberType = typeof(TeacherTData))]
        public async Task GetAllTeachers_WhenValidTestPassed_ShouldReturnAllTeachers(Teacher insertedTeacher,
            Teacher expected)
        {
            await TruncateAllTablesAsync();

            var postRoute = ApiRoutes.Teacher.GetRouteForCreate();
            var createResponse = await _client.PostAsync(postRoute,
               new StringContent(JsonConvert.SerializeObject(insertedTeacher), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.Teacher.GetRouteForGetAllTeachers();
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<List<Teacher>>(await getResponse.Content.ReadAsStringAsync());

            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(TeacherTData.DataForUpdate), MemberType = typeof(TeacherTData))]
        public async Task UpdateTeacher_WhenValidTestPassed_ShouldReturnTeacher(Teacher teacher)
        {
            await TruncateAllTablesAsync();

            var postRoute = ApiRoutes.Teacher.GetRouteForCreate();
            var createResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(teacher), Encoding.UTF8, "application/json"));

            teacher.FirstName = "NewTeacherName";
            teacher.LastName = "NewTeacherLastName";
            var updateRoute = ApiRoutes.Teacher.GetRouteForUpdate();
            var updateResponse = await _client.PutAsync(updateRoute,
                new StringContent(JsonConvert.SerializeObject(teacher), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.Teacher.GetRouteForGetByID(teacher.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<Teacher>(await getResponse.Content.ReadAsStringAsync());

            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(teacher);
        }

        [Theory]
        [MemberData(nameof(TeacherTData.DataForUpdate), MemberType = typeof(TeacherTData))]
        public async Task DeleteTeacher_WhenValidTestPassed_ShouldDeleteTeacher(Teacher teacher)
        {
            await TruncateAllTablesAsync();

            var postRoute = ApiRoutes.Teacher.GetRouteForCreate();
            var createResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(teacher), Encoding.UTF8, "application/json"));

            var deleteRoute = ApiRoutes.Teacher.GetRouteForDelete(teacher.ID);
            var deleteResponse = await _client.DeleteAsync(deleteRoute);

            var getRoute = ApiRoutes.Teacher.GetRouteForGetByID(teacher.ID);
            var getResponse = await _client.GetAsync(getRoute);

            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Theory]
        [MemberData(nameof(TeacherTData.DataForAddTeacherToGroup), MemberType = typeof(TeacherTData))]
        public async Task AddTeacherToGroup_WhenValidTestPassed_ShouldAddTeacherToGroup(Teacher teacher)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Teacher.GetRouteForCreate();
            var createResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(teacher), Encoding.UTF8, "application/json"));



            HttpResponseMessage addTeacherToGroupResponse = new HttpResponseMessage();
            foreach (var group in teacher.Groups)
            {
                var GroupID = group.ID;
                var UserID = teacher.ID;

                var addRoGroupRote = ApiRoutes.Teacher.GetRouteForAddTeacherToGroup(GroupID, UserID);
                addTeacherToGroupResponse = await _client.PostAsync(addRoGroupRote,
                    new StringContent(JsonConvert.SerializeObject(teacher), Encoding.UTF8, "application/json"));
            }

            var getRoute = ApiRoutes.Teacher.GetRouteForGetByID(teacher.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<Teacher>(await getResponse.Content.ReadAsStringAsync());

            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            addTeacherToGroupResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(teacher);
        }

        [Theory]
        [MemberData(nameof(TeacherTData.DataForUpdate), MemberType = typeof(TeacherTData))]
        public async Task AddTeacherToLesson_WhenValidTestPassed_ShouldAddTeacherToLesson(Teacher teacher)
        {
            await TruncateAllTablesAsync();
            await InitializeData();

            var postRoute = ApiRoutes.Teacher.GetRouteForCreate();
            var createResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(teacher), Encoding.UTF8, "application/json"));

            var addLessonRoute = ApiRoutes.Teacher.GetRouteForAddTeacherToLesson(LessonInitData.Lesson.ID, teacher.ID);
            var AddTeacherToLessonResponse = await _client.PostAsync(addLessonRoute,
                new StringContent(JsonConvert.SerializeObject(teacher), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.Teacher.GetRouteForGetByID(teacher.ID);
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<Teacher>(await getResponse.Content.ReadAsStringAsync());

            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(teacher);
        }
        protected async override Task InitializeData()
        {
            using (DbConnection connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                await connection.QueryAsync("CreateCourse", SourceData.InitializeData.CourseInitData.Courses[0]);

                var CourseID = CourseInitData.Courses[0].ID;

                foreach (var group in GroupInitData.Groups)
                {
                    group.ID = group.ID == Guid.Empty ? Guid.NewGuid() : group.ID;


                    await connection.QueryAsync("CreateGroupWithinCourse",
                        parameters: new
                        {
                            group.ID,
                            group.Title,
                            group.StartDate,
                            group.FinishDate,
                            CourseID
                        });
                }

                LessonInitData.Lesson.ID = LessonInitData.Lesson.ID == Guid.Empty ? Guid.NewGuid() : LessonInitData.Lesson.ID;

                await connection.QueryAsync("CreateLessonWithinCourse",
                    parameters: new
                    {
                        LessonInitData.Lesson.ID,
                        LessonInitData.Lesson.Title,
                        LessonInitData.Lesson.Description,
                        LessonInitData.Lesson.DeadLine,
                        CourseID
                    });
            }

        }
    }
}
