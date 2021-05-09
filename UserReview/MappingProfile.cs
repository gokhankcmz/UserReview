using AutoMapper;
using Entities;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserReview
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Review, PublicReview>();
        }
    }
}
