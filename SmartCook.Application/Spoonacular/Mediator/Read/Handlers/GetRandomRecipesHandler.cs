using MediatR;
using SmartCook.Application.Spoonacular.Interfaces;
using SmartCook.Application.Spoonacular.Mediator.Read.Queries;
using SmartCook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Spoonacular.Mediator.Read.Handlers
{
    public class GetRandomRecipesHandler : IRequestHandler<GetRandomRecipesQuery, List<Recipes>>
    {
        private readonly IRecipeRepository _recipeRepository;
        public GetRandomRecipesHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
        public async Task<List<Recipes>> Handle(GetRandomRecipesQuery request, CancellationToken cancellationToken)
        {
            return await _recipeRepository.GetRandomRecipes();
        }
    }
}
