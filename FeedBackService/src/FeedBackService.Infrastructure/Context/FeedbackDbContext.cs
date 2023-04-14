using FeedBackService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedBackService.Infrastructure.Context
{
    public class FeedbackDbContext : DbContext
    {
        public FeedbackDbContext(DbContextOptions<FeedbackDbContext> option) : base(option)
        {
            SeedDate();
        }

        public virtual DbSet<Feedback> Feedbacks { get; set; }

        private void SeedDate()
        {
            var feedbacks = new List<Feedback>()
            {
                new Feedback(){Id=1 ,Subject=".NET core 5 web Api", Message="Excellent",CreatedBy ="ETOU",CreatedDate=  DateTime.Now,IUserId= Guid.NewGuid(),Rating=3},
                 new Feedback(){Id=2 ,Subject="Microservice", Message="Cool",CreatedBy ="Edem",CreatedDate=  DateTime.Now,IUserId= Guid.NewGuid(),Rating=3},
                  new Feedback(){Id=3 ,Subject="Azure cloud", Message="tres Excellent",CreatedBy ="Koffi",CreatedDate=  DateTime.Now,IUserId= Guid.NewGuid(),Rating=3}
            };
            Feedbacks.AddRange(feedbacks);
            SaveChanges();

        }
    }

}
