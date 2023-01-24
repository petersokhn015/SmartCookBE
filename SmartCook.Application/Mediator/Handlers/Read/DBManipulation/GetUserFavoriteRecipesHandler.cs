using MediatR;
using SmartCook.Application.DBManipulation.Interfaces;
using SmartCook.Application.Mediator.Queries.DBManipulation;
using SmartCook.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Mediator.Handlers.Read.DBManipulation
{
    public class GetUserFavoriteRecipesHandler : IRequestHandler<GetUserFavoriteRecipesQuery, List<DBRecipe>>
    {
        private readonly IDBRecipeRepository _recipeRepository;

        public GetUserFavoriteRecipesHandler(IDBRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public Task<List<DBRecipe>> Handle(GetUserFavoriteRecipesQuery request, CancellationToken cancellationToken)
        {
            return _recipeRepository.GetUserFavoriteRecipes(request.email);
        }
    }
}
