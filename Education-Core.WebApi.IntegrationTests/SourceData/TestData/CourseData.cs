using Domain.Entities.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public static class CourseData
    {
        private static List<Course> _courses;

        static CourseData()
        {
            _courses = new List<Course>();

            for (int i = 0; i < 3; i++)
            {
                _courses.Add(new Course()
                {
                    ID = Guid.NewGuid(),
                    Title = $"Integratio Test{i}",
                    Description = $"Description{i}"
                });
            }
        }

        public static IEnumerable<object[]> DataForCreate()
        {
            foreach (var course in _courses)
            {
                yield return new object[]
                    {
                        course,
                        course
                    };
            }
        }

        public static IEnumerable<object[]> DataForUpdate()
        {
            foreach (var course in _courses)
            {
                yield return new object[]
                    {
                        course
                    };
            }
        }
    }
}
