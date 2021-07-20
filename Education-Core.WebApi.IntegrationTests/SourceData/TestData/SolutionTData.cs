using Domain.Entities.Solutions;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public static class SolutionTData
    {
        private static Solution _solution;
        static SolutionTData()
        {
            _solution = new Solution()
            {
                ID = Guid.NewGuid(),
                Answer = "Integration test Answer",
                Mark = 10,
                Homework = HomeworkInitData.Homework
            };
        }

        public static IEnumerable<object[]> GetDataForCreate()
        {
            yield return new object[]
            {
                _solution,
                UserInitData.Students[0],
                _solution
            };
        }

        public static IEnumerable<object[]> GetDataForUpdate()
        {
            yield return new object[]
            {
                _solution,
                UserInitData.Students[0]
            };
        }

        public static IEnumerable<object[]> GetDataForDelete()
        {
            yield return new object[]
            {
                _solution,
                UserInitData.Students[0]
            };
        }
    }
}
