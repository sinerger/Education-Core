using Domain.Entities.Attendance;
using Domain.Entities.Users;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.AttendanceRepositoryInterfaces
{
    public interface IAttendanceRepository
    {
        [Recordset(typeof(Attendance), typeof(Student))]
        Task<IEnumerable<Attendance>> GetAllAttendanceByLessonIDAsync(Guid lessonID);
        [Recordset(typeof(Attendance), typeof(Student))]
        Task<IEnumerable<Attendance>> GetAllAttendanceByStudentIDAsync(Guid studentID);

        Task CreateAttendanceWithinLessonAsync(Guid lessonID, Attendance attendance);
        Task UpdateAttendanceAsync(Guid lessonID, Attendance attendance);
    }
}
