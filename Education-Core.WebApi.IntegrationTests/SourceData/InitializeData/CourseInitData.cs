using Domain.Entities.Courses;
using System;
using System.Collections.Generic;

namespace Education_Core.WebApi.IntegrationTests.SourceData.InitializeData
{
    public static class CourseInitData
    {
        public static Course Course { get; set; }

        static CourseInitData()
        {
            Course = new Course()
            {
                ID = Guid.NewGuid(),
                Title = $"Integratio Test",
                Description = $"Description"
            };
        }
    }
}
