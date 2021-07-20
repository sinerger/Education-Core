using DataAccess.InsightDatabase.Extensions;
using Domain.Entities.Feedbacks;
using Domain.Entities.Users;
using Domain.Interfaces.FeedbackRepositoryInterfaces;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

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

        public async Task CreateFeedbackForUserAsync(Guid authorID, Guid userID, Feedback feedback)
        {
            try
            {
                feedback.ID = feedback.ID == Guid.Empty ? Guid.NewGuid() : feedback.ID;
                await DBConnection.QueryAsync(nameof(CreateFeedbackForUserAsync).GetStoredProcedureName(),
                    new
                    {
                        feedback.ID,
                        feedback.Date,
                        feedback.Description,
                        userID,
                        authorID
                    });
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

        public async Task<UserWithRole> GetAuthorByFeedbackIDAsync(Guid id)
        {
            try
            {
                return await _feedbackRepository.GetAuthorByFeedbackIDAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task UpdateFeedbackAsync(Feedback feedback)
        {
            try
            {
                await _feedbackRepository.UpdateFeedbackAsync(feedback);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteFeedbackAsync(Guid id)
        {
            try
            {
                await _feedbackRepository.DeleteFeedbackAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
