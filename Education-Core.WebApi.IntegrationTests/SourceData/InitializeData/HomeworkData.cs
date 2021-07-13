using Domain.Entities.Homeworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Core.WebApi.IntegrationTests.SourceData.InitializeData
{
    public static class HomeworkData
    {
        public static Homework Homework { get; set; }

        static HomeworkData()
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
