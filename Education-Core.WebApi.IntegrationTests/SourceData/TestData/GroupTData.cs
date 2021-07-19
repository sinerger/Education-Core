using Domain.Entities.Groups;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Groups;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public class GroupTData
    {
        private static List<Group> _groups;
        private static Group _group;
        private static readonly int _countGroups = 1;

        static GroupTData()
        {
            _groups = new List<Group>();

            _group = new Group()
            {
                ID = Guid.NewGuid(),
                Course = CourseInitData.Courses[0],
                Title = $"Title",
                StartDate = new DateTime(2020, 08, 09),
                FinishDate = new DateTime(2021, 03, 15)
            };

            for (int i = 0; i < _countGroups; i++)
            {
                _groups.Add(new Group()
                {
                    ID = Guid.NewGuid(),
                    Course = InitializeData.CourseInitData.Courses[0],
                    Title = $"Title{i}",
                    StartDate = new DateTime(2020, 08, 09),
                    FinishDate = new DateTime(2021, 03, 15)
                });
            }
        }

        public static IEnumerable<object[]> DataForCreate()
        {
            //InitializeData();
            foreach (var group in _groups)
            {
                yield return new object[]
                {
                    group,
                    group
                };
            }
        }
        public static IEnumerable<object[]> DataForUpdate()
        {
            //InitializeData();
            foreach (var group in _groups)
            {
                yield return new object[]
                {
                    group
                };
            }
        }

        public static IEnumerable<object[]> DataForGetAllGroups()
        {
            yield return new object[]
            {
                _groups,
                _groups
            };
        }
    }
}
