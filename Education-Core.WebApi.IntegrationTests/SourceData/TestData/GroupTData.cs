using Domain.Entities.Groups;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;
using System;
using System.Collections.Generic;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public class GroupTData
    {
        private static List<Group> _groups;
        private static readonly int _countGroups = 1;

        static GroupTData()
        {
            _groups = new List<Group>();

            for (int i = 0; i < _countGroups; i++)
            {
                _groups.Add(new Group()
                {
                    ID = Guid.NewGuid(),
                    Course = CourseInitData.Course,
                    Title = $"Title {i}",
                    StartDate = new DateTime(2020, 08, 09),
                    FinishDate = new DateTime(2021, 03, 15)
                });
            }
        }

        public static IEnumerable<object[]> GetDataForCreate()
        {
            foreach (var group in _groups)
            {
                yield return new object[]
                {
                    group,
                    group
                };
            }
        }
        public static IEnumerable<object[]> GetDataForUpdate()
        {
            foreach (var group in _groups)
            {
                yield return new object[]
                {
                    group
                };
            }
        }

        public static IEnumerable<object[]> GetDataForGetAllGroups()
        {
            yield return new object[]
            {
                _groups,
                _groups
            };
        }
    }
}
