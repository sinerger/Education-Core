using System;
using Domain.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.GroupWithStudents;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupWithStudentsController : ControllerBase
    {
        private readonly IDBContext _dbContext;

        public GroupWithStudentsController(IDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpGet("{id}")]
        public async Task<GroupWithStudent> GetGroupWithStudentById(Guid id)
        {
            return await _dbContext.GroupWithStudentRepository.GetGroupWithStudentByIDAsync(id);
        }
    }
}
