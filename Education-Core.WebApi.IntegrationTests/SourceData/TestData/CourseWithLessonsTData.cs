using Domain.Entities.Courses;
using Domain.Entities.Lessons;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;
using System.Collections.Generic;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public static class CourseWithLessonsTData
    {
        private static CourseWithLessons _courseWithLesson;
        static CourseWithLessonsTData()
        {
            _courseWithLesson = new CourseWithLessons()
            {
                ID = CourseInitData.Courses[0].ID,
                Title = CourseInitData.Courses[0].Title,
                Description = CourseInitData.Courses[0].Description,
                Lessons = new List<Lesson>()
                {
                    LessonInitData.Lesson
                }
            };
        }

        public static IEnumerable<object[]> GetDataForGetById()
        {
            yield return new object[]
                {
                    _courseWithLesson
                };
        }
    }
}
