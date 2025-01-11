using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Mapper.BlogMapping
{
    public partial class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            BlogCommandMapping();
        }
    }
}
