using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.FeedbackRepositoryInterfaces;
using Insight.Database;

namespace DataAccess.InsightDatabase.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public IDbConnection DBConnection { get; }
        private IFeedbackRepository _feedbackRepository;

        public FeedbackRepository(IDbConnection dBConnection)
        {
            DBConnection = dBConnection;
            _feedbackRepository = DBConnection.As<IFeedbackRepository>();
        }

        public async Task<bool> CreateFeedbackForUserAsync(Guid userID, Feedback feedback)
        {
            try
            {
                return await _feedbackRepository.CreateFeedbackForUserAsync(userID, feedback);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacksByAuthorIDAsync(Guid userID)
        {
            try
            {
                return await _feedbackRepository.GetAllFeedbacksByAuthorIDAsync(userID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacksByUserIDAsync(Guid userID)
        {
            try
            {
                return await _feedbackRepository.GetAllFeedbacksByUserIDAsync(userID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdateFeedbackAsync(Feedback feedback)
        {
            try
            {
                return await _feedbackRepository.UpdateFeedbackAsync(feedback);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteFeedbackAsync(Guid id)
        {
            try
            {
                return await _feedbackRepository.DeleteFeedbackAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
