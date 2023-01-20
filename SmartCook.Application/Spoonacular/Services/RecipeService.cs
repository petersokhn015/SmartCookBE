﻿using MediatR;
using SmartCook.Application.Spoonacular.Interfaces;
using SmartCook.Application.Spoonacular.Mediator.Read.Queries;
using SmartCook.Domain.Entities;
using SmartCook.Domain.Entities.RecipeDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Spoonacular.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IMediator _mediator;
        public RecipeService(IMediator mediator) 
        {
            _mediator= mediator;
        }
        public Task<List<Recipes>> GetRandomRecipes()
        {
            return _mediator.Send(new GetRandomRecipesQuery());
        }

        public Task<List<Recipes>> GetRecipeByIngredients(string[] ingredients)
        {
            return _mediator.Send(new GetRecipesFromIngredientsQuery(ingredients));
        }

        public Task<DetailedRecipe> GetRecipeDetails(int recipeId)
        {
            return _mediator.Send(new GetRecipeDetailsQuery(recipeId));
        }

        public Task<List<Recipes>> GetRecommendedRecipes(int[] recipeIds)
        {
            return _mediator.Send(new GetRecommendedRecipesQuery(recipeIds));
        }

        public Task<List<Recipes>> GetRecipesByTime(string tags)
        {
            return _mediator.Send(new GetRecipesByTimeQuery(tags));
        }
    }
}
