using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SmartCook.Domain.Entities;
using SmartCook.Application.Spoonacular.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SmartCook.Infrastructure.Spoonacular.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private HttpClient _client;
        public RecipeRepository() 
        {
            _client = new HttpClient();
        }

        public async Task<List<Recipes>> GetRandomRecipes()
        {
            List<Recipes> recipes = new();
            try
            {
                var response = await _client.GetAsync(new Uri(Constants.GetRandomRecipesUrl));
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var recipesData = JObject.Parse(apiResponse);
                    var recipeList = recipesData["recipes"];
                    recipes = recipeList?.ToObject<List<Recipes>>()!;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return recipes;
        }

        public async Task<List<Recipes>> GetRecipeByIngredients(string[] ingredients)
        {
            List<Recipes> recipes = new();
            try
            {
                string ingredientsString = String.Join(",", ingredients);
                var response = await _client.GetAsync(new Uri(Constants.GetRecipesByIngredients+ingredientsString));

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    recipes = JsonConvert.DeserializeObject<List<Recipes>>(apiResponse)!;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }
            return recipes;
        }

    }
}
