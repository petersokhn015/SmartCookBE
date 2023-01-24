using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Infrastructure.Spoonacular
{
    public static class Constants
    {
        public static string SpoonacularBaseUrl = "https://api.spoonacular.com/recipes/";
        public static string SpoonacularSecret = "03f7fd19fd3e438cb751fa3523af01e0";
        public static string GetRandomRecipesUrl = $"{SpoonacularBaseUrl}random?apiKey={SpoonacularSecret}&number=3";
        public static string GetRecipesByIngredients = $"{SpoonacularBaseUrl}findByIngredients?apiKey={SpoonacularSecret}&ingredients=";
        public static string GetRecipesByTime = $"{SpoonacularBaseUrl}random?apiKey={SpoonacularSecret}&number=5&tags=";
        public static string GetRecipeInfoByIdContinued = $"/information?apiKey={SpoonacularSecret}&includeNutrition=true";
        public static string GetSimilarRecipeContinued = $"/similar?apiKey={SpoonacularSecret}&number=5";
        public static string GetRecipesByPreferences = $"{SpoonacularBaseUrl}complexSearch?apiKey={SpoonacularSecret}&number=5";
        public static string GetRecipesByCuisineType = $"{SpoonacularBaseUrl}complexSearch?apiKey={SpoonacularSecret}&number=5&cuisine=";

    }
}
