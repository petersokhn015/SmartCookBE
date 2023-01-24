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
    public class GetRecipesByTimeHandler : IRequestHandler<GetRecipesByTimeQuery, List<Recipes>>
    {
        private readonly IRecipeRepository _repository;

        public GetRecipesByTimeHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }
        public Task<List<Recipes>> Handle(GetRecipesByTimeQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetRecipesByTime(request.userTime);
        }
    }

}
