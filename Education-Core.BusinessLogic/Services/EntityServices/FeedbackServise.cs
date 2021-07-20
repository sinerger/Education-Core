using Domain.Entities.Feedbacks;
using Domain.Entities.Users;
using Domain.Interfaces;
using Domain.Interfaces.FeedbackRepositoryInterfaces;
using Domain.Interfaces.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Education_Core.BusinessLogic.Services.EntityServices
{
    public class FeedbackServise : IFeedbackServise
    {
        private IFeedbackRepository _feedbackRepository;

        public FeedbackServise(IDBContext dbContext)
        {
            _feedbackRepository = dbContext.FeedbackRepository;
        }

        public async Task<IServiceResponce<bool>> CreateFeedbackForUserAsync(Guid authorID, Guid userID, Feedback feedback)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _feedbackRepository.CreateFeedbackForUserAsync(authorID, userID, feedback);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(FeedbackServise) + nameof(CreateFeedbackForUserAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<bool>> DeleteFeedbackAsync(Guid id)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _feedbackRepository.DeleteFeedbackAsync(id);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(FeedbackServise) + nameof(DeleteFeedbackAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<IEnumerable<Feedback>>> GetAllFeedbacksByUserIDAsync(Guid userID)
        {
            var responce = new ServiceResponce<IEnumerable<Feedback>>();

            try
            {
                responce.SetValidResponce(obj: await _feedbackRepository.GetAllFeedbacksByUserIDAsync(userID));
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(FeedbackServise) + nameof(GetAllFeedbacksByUserIDAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<UserWithRole>> GetAuthorByFeedbackIDAsync(Guid id)
        {
            var responce = new ServiceResponce<UserWithRole>();

            try
            {
                responce.SetValidResponce(obj: await _feedbackRepository.GetAuthorByFeedbackIDAsync(id));
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(FeedbackServise) + nameof(GetAuthorByFeedbackIDAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }

        public async Task<IServiceResponce<bool>> UpdateFeedbackAsync(Feedback feedback)
        {
            var responce = new ServiceResponce<bool>();

            try
            {
                await _feedbackRepository.UpdateFeedbackAsync(feedback);
                responce.SetValidResponce(obj: true);
            }
            catch (Exception e)
            {
                Log.Logger.Error(nameof(FeedbackServise) + nameof(UpdateFeedbackAsync) + e.ToString());
                responce.SetInvalidResponce(e);
            }

            return responce;
        }
    }
}
