using Domain.Entities.Feedbacks;
using Domain.Entities.Users;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Routes;

namespace WebApi.Controllers
{
    [Route(ApiRoutes.Api + ApiRoutes.Controller)]
    [ApiController]
    public class FeedbackController : Controller
    {
        private readonly IDBContext _dBContext;

        public FeedbackController(IDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        [HttpPost(ApiRoutes.Feedback.CreateFeedbackForUser)]
        public async Task CreateFeedbackForUserAsync(Guid authorID, Guid userID, Feedback feedback)
        {
            await _dBContext.FeedbackRepository.CreateFeedbackForUserAsync(authorID, userID, feedback);
        }

        [HttpGet(ApiRoutes.Feedback.GetAllFeedbacksByUserID)]
        public async Task<IEnumerable<Feedback>> GetAllFeedbacksByUserIDAsync(Guid userID)
        {
            return await _dBContext.FeedbackRepository.GetAllFeedbacksByUserIDAsync(userID);
        }

        [HttpGet(ApiRoutes.Feedback.GetAuthorByFeedbackID)]
        public async Task<UserWithRole> GetAuthorByFeedbackIDAsync(Guid feedbackID)
        {
            return await _dBContext.FeedbackRepository.GetAuthorByFeedbackIDAsync(feedbackID);
        }

        [HttpPut(ApiRoutes.Feedback.UpdateFeedback)]
        public async Task UpdateFeedbackAsync(Feedback feedback)
        {
            await _dBContext.FeedbackRepository.UpdateFeedbackAsync(feedback);
        }

        [HttpDelete(ApiRoutes.Feedback.DeleteFeedback)]
        public async Task DeleteFeedbackAsync(Guid id)
        {
            await _dBContext.FeedbackRepository.DeleteFeedbackAsync(id);
        }
    }
}
