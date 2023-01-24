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
    public class GetRecommendedRecipesHandler : IRequestHandler<GetRecommendedRecipesQuery, List<Recipes>>
    {
        private readonly IRecipeRepository _repository;
        public GetRecommendedRecipesHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Recipes>> Handle(GetRecommendedRecipesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRecommendedRecipes(request.email);
        }
    }
}
