using AutoMapper;
using SmartCook.Domain.DBEntities;
using SmartCook.Domain.SpoonacularEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Spoonacular.Mapper
{
    public class SpoonacularPreferencesProfile : Profile
    {
        public SpoonacularPreferencesProfile()
        {
            CreateMap<FoodPreferences, Preferences>().ReverseMap();
        }
    }
}
