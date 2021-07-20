using Domain.Entities.Homeworks;
using System;

namespace Education_Core.WebApi.IntegrationTests.SourceData.InitializeData
{
    public static class HomeworkInitData
    {
        public static Homework Homework { get; set; }

        static HomeworkInitData()
        {
            Homework = new Homework()
            {
                ID = Guid.NewGuid(),
                Title = "Integration test Title",
                Description = "Integration test Description",
                Deadline = new DateTime(2020, 10, 10)
            };
        }
    }
}
