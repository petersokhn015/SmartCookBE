using MediatR;
using SmartCook.Application.Mediator.Queries.Spoonacular;
using SmartCook.Application.Spoonacular.Interfaces;
using SmartCook.Domain.SpoonacularEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Spoonacular.Services
{
    public class NutritionFactsService : INutritionFactsService
    {
        private readonly IMediator _mediator;

        public NutritionFactsService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Dish> GetNutritionFacts(string name)
        {
            return await _mediator.Send(new GetNutritionFactsQuery(name));
        }
    }
}
