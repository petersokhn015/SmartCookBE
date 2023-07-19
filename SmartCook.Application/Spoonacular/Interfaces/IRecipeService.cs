using SmartCook.Domain.SpoonacularEntities;
using SmartCook.Domain.SpoonacularEntities.RecipeDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Spoonacular.Interfaces
{
    public interface IRecipeService
    {
        Task<List<Recipes>> GetRandomRecipes();
        Task<List<Recipes>> GetRecipeByIngredients(string[] ingredients);
        Task<DetailedRecipe> GetRecipeDetails(long recipeId);
        Task<List<Recipes>> GetRecommendedRecipes(string email);
        Task<List<Recipes>> GetRecipesByTime(string userTime);
        Task<List<Recipes>> SearchRecipe(string querySearch, int limit);
        Task<List<Recipes>> SearchRecipeByCuisine(string cuisine);
        Task<List<Recipes>> GetRecipesByCuisineType(string cuisineType, int limit, string email);
    }
}
