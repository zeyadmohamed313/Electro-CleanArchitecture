using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Mapper.UserMapping
{
    partial class UserMappingProfile : Profile
    {
        public UserMappingProfile() 
        {
            ApplyValidations();
        }
    }
}
