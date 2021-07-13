using Domain.Entities.Groups;
using System;
using System.Collections.Generic;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public class GroupData
    {
        private static List<Group> _groups;
        private static Group _group;
        private static readonly int _countGroups = 1;

        static GroupData()
        {
            _groups = new List<Group>();

            _group = new Group()
            {
                ID = Guid.NewGuid(),
                Course = CoursesData.Courses[0],
                Title = $"Title",
                StartDate = new DateTime(2020, 08, 09),
                FinishDate = new DateTime(2021, 03, 15)
            };

            for (int i = 0; i < _countGroups; i++)
            {
                _groups.Add(new Group()
                {
                    ID = Guid.NewGuid(),
                    Course = InitializeData.CoursesData.Courses[0],
                    Title = $"Title{i}",
                    StartDate = new DateTime(2020, 08, 09),
                    FinishDate = new DateTime(2021, 03, 15)
                });
            }
        }

        public static IEnumerable<object[]> DataForCreate()
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
        public static IEnumerable<object[]> DataForUpdate()
        {
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
