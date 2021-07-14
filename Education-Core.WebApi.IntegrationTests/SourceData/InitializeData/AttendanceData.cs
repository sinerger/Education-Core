using Domain.Entities.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Core.WebApi.IntegrationTests.SourceData.InitializeData
{
    public static class AttendanceData
    {
        private const int lenght = 3; 
        public static List<Attendance> Attendance { get; }

        static AttendanceData()
        {
            Attendance = new List<Attendance>();
            for (int i = 0; i < lenght; i++)
            {
                Attendance.Add(new Attendance()
                {
                    Student = UserData.Students[i],
                    IsVisited = i % 2 == 0 ? true : false
                });
            }
        }
    }
}
