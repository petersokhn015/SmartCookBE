using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Infrastructure.Spoonacular
{
    public static class Constants
    {
        //977311665db841aaaab0c86ba102272b
        //03f7fd19fd3e438cb751fa3523af01e0
        //3b745d1233c64d598d332350d462f375
        //3eb7443f404841f79911b06e863c5276
        //53da2a506bd745c7996d4b33fa36f2c0
        public static string SpoonacularBaseUrl = "https://api.spoonacular.com/recipes/";
        public static string SpoonacularSecret = "53da2a506bd745c7996d4b33fa36f2c0";
        public static string RapidAPIHost = "dietagram.p.rapidapi.com";
        public static string RapidAPIKey = "e315e638edmshc4857019ba9b152p1e06f3jsn3f7a9e9f45af";
        public static string GetRandomRecipesUrl = $"{SpoonacularBaseUrl}random?apiKey={SpoonacularSecret}&number=3";
        public static string GetRecipesByIngredients = $"{SpoonacularBaseUrl}findByIngredients?apiKey={SpoonacularSecret}&ingredients=";
        public static string GetRecipesByTime = $"{SpoonacularBaseUrl}random?apiKey={SpoonacularSecret}&number=5&tags=";
        public static string GetRecipeInfoByIdContinued = $"/information?apiKey={SpoonacularSecret}&includeNutrition=true";
        public static string GetSimilarRecipeContinued = $"/similar?apiKey={SpoonacularSecret}&number=9";
        public static string GetRecipesByPreferences = $"{SpoonacularBaseUrl}complexSearch?apiKey={SpoonacularSecret}&number=9";
        public static string GetRecipesByCuisineType = $"{SpoonacularBaseUrl}complexSearch?apiKey={SpoonacularSecret}&cuisine=";
        public static string SearchRecipes = $"{SpoonacularBaseUrl}complexSearch?apiKey={SpoonacularSecret}&query=";

    }
}
