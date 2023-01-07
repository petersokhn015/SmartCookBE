using AutoMapper;
using MediatR;
using SmartCook.Application.Spoonacular.Interfaces;
using SmartCook.Application.Spoonacular.Mediator.Read.Queries;
using SmartCook.Domain.Entities.RecipeDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Spoonacular.Mediator.Read.Handlers
{
    public class GetRecipeDetailsHandler : IRequestHandler<GetRecipeDetailsQuery, DetailedRecipe>
    {
        private readonly IRecipeRepository _repository;
        private readonly IMapper _mapper;
        public GetRecipeDetailsHandler(IRecipeRepository repository, IMapper mapper)
        {
            _repository= repository;
            _mapper= mapper;
        }
        public async Task<DetailedRecipe> Handle(GetRecipeDetailsQuery request, CancellationToken cancellationToken)
        {
            AnalysedRecipe analysedRecipe = await _repository.GetRecipeInfo(request.recipeID);
            return _mapper.Map<DetailedRecipe>(analysedRecipe);
        }
    }
}
