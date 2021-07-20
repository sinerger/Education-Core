using Domain.Entities.Feedbacks;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IFeedbackServise
    {
        Task<IServiceResponce<IEnumerable<Feedback>>> GetAllFeedbacksByUserIDAsync(Guid userID);
        Task<IServiceResponce<UserWithRole>> GetAuthorByFeedbackIDAsync(Guid id);
        Task<IServiceResponce<bool>> CreateFeedbackForUserAsync(Guid authorID, Guid userID, Feedback feedback);
        Task<IServiceResponce<bool>> UpdateFeedbackAsync(Feedback feedback);
        Task<IServiceResponce<bool>> DeleteFeedbackAsync(Guid id);
    }
}
