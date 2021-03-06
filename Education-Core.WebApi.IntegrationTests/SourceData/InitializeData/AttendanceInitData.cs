using Domain.Entities.Lessons;
using System.Collections.Generic;

namespace Education_Core.WebApi.IntegrationTests.SourceData.InitializeData
{
    public static class AttendanceInitData
    {
        private const int lenght = 3;
        public static List<Attendance> Attendance { get; }

        static AttendanceInitData()
        {
            Attendance = new List<Attendance>();
            for (int i = 0; i < lenght; i++)
            {
                Attendance.Add(new Attendance()
                {
                    Student = UserInitData.Students[i],
                    IsVisited = i % 2 == 0 ? true : false
                });
            }
        }
    }
}
