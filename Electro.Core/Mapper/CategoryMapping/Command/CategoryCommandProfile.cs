using AutoMapper;
using Electro.Core.Features.Category.Command.Models;
using Electro.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Mapper.CategoryMapping
{
    public partial class CategoryMappingProfile : Profile
    {
        private void CategoryCommandMapping()
        {
            CreateMap<Category, AddCategoryModel>().ReverseMap();
            CreateMap<Category, UpdateCategoryModel>().ReverseMap();

        }
    }
}
