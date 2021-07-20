using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities.Feedbacks;
using Domain.Entities.Users;
using Insight.Database;

namespace Domain.Interfaces.FeedbackRepositoryInterfaces
{
    public interface IFeedbackRepository : IRepository
    {
        [Recordset(typeof(Feedback), typeof(UserWithRole))]
        Task<IEnumerable<Feedback>> GetAllFeedbacksByUserIDAsync(Guid userID);
        Task<UserWithRole> GetAuthorByFeedbackIDAsync(Guid id);
        Task CreateFeedbackForUserAsync(Guid authorID, Guid userID, Feedback feedback);
        Task UpdateFeedbackAsync(Feedback feedback);
        Task DeleteFeedbackAsync(Guid id);
    }
}
