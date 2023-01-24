using AutoMapper;
using SmartCook.Application.DTO;
using SmartCook.Domain.DBEntities;
using SmartCook.Domain.SpoonacularEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.DBManipulation.Mapper
{
    public class DBRecipeProfile : Profile
    {
        public DBRecipeProfile()
        {
            CreateMap<DBRecipe, DBRecipeDTO>().ReverseMap();
        }
    }
}
