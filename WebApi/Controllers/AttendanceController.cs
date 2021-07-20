using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using WebApi.Routes;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Entities.Attendance;
using System;
using Serilog;

namespace WebApi.Controllers
{
    [Route(ApiRoutes.Api + ApiRoutes.Controller)]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IDBContext _dbContext;

        public AttendanceController(IDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet(ApiRoutes.Attendance.GetAllAttendanceByLessonID)]
        public async Task<IEnumerable<Attendance>> GetAllAttendanceByLessonIDAsync(Guid lessonID)
        {
            return await _dbContext.AttendanceRepository.GetAllAttendanceByLessonIDAsync(lessonID);
        }

        [HttpGet(ApiRoutes.Attendance.GetAllAttendanceByStudentID)]
        public async Task<IEnumerable<Attendance>> GetAllAttendanceByStudentIDAsync(Guid studentID)
        {
            return await _dbContext.AttendanceRepository.GetAllAttendanceByStudentIDAsync(studentID);
        }

        [HttpPost(ApiRoutes.Attendance.CreateAttendanceWithinLesson)]
        public async Task CreateAttendanceWithinLessonAsync(Guid lessonID, Attendance attendance)
        {
            try
            {
                await _dbContext.AttendanceRepository.CreateAttendanceWithinLessonAsync(lessonID, attendance);
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.ToString());
            }
        }

        [HttpPut(ApiRoutes.Attendance.UpdateAttendance)]
        public async Task UpdateAttendanceAsync(Guid lessonID, Attendance attendance)
        {
            await _dbContext.AttendanceRepository.UpdateAttendanceAsync(lessonID, attendance);
        }

    }
}
