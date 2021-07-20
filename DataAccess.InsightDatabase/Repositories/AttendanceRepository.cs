using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Attendance;
using Domain.Interfaces.AttendanceRepositoryInterfaces;
using Insight.Database;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess.InsightDatabase.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly IAttendanceRepository _attendanceRepository;
        public IDbConnection DBConnection { get; }

        public AttendanceRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _attendanceRepository = DBConnection.As<IAttendanceRepository>();
        }

        public async Task CreateAttendanceWithinLessonAsync(Guid lessonID, Attendance attendance)
        {
            try
            {
                var studentID = attendance.Student.ID;

                await DBConnection.QueryAsync(nameof(UpdateAttendanceAsync).GetStoredProcedureName(),
                    parameters: new
                    {
                        lessonID,
                        studentID,
                        attendance.IsVisited
                    });
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendanceByLessonIDAsync(Guid lessonID)
        {
            try
            {
                return await _attendanceRepository.GetAllAttendanceByLessonIDAsync(lessonID);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendanceByStudentIDAsync(Guid studentID)
        {
            try
            {
                return await _attendanceRepository.GetAllAttendanceByStudentIDAsync(studentID);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }

        public async Task UpdateAttendanceAsync(Guid lessonID, Attendance attendance)
        {
            try
            {
                var studentID = attendance.Student.ID;

                await DBConnection.QueryAsync(nameof(UpdateAttendanceAsync).GetStoredProcedureName(),
                    parameters: new
                    {
                        lessonID,
                        studentID,
                        attendance.IsVisited
                    });
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());

                throw e;
            }
        }
    }
}
