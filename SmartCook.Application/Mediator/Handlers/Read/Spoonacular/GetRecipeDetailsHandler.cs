using AutoMapper;
using MediatR;
using SmartCook.Application.Mediator.Queries.Spoonacular;
using SmartCook.Application.Spoonacular.Interfaces;
using SmartCook.Domain.SpoonacularEntities.RecipeDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Mediator.Handlers.Read.Spoonacular
{
    public class GetRecipeDetailsHandler : IRequestHandler<GetRecipeDetailsQuery, DetailedRecipe>
    {
        private readonly IRecipeRepository _repository;
        private readonly IMapper _mapper;
        public GetRecipeDetailsHandler(IRecipeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<DetailedRecipe> Handle(GetRecipeDetailsQuery request, CancellationToken cancellationToken)
        {
            AnalysedRecipe analysedRecipe = await _repository.GetRecipeInfo(request.recipeID);
            return _mapper.Map<DetailedRecipe>(analysedRecipe);
        }
    }
}
