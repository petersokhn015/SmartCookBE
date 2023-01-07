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
    public class GetRecipesByTimeHandler : IRequestHandler<GetRecipesByTimeQuery, List<Recipes>>
    {
        private readonly IRecipeRepository _repository;

        public GetRecipesByTimeHandler(IRecipeRepository repository)
        {
            _repository = repository;
        }
        public Task<List<Recipes>> Handle(GetRecipesByTimeQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetRecipesByTime(request.tags);
        }
    }

}
