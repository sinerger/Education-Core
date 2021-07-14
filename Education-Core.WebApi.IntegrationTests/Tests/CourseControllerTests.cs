using Domain.Entities.Courses;
using Education_Core.WebApi.IntegrationTests.Factories;
using Education_Core.WebApi.IntegrationTests.SourceData;
using Education_Core.WebApi.IntegrationTests.SourceData.TestData;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [MemberData(nameof(CourseData.DataForCreate), MemberType = typeof(CourseData))]
        public async Task CreateCourse_WhenValidTestPassed_ShouldReturnIEnumerableCourse(
            Course insertedCourse,Course expected)
        {
            await TruncateAllTablesAsync();

            var postRoute = ApiRoutes.Course.GetRouteForCreate();
            var createResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(insertedCourse), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.Course.GetRouteForGetAllCourses();
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<List<Course>>(await getResponse.Content.ReadAsStringAsync());

            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(CourseData.DataForUpdate), MemberType = typeof(CourseData))]
        public async Task UpdateCourse_WhenValidTestPassed_ShouldReturnIEnumerableCourse(Course course)
        {
            await TruncateAllTablesAsync();

            var postRoute = ApiRoutes.Course.GetRouteForCreate();
            var createResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json"));

            course.Title = "New Title";
            course.Description = "New Description";
            var updateRoute = ApiRoutes.Course.GetRouteForUpdate();
            var updateResponce = await _client.PutAsync(updateRoute,
                new StringContent(JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json"));

            var getRoute = ApiRoutes.Course.GetRouteForGetAllCourses();
            var getResponse = await _client.GetAsync(getRoute);
            var actual = JsonConvert.DeserializeObject<List<Course>>(await getResponse.Content.ReadAsStringAsync());

            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            updateResponce.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            actual.Should().BeEquivalentTo(course);
        }

        [Theory]
        [MemberData(nameof(CourseData.DataForUpdate), MemberType = typeof(CourseData))]
        public async Task DeleteCourse_WhenValidTestPassed_ShouldReturnIEnumerableCourse(Course deleteCourse)
        {
            await TruncateAllTablesAsync();

            var postRoute = ApiRoutes.Course.GetRouteForCreate();
            var createResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(deleteCourse), Encoding.UTF8, "application/json"));

            var deleteRoute = ApiRoutes.Course.GetRouteForDelete(deleteCourse.ID);
            var DeleteResponce = await _client.DeleteAsync(deleteRoute);

            var getRoute = ApiRoutes.Course.GetRouteForGetAllCourses();
            var getResponse = await _client.GetAsync(getRoute);
           
            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            DeleteResponce.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        protected async override Task InitializeData()
        {
        }
    }
}
