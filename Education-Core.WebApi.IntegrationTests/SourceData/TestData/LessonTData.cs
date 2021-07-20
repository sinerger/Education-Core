using Domain.Entities.Lessons;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;
using System;
using System.Collections.Generic;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public static class LessonTData
    {
        private static Lesson _lesson;

        static LessonTData()
        {
            _lesson = new Lesson()
            {
                ID = Guid.NewGuid(),
                Title = "Integration test Title",
                Description = "Integration test Description",
                DeadLine = new DateTime(2020, 10, 10),
                Teacher = UserInitData.Teacher,
                Course = CourseInitData.Course,
                Homework = HomeworkInitData.Homework
            };
        }


        public static IEnumerable<object[]> GetDataForCreate()
        {
            yield return new object[]
            {
                _lesson,
                _lesson
            };
        }

        public static IEnumerable<object[]> GetDataForGetAll()
        {
            List<Lesson> lessons = new List<Lesson>() { _lesson };

            yield return new object[]
            {
                _lesson,
                lessons
            };
        }

        public static IEnumerable<object[]> GetDataForUpdate()
        {
            yield return new object[]
            {
                _lesson
            };
        }
    }
}
