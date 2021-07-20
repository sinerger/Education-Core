using Domain.Entities.Homeworks;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;
using System;
using System.Collections.Generic;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public static class HomeworkTData
    {
        private static Homework _homework;

        static HomeworkTData()
        {
            _homework = new Homework()
            {
                ID = Guid.NewGuid(),
                Title = "Integration test Title",
                Description = "Integration test Description",
                Deadline = new DateTime(2020, 10, 10)
            };
        }

        public static IEnumerable<object[]> GetDataForCreate()
        {
            yield return new object[]
            {
                    _homework,
                    LessonInitData.Lesson.ID,
                    _homework
            };
        }
        public static IEnumerable<object[]> GetDataForDelete()
        {
            yield return new object[]
            {
                    _homework,
                    LessonInitData.Lesson.ID
            };
        }
        public static IEnumerable<object[]> GetDataForUpdate()
        {
            yield return new object[]
            {
                    _homework,
                    LessonInitData.Lesson.ID
            };
        }

        public static IEnumerable<object[]> GetDataForGetAllByCourseID()
        {
            yield return new object[]
            {
                    _homework,
                    LessonInitData.Lesson.ID,
                    CourseInitData.Course.ID,
                    _homework
            };
        }
    }
}
