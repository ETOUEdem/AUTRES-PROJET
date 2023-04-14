using AutoMapper;
using FeedBackService.Core.Interfaces.Repositories;
using FeedBackService.Core.Models;
using FeedBackService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FeedBackService.Infrastructure.Repositories
{

    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly FeedbackDbContext _dbcontext;
        private readonly IMapper _mapper;
        public FeedbackRepository(FeedbackDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<bool> CreateFeedback(Feedback feedback)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFeedback(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacks()
        {
            var dbFeedbacks = await _dbcontext.Feedbacks.ToListAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<Feedback>>(dbFeedbacks);
        }

        public Task<Feedback> GetFeedbackById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
