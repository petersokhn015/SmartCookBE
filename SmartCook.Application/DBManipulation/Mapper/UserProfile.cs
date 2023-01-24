using AutoMapper;
using SmartCook.Application.DTO;
using SmartCook.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.DBManipulation.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<RegisterUserDTO, User>().ReverseMap();
            CreateMap<LoginUserDTO, User>().ReverseMap();

        }
    }
}
