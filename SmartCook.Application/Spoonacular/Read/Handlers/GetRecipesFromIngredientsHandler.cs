using MediatR;
using SmartCook.Application.Spoonacular.Interfaces;
using SmartCook.Application.Spoonacular.Read.Queries;
using SmartCook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Spoonacular.Read.Handlers
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
