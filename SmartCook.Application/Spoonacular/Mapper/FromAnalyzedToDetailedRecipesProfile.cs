using AutoMapper;
using SmartCook.Domain.SpoonacularEntities.RecipeDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Spoonacular.Mapper
{
    public class FromAnalyzedToDetailedRecipesProfile : Profile
    {
        public FromAnalyzedToDetailedRecipesProfile()
        {
            CreateMap<AnalysedRecipe, DetailedRecipe>().ReverseMap();
        }
    }
}
