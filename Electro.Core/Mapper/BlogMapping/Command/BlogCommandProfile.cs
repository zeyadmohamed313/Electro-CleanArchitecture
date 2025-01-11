using AutoMapper;
using Electro.Core.Features.Blog.Command.Models;
using Electro.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Mapper.BlogMapping
{
    public partial class BlogMappingProfile : Profile
    {
        private void BlogCommandMapping()
        {
            CreateMap<AddBlogModel,Blog>().ReverseMap();
        }
    }
}
