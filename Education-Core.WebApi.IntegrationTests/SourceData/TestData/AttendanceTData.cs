using Domain.Entities.Lessons;
using Education_Core.WebApi.IntegrationTests.SourceData.InitializeData;
using System;
using System.Collections.Generic;

namespace Education_Core.WebApi.IntegrationTests.SourceData.TestData
{
    public static class AttendanceTData
    {
        private static List<Attendance> _attendance;

        static AttendanceTData()
        {
            _attendance = new List<Attendance>();

            _attendance.Add(new Attendance
            {
                Student = UserInitData.Students[0],
                IsVisited = true
            });
        }

        public static IEnumerable<object[]> DataForCreate()
        {
            foreach (var attendance in _attendance)
            {
                yield return new object[]
                {
                    attendance,
                    attendance
                };
            }
        }
    }
}