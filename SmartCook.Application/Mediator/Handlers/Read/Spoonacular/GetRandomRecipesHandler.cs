using MediatR;
using SmartCook.Application.Mediator.Queries.Spoonacular;
using SmartCook.Application.Spoonacular.Interfaces;
using SmartCook.Domain.SpoonacularEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Mediator.Handlers.Read.Spoonacular
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
