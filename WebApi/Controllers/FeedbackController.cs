using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : Controller
    {
        private readonly IDBContext _dBContext;

        public FeedbackController(IDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        [HttpPost]
        public async Task<bool> CreateFeedbackForUserAsync(Guid userID, Feedback feedback)
        {
            return await _dBContext.FeedbackRepository.CreateFeedbackForUserAsync(userID, feedback);
        }

        [HttpGet("authorid")]
        public async Task<IEnumerable<Feedback>> GetAllFeedbacksByAuthorIDAsync(Guid userID)
        {
            return await _dBContext.FeedbackRepository.GetAllFeedbacksByAuthorIDAsync(userID);
        }

        [HttpGet("userid")]
        public async Task<IEnumerable<Feedback>> GetAllFeedbacksByUserIDAsync(Guid userID)
        {
            return await _dBContext.FeedbackRepository.GetAllFeedbacksByUserIDAsync(userID);
        }

        [HttpPut]
        public async Task<bool> UpdateFeedbackAsync(Feedback feedback)
        {
            return await _dBContext.FeedbackRepository.UpdateFeedbackAsync(feedback);
        }

        [HttpDelete("id")]
        public async Task<bool> DeleteFeedbackAsync(Guid id)
        {
            return await _dBContext.FeedbackRepository.DeleteFeedbackAsync(id);
        }
    }
}
