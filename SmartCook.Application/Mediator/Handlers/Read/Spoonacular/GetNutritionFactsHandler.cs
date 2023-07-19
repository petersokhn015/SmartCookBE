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
    public class GetNutritionFactsHandler : IRequestHandler<GetNutritionFactsQuery, Dish>
    {
        private readonly INutritionFactsRepository _repository;

        public GetNutritionFactsHandler(INutritionFactsRepository repository)
        {
            _repository = repository;
        }

        public Task<Dish> Handle(GetNutritionFactsQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetNutritionFacts(request.name);
        }
    }
}
