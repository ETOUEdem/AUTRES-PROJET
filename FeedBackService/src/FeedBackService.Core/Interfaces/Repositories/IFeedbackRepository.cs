using FeedBackService.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FeedBackService.Core.Interfaces.Repositories
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetAllFeedbacks();
        Task<Feedback> GetFeedbackById(int id);

        Task<bool> CreateFeedback(Feedback feedback);

        Task<bool> DeleteFeedback(int id);
    }
}
