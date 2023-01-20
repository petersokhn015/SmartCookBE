﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SmartCook.Domain.Entities;
using SmartCook.Application.Spoonacular.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SmartCook.Domain.Entities.RecipeDetails;
using System.Security.Cryptography;

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

        public async Task<List<Recipes>> GetRecipesByTime(string tag)
        {
            List<Recipes> recipes = new();
            try
            {
                var response = await _client.GetAsync(new Uri(Constants.GetRecipesByTime+tag));
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

        public async Task<List<Recipes>> GetRecipesBasedOnPreferences(FoodPreferences preferences)
        {
            List<Recipes> recipes = new();
            string preferencesApiString = "";
            try
            {
                if (preferences.CuisineTypes != null || preferences.CuisineTypes!.Count > 0)
                {
                    preferencesApiString += $"&cuisine={String.Join(",", preferences.CuisineTypes)}";
                }

                if (preferences.Intolerances != null || preferences.Intolerances!.Count > 0) 
                {
                    preferencesApiString += $"&intolerances={String.Join(",", preferences.Intolerances)}";
                }

                if (preferences.Diet != null || preferences.Diet != "") 
                {
                    preferencesApiString += $"&diet={preferences.Diet}";
                }

                var response = await _client.GetAsync(new Uri(Constants.GetRecipesByPreferences+preferencesApiString));
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var recipesData = JObject.Parse(apiResponse);
                    var recipeList = recipesData["results"];
                    recipes = recipeList?.ToObject<List<Recipes>>()!;
                }
            }
            catch(Exception e) 
            { 
                Console.WriteLine(e.ToString());
            }
            return recipes;
        }

        public async Task<List<Recipes>> GetSimilarRecipe(int recipeId)
        {
            List<Recipes> similarRecipes = new();
            try
            {
                var response = await _client.GetAsync(new Uri(Constants.SpoonacularBaseUrl + recipeId + Constants.GetSimilarRecipeContinued));
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    similarRecipes = JsonConvert.DeserializeObject<List<Recipes>>(apiResponse)!;
                    foreach(var recipe in similarRecipes)
                    {
                        if(recipe.Image == "")
                        {
                            AnalysedRecipe recipeDetails = await GetRecipeInfo((int)recipe.Id);
                            recipe.Image = recipeDetails.Image;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return similarRecipes;
        }

        private List<Recipes> ShuffleAndFixRecipeList(List<Recipes> recipes)
        {
            var random = new Random();
            var newShuffledList = new List<Recipes>();
            var listcCount = recipes.Count;

            for (int i = 0; i < listcCount; i++)
            {
                var randomElementInList = random.Next(0, recipes.Count);
                newShuffledList.Add(recipes[randomElementInList]);
                recipes.Remove(recipes[randomElementInList]);
            }

            newShuffledList = newShuffledList.DistinctBy(recipe => recipe.Title).ToList();
            return newShuffledList;
        }

        public async Task<List<Recipes>> GetRecommendedRecipes(int[] recipeIds)
        {
            List<Recipes> RecommendedRecipes = new();
            FoodPreferences preferences = new()
            {
                Diet="vegan",
                Intolerances = new List<string>()
                {
                    "gluten",
                    "egg"
                },
                CuisineTypes = new List<string>()
                {
                    "thai",
                    "american"
                }
            };

            try
            {
                foreach(int Id in recipeIds)
                {
                    var similarRecipes = await GetSimilarRecipe(Id);
                    similarRecipes.ForEach(similarRecipe => RecommendedRecipes.Add(similarRecipe));
                }

                var recipesByPreferences = await GetRecipesBasedOnPreferences(preferences);
                recipesByPreferences.ForEach(recipeByPref => RecommendedRecipes.Add(recipeByPref));

                RecommendedRecipes = ShuffleAndFixRecipeList(RecommendedRecipes);
                return RecommendedRecipes;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return RecommendedRecipes;
        }

        public async Task<AnalysedRecipe> GetRecipeInfo(int recipeId)
        {
            AnalysedRecipe recipe = new();
            try
            {
                var response = await _client.GetAsync(new Uri(Constants.SpoonacularBaseUrl+recipeId+Constants.GetRecipeInfoByIdContinued));
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    recipe = JsonConvert.DeserializeObject<AnalysedRecipe>(apiResponse)!;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return recipe;

        }

    }
}
