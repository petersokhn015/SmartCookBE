﻿using SmartCook.Domain.Entities;
using SmartCook.Domain.Entities.RecipeDetails;
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
        Task<DetailedRecipe> GetRecipeDetails(int recipeId);
        Task<List<Recipes>> GetRecommendedRecipes(int[] recipesIds);
        Task<List<Recipes>> GetRecipesByTime(string tags);
    }
}
