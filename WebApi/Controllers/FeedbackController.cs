using Domain.Entities.Feedbacks;
using Domain.Entities.Users;
using Domain.Interfaces;
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
    public class FeedbackController : Controller
    {
        private readonly IFeedbackServise _feedbackServise;

        public FeedbackController(IFeedbackServise feedbackServise)
        {
            _feedbackServise = feedbackServise;
        }

        [HttpPost(ApiRoutes.Feedback.CreateFeedbackForUser)]
        public async Task<IActionResult> CreateFeedbackForUser(Guid authorID, Guid userID, Feedback feedback)
        {
            var responce = await _feedbackServise.CreateFeedbackForUserAsync(authorID, userID, feedback);

            return GetIActionResult(responce);
        }

        [HttpGet(ApiRoutes.Feedback.GetAllFeedbacksByUserID)]
        public async Task<IActionResult> GetAllFeedbacksByUserID(Guid userID)
        {
            var responce = await _feedbackServise.GetAllFeedbacksByUserIDAsync(userID);

            return GetIActionResult(responce);
        }

        [HttpGet(ApiRoutes.Feedback.GetAuthorByFeedbackID)]
        public async Task<IActionResult> GetAuthorByFeedbackID(Guid feedbackID)
        {
            var responce = await _feedbackServise.GetAuthorByFeedbackIDAsync(feedbackID);

            return GetIActionResult(responce);
        }

        [HttpPut(ApiRoutes.Feedback.UpdateFeedback)]
        public async Task<IActionResult> UpdateFeedback(Feedback feedback)
        {
            var responce = await _feedbackServise.UpdateFeedbackAsync(feedback);

            return GetIActionResult(responce);
        }

        [HttpDelete(ApiRoutes.Feedback.DeleteFeedback)]
        public async Task<IActionResult> DeleteFeedback(Guid id)
        {
            var responce = await _feedbackServise.DeleteFeedbackAsync(id);

            return GetIActionResult(responce);
        }

        private IActionResult GetIActionResult(IServiceResponce<Feedback> responce)
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

        private IActionResult GetIActionResult(IServiceResponce<UserWithRole> responce)
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

        private IActionResult GetIActionResult(IServiceResponce<IEnumerable<Feedback>> responce)
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
