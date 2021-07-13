using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Feedbacks;

namespace Domain.Interfaces.FeedbackRepositoryInterfaces
{
    public interface IFeedbackRepository : IRepository
    {
        Task<IEnumerable<Feedback>> GetAllFeedbacksByUserIDAsync(Guid userID);
        Task<IEnumerable<Feedback>> GetAllFeedbacksByAuthorIDAsync(Guid userID);
        Task<bool> CreateFeedbackForUserAsync(Guid userID, Feedback feedback);
        Task<bool> UpdateFeedbackAsync(Feedback feedback);
        Task<bool> DeleteFeedbackAsync(Guid id);
    }
}
