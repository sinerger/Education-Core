﻿using Domain.Entities.Lessons;
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
                Course = InitializeData.CourseInitData.Courses[0],
                Homework = HomeworkInitData.Homework
            };
        }

        public static IEnumerable<object> Lesson { get; internal set; }

        public static IEnumerable<object[]> DataForCreate()
        {
            yield return new object[]
            {
                _lesson,
                _lesson
            };
        }

        public static IEnumerable<object[]> DataForGetAll()
        {
            List<Lesson> lessons = new List<Lesson>();
            lessons.Add(_lesson);

            yield return new object[]
            {
                _lesson,
                lessons
            };
        }

        public static IEnumerable<object[]> DataForUpdate()
        {
            yield return new object[]
            {
                _lesson
            };
        }
    }
}
