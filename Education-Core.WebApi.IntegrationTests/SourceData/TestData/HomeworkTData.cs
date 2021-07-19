using Domain.Entities.Homeworks;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public static class HomeworkTData
    {
        public static Homework Homework { get; }

        static HomeworkTData()
        {
            Homework = new Homework()
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
                    Homework,
                    LessonInitData.Lesson.ID,
                    Homework
            };
        }
        public static IEnumerable<object[]> GetDataForDelete()
        {
            yield return new object[]
            {
                    Homework,
                    LessonInitData.Lesson.ID
            };
        }
        public static IEnumerable<object[]> GetDataForUpdate()
        {
            yield return new object[]
            {
                    Homework,
                    LessonInitData.Lesson.ID
            };
        }

        public static IEnumerable<object[]> GetDataForGetAllByCourseID()
        {
            var homeworks = new List<Homework>() { Homework };
            yield return new object[]
            {
                    Homework,
                    LessonInitData.Lesson.ID,
                    CourseInitData.Courses[0].ID,
                    Homework
            };
        }
    }
}
