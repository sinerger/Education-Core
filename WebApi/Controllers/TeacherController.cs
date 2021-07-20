using Domain.Entities.Users;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebApi.Routes;

namespace WebApi.Controllers
{
    [Authorize]
    [Route(ApiRoutes.Api + ApiRoutes.Controller)]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet(ApiRoutes.Teacher.GetAllTeachers)]
        public async Task<IActionResult> GetAllTeachers()
        {
            var responce = await _teacherService.GetAllTeachersAsync();

            return GetIActionResult(responce);
        }

        [HttpGet(ApiRoutes.Teacher.GetTeacherByID)]
        public async Task<IActionResult> GetTeacherByID(Guid id)
        {
            var responce = await _teacherService.GetTeacherByIDAsync(id);

            return GetIActionResult(responce);
        }

        [HttpPost(ApiRoutes.Teacher.AddTeacherToGroup)]
        public async Task<IActionResult> AddTeacherToGroup(Guid groupID, Guid userID)
        {
            var responce = await _teacherService.AddTeacherToGroupAsync(groupID, userID);

            return GetIActionResult(responce);
        }

        [HttpPost(ApiRoutes.Teacher.AddTeacherToLesson)]
        public async Task<IActionResult> AddTeacherToLesson(Guid groupID, Guid teacherID)
        {
            var responce = await _teacherService.AddTeacherToLessonAsync(groupID, teacherID);

            return GetIActionResult(responce);
        }

        [HttpPost(ApiRoutes.Teacher.CreateTeacher)]
        public async Task<IActionResult> CreateTeacher(Teacher teacher)
        {
            var responce = await _teacherService.CreateTeacherAsync(teacher);

            return GetIActionResult(responce);
        }

        [HttpPut(ApiRoutes.Teacher.UpdateTeacher)]
        public async Task<IActionResult> UpdateTeacher(Teacher teacher)
        {
            var responce = await _teacherService.UpdateTeacherAsync(teacher);

            return GetIActionResult(responce);
        }

        [HttpDelete(ApiRoutes.Teacher.DeleteTeacher)]
        public async Task<IActionResult> DeleteTeacher(Guid id)
        {
            var responce = await _teacherService.DeleteTeacherAsync(id);

            return GetIActionResult(responce);
        }

        private IActionResult GetIActionResult(IServiceResponce<Teacher> responce)
        {
            IActionResult result = null;

            if (responce.IsSuccessfully)
            {
                result = Ok(responce.Result);
            }
            else
            {
                result = BadRequest(responce.Message);
            }

            return result;
        }

        private IActionResult GetIActionResult(IServiceResponce<IEnumerable<Teacher>> responce)
        {
            IActionResult result = null;

            if (responce.IsSuccessfully)
            {
                result = Ok(responce.Result);
            }
            else
            {
                result = BadRequest(responce.Message);
            }

            return result;
        }

        private IActionResult GetIActionResult(IServiceResponce<bool> responce)
        {
            IActionResult result = null;

            if (responce.IsSuccessfully)
            {
                result = Ok(responce.Result);
            }
            else
            {
                result = BadRequest(responce.Message);
            }

            return result;
        }
    }
}
