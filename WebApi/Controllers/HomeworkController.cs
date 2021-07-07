using Domain.Entities.Homeworks;
using Domain.Interfaces.HomeworkRepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly IHomeworkUnitOfWork _homeworkUnitOfWork;

        public HomeworkController(IHomeworkUnitOfWork homeworkUnitOfWork)
        {
            _homeworkUnitOfWork = homeworkUnitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Homework>> GetHomeworks()
        {
            return (IEnumerable<Homework>)await _homeworkUnitOfWork.HomeworkRepository.GetHomeworkAsync();
        }

        [HttpGet("id")]
        public async Task<Homework> GetHomeworkById(Guid id)
        {
            return await _homeworkUnitOfWork.HomeworkRepository.GetHomeworkByIdAsync(id);
        }

        [HttpPost]
        public async Task<bool> GreateHomework(Homework homework)
        {
            return await _homeworkUnitOfWork.HomeworkRepository.CreateHomeworkAsync(homework);
        }

        [HttpDelete("id")]
        public async Task<bool> DeleteHomework(Guid id)
        {
            return await _homeworkUnitOfWork.HomeworkRepository.DeleteHomeworkAsync(id);
        }

        [HttpPut]
        public async Task<bool> UpdateHomework(Homework homework)
        {
            return await _homeworkUnitOfWork.HomeworkRepository.UpdateHomeworkAsync(homework);
        }
    }
}
