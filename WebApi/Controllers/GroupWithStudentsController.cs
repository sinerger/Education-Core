using Domain.Entities.GroupWithStudents;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApi.Routes;

namespace WebApi.Controllers
{
    [Route(ApiRoutes.Api + ApiRoutes.Controller)]
    [ApiController]
    public class GroupWithStudentsController : ControllerBase
    {
        private readonly IGroupWithStudentsService _groupWithStudentsService;

        public GroupWithStudentsController(IGroupWithStudentsService groupWithStudentsService)
        {
            _groupWithStudentsService = groupWithStudentsService;
        }

        [HttpGet(ApiRoutes.GroupWithStudents.GetGroupWithStudentsByID)]
        public async Task<IActionResult> GetGroupWithStudentById(Guid id)
        {
            var responce = await _groupWithStudentsService.GetGroupWithStudentsByIDAsync(id);

            return GetIActionResult(responce);
        }

        private IActionResult GetIActionResult(IServiceResponce<GroupWithStudents> responce)
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
