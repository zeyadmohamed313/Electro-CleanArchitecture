using AutoMapper;
using Electro.Core.Features.User.Command.Models;
using Electro.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Mapper.UserMapping
{
    partial class UserMappingProfile : Profile
    {
        private void ApplyValidations()
        {
            CreateMap<User, AddUserModel>().ReverseMap();
            CreateMap<User, UpdateUserModel>().ReverseMap();
        }
    }
}
