using Domain.Entities.Courses;
using System;
using System.Collections.Generic;

namespace Education_Core.WebApi.IntegrationTests.SourceData.InitializeData
{
    public static class CoursesData
    {
        public  static  List<Course> Courses { get; set; }

        static CoursesData()
        {
            Courses = new List<Course>();

            for (int i = 0; i < 3; i++)
            {
                Courses.Add(new Course()
                {
                    ID = Guid.NewGuid(),
                    Title = $"Integratio Test{i}",
                    Description = $"Description{i}"
                });
            }
        }
    }
}
