using Domain.Entities.Lessons;
using System;

namespace Education_Core.WebApi.IntegrationTests.SourceData.InitializeData
{
    public static class LessonInitData
    {
        public static Lesson Lesson;

        static LessonInitData()
        {
            Lesson = new Lesson()
            {
                ID = Guid.NewGuid(),
                Title = "Integration test Title",
                Description = "Integration test Description",
                DeadLine = new DateTime(2020, 10, 10),
                Teacher = UserInitData.Teacher,
                Course = CourseInitData.Course
            };
        }
    }
}
