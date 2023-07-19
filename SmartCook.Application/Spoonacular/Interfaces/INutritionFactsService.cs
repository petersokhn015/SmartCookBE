using SmartCook.Domain.SpoonacularEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Spoonacular.Interfaces
{
    public interface INutritionFactsService
    {
        Task<Dish> GetNutritionFacts(string name);
    }
}
