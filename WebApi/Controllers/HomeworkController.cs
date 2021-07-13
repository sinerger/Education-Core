using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.Homeworks;
using Domain.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly IDBContext _dbContext;

        public HomeworkController(IDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Homework>> GetHomeworks()
        {
            return await _dbContext.HomeworkRepository.GetHomeworkAsync();
        }

        [HttpGet("{id}")]
        public async Task<Homework> GetHomeworkById(Guid id)
        {
            return await _dbContext.HomeworkRepository.GetHomeworkByIdAsync(id);
        }

        [HttpPost]
        public async Task<bool> GreateHomework(Homework homework)
        {
            return await _dbContext.HomeworkRepository.CreateHomeworkAsync(homework);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteHomework(Guid id)
        {
            return await _dbContext.HomeworkRepository.DeleteHomeworkAsync(id);
        }

        [HttpPut]
        public async Task<bool> UpdateHomework(Homework homework)
        {
            return await _dbContext.HomeworkRepository.UpdateHomeworkAsync(homework);
        }
    }
}
