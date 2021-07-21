using Domain.Entities.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Core.WebApi.IntegrationTests.SourceData.InitializeData
{
    public class SolutionInitData
    {
        public static List<Solution> Solutions { get; set; }
        private static readonly int _countSolutions = 3;

        static SolutionInitData()
        {
            Solutions = new List<Solution>();
            for (int i = 0; i < _countSolutions; i++)
            {
                Solutions.Add(new Solution()
                {
                    ID = Guid.NewGuid(),
                    Answer = $"integration test answer{i}",
                    Mark = i,
                    Homework = HomeworkInitData.Homework
                });
            }
        }
    }
}
