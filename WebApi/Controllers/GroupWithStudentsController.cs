using System;
using Domain.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.GroupWithStudents;
using WebApi.Routes;

namespace WebApi.Controllers
{
    [Route(ApiRoutes.Api + ApiRoutes.Controller)]
    [ApiController]
    public class GroupWithStudentsController : ControllerBase
    {
        private readonly IDBContext _dbContext;

        public GroupWithStudentsController(IDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet(ApiRoutes.GroupWithStudents.GetGroupWithStudentsByID)]
        public async Task<GroupWithStudents> GetGroupWithStudentById(Guid id)
        {
            return await _dbContext.GroupWithStudentsRepository.GetGroupWithStudentsByIDAsync(id);
        }
    }
}
