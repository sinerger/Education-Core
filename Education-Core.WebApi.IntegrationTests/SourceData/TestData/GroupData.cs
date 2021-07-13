using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Groups;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public class GroupData 
    {
        private static List<Group> _groups;
        private static readonly int _countGroups = 1;

        static GroupData()
        {
            _groups = new List<Group>();

            for (int i = 0; i < _countGroups; i++)
            {
                _groups.Add(new Group()
                {
                    ID = Guid.NewGuid(),
                    Course = CourseData.Courses[0],
                    Title = $"Title{i}",
                    StartDate = new DateTime(2020,08,09),
                    FinishDate = new DateTime(2021,03,15)
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
