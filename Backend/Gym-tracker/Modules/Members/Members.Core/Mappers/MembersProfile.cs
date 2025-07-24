using AutoMapper;
using Members.API.Dtos;
using Members.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Core.Mappers
{
    public class MembersProfile : Profile
    {
        public MembersProfile() 
        {
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
