using Domain.Entities.Courses;
using System;
using System.Collections.Generic;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public static class CourseTData
    {
        private static Course _course;

        static CourseTData()
        {
            _course = new Course()
            {
                ID = Guid.NewGuid(),
                Title = $"Integratio Test",
                Description = $"Description"
            };

        }

        public static IEnumerable<object[]> DataForCreate()
        {
            yield return new object[]
            {
                _course,
                _course
            };

        }

        public static IEnumerable<object[]> DataForUpdate()
        {
            yield return new object[]
            {
                _course
            };
        }
    }
}
