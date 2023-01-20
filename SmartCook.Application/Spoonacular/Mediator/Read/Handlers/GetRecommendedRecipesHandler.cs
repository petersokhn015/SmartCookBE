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
    public class GetRecommendedRecipesHandler : IRequestHandler<GetRecommendedRecipesQuery, List<Recipes>>
    {
        private readonly IRecipeRepository _repository;
        public GetRecommendedRecipesHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Recipes>> Handle(GetRecommendedRecipesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRecommendedRecipes(request.recipeIds);
        }
    }
}
