using SmartCook.Domain.SpoonacularEntities;
using SmartCook.Domain.SpoonacularEntities.RecipeDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Spoonacular.Interfaces
{
    public interface IRecipeRepository
    {
        Task<List<Recipes>> GetRandomRecipes();
        Task<List<Recipes>> GetRecipeByIngredients(string[] ingredients);
        Task<AnalysedRecipe> GetRecipeInfo(int recipeID);
        Task<List<Recipes>> GetRecommendedRecipes(int[] recipeIds);
        Task<List<Recipes>> GetRecipesByTime(string tags);
        Task<List<Recipes>> GetRecipesByCuisineType(string cuisineType);
    }
}
