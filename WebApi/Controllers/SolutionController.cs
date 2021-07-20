using Domain.Entities.Solutions;
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
    public class SolutionController : ControllerBase
    {
        private readonly ISolutionService _solutionService;

        public SolutionController(ISolutionService solutionService)
        {
            _solutionService = solutionService;
        }

        [HttpGet(ApiRoutes.Solution.GetAllSolutionsByHomeworkID)]
        public async Task<IActionResult> GetAllSolutionsByHomeworkID(Guid homeworkId)
        {
            var responce = await _solutionService.GetAllSolutionsByHomeworkIDAsync(homeworkId);

            return GetIActionResult(responce);
        }

        [HttpGet(ApiRoutes.Solution.GetAllSolutionsByStudentID)]
        public async Task<IActionResult> GetAllSolutionsByStudentID(Guid studentId)
        {
            var responce = await _solutionService.GetAllSolutionsByStudentIDAsync(studentId);

            return GetIActionResult(responce);
        }

        [HttpPost(ApiRoutes.Solution.CreateSolutionWithinHomework)]
        public async Task<IActionResult> CreateSolutionWithinHomework(Guid studentID, Solution solution)
        {
            var responce = await _solutionService.CreateSolutionWithinHomeworkAsync(studentID, solution);

            return GetIActionResult(responce);
        }

        [HttpPut(ApiRoutes.Solution.UpdateSolution)]
        public async Task<IActionResult> UpdateSolution(Solution solution)
        {
            var responce = await _solutionService.UpdateSolutionAsync(solution);

            return GetIActionResult(responce);
        }

        [HttpDelete(ApiRoutes.Solution.DeleteSolution)]
        public async Task<IActionResult> DeleteSolution(Guid id)
        {
            var responce = await _solutionService.DeleteSolutionAsync(id);

            return GetIActionResult(responce);
        }

        private IActionResult GetIActionResult(IServiceResponce<Solution> responce)
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

        private IActionResult GetIActionResult(IServiceResponce<IEnumerable<Solution>> responce)
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
