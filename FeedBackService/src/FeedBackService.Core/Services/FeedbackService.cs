using FeedBackService.Core.Interfaces.Repositories;
using FeedBackService.Core.Interfaces.Services;
using FeedBackService.Core.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FeedBackService.Core.Services
{
    public class FeedbackService : IFeedbackService
    {
        public readonly IFeedbackRepository _feedbackRepository;
        private readonly ILogger<FeedbackService> _logger;
        public FeedbackService(IFeedbackRepository feedbackRepository, ILogger<FeedbackService> logger)
        {
            _feedbackRepository = feedbackRepository ?? throw new ArgumentNullException(nameof(feedbackRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<bool> CreateFeedback(Feedback feedback)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteFeedback(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacks()
        {
            try
            {
                throw new ArgumentException("ffff");
                return await _feedbackRepository.GetAllFeedbacks();
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while trying to call GetAllFeedbacks, Error Message ={exception}");
                throw;
            }

        }

        public Task<Feedback> GetFeedbackById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
