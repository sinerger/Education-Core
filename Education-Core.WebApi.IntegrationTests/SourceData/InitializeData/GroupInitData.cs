using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Groups;

namespace Education_Core.WebApi.IntegrationTests.SourceData.InitializeData
{
    public class GroupInitData
    {
        public static List<Group> Groups { get; set; }
        private static readonly int _countGroups = 1;
        static  GroupInitData()
        {
            Groups = new List<Group>();
            for (int i = 0; i < _countGroups; i++)
            {
                Groups.Add(new Group()
                {
                    ID = Guid.NewGuid(),
                    Course = InitializeData.CourseInitData.Courses[0],
                    Title = $"Title{i}",
                    StartDate = new DateTime(2020, 08, 09),
                    FinishDate = new DateTime(2021, 03, 15)
                });
            }
        }
    }
}
