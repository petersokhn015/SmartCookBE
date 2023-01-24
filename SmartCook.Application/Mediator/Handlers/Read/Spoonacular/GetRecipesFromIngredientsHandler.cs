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
    public class GetRecipesFromIngredientsHandler : IRequestHandler<GetRecipesFromIngredientsQuery, List<Recipes>>
    {
        private readonly IRecipeRepository _repository;

        public GetRecipesFromIngredientsHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Recipes>> Handle(GetRecipesFromIngredientsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRecipeByIngredients(request.ingredients);
        }
    }
}
