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
    public class GetSearchRecipeByCuisineHandler : IRequestHandler<GetSearchRecipeByCuisineQuery, List<Recipes>>
    {
        private readonly IRecipeRepository _repository;

        public GetSearchRecipeByCuisineHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Recipes>> Handle(GetSearchRecipeByCuisineQuery request, CancellationToken cancellationToken)
        {
            return await _repository.SearchRecipeByCuisine(request.cuisine);
        }
    }
}
