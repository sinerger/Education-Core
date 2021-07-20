using Domain.Entities.Courses;
using Education_Core.WebApi.IntegrationTests.Factories;
using Education_Core.WebApi.IntegrationTests.SourceData.TestData;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.Routes;
using Xunit;

namespace Education_Core.WebApi.IntegrationTests.Tests
{
    public class CourseControllerTests : IntegrationTestAbstract
    {
        public CourseControllerTests(ApiWebApplicationFactory fixture) : base(fixture)
        {
        }

        [Theory]
        [MemberData(nameof(CourseTData.DataForCreate), MemberType = typeof(CourseTData))]
        public async Task CreateCourse_WhenValidTestPassed_ShouldReturnIEnumerableCourse(
            Course course,Course expected)
        {
            await TruncateAllTablesAsync();

            var postResponse = await SendRequesToCreate(course);

            var getResponse = await SendRequesToGetAll();
            var actual = JsonConvert.DeserializeObject<List<Course>>(await getResponse.Content.ReadAsStringAsync());

            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(CourseTData.DataForUpdate), MemberType = typeof(CourseTData))]
        public async Task UpdateCourse_WhenValidTestPassed_ShouldReturnIEnumerableCourse(Course course)
        {
            await TruncateAllTablesAsync();

            var postResponse = await SendRequesToCreate(course);

            course.Title = "New Title";
            course.Description = "New Description";
            var updateRoute = ApiRoutes.Course.GetRouteForUpdate();
            var updateResponce = await _client.PutAsync(updateRoute,
                new StringContent(JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json"));

            var getResponse = await SendRequesToGetAll();
            var actual = JsonConvert.DeserializeObject<List<Course>>(await getResponse.Content.ReadAsStringAsync());

            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            updateResponce.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(course);
        }

        [Theory]
        [MemberData(nameof(CourseTData.DataForUpdate), MemberType = typeof(CourseTData))]
        public async Task DeleteCourse_WhenValidTestPassed_ShouldReturnIEnumerableCourse(Course course)
        {
            await TruncateAllTablesAsync();

            var postResponse = await SendRequesToCreate(course);

            var deleteRoute = ApiRoutes.Course.GetRouteForDelete(course.ID);
            var DeleteResponce = await _client.DeleteAsync(deleteRoute);

            var getResponse = await SendRequesToGetAll();

            postResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            DeleteResponce.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        protected async override Task InitializeData()
        {
        }

        protected override async Task<HttpResponseMessage> SendRequesToCreate(object obj)
        {
            var course = (Course)obj;
            var postRoute = ApiRoutes.Course.GetRouteForCreate();
            var postResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json"));

            return postResponse;
        }

        protected override Task<HttpResponseMessage> SendRequesToGetByID(object obj)
        {
            throw new NotImplementedException();
        }

        protected override async Task<HttpResponseMessage> SendRequesToGetAll()
        {
            var getRoute = ApiRoutes.Course.GetRouteForGetAllCourses();
            var getResponse = await _client.GetAsync(getRoute);

            return getResponse;
        }
    }
}
