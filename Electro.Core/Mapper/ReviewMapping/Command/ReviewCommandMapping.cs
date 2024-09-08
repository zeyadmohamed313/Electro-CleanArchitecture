using AutoMapper;
using Electro.Core.Features.Review.Command.Models;
using Electro.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Mapper.ReviewMapping
{
    public partial class ReviewMappingProfile : Profile
    {
        private void ReviewCommandMapping()
        {
            CreateMap<Review, AddReviewModel>().ReverseMap();
            CreateMap<Review, UpdateReviewModel>().ReverseMap();
        }
    }
}
