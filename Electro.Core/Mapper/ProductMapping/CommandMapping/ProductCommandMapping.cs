using AutoMapper;
using Electro.Core.Features.Product.Command.Models;
using Electro.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Mapper.ProductMapping
{
    public partial class ProductMappingProfile : Profile
    {
        public void ProductCommandMapping()
        {
            CreateMap<Product,AddProductModel>().ReverseMap();
            CreateMap<Product, UpdateProductModel>().ReverseMap();

        }
    }
}
