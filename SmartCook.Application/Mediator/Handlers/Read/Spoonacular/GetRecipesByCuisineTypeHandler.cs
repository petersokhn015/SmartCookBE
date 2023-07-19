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
    public class GetRecipesByCuisineTypeHandler : IRequestHandler<GetRecipesByCuisineTypeQuery, List<Recipes>>
    {
        private readonly IRecipeRepository _repository;

        public GetRecipesByCuisineTypeHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Recipes>> Handle(GetRecipesByCuisineTypeQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetRecipesByCuisineType(request.cuisineType, request.limit, request.email);
        }
    }
}
