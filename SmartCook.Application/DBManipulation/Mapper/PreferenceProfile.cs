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
    public class PreferenceProfile : Profile
    {
        public PreferenceProfile()
        {
            CreateMap<Preferences, PreferencesDTO>().ReverseMap();
        }
    }
}
