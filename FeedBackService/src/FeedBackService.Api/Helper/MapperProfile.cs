using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedBackService.Api.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Infrastructure.Entities.Feedback, Core.Models.Feedback>();
        }

    }
}
