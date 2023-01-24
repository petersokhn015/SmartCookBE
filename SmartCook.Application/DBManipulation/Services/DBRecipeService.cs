using AutoMapper;
using MediatR;
using SmartCook.Application.DBManipulation.Interfaces;
using SmartCook.Application.DTO;
using SmartCook.Application.Mediator.Commands.DBManipulation;
using SmartCook.Application.Mediator.Queries.DBManipulation;
using SmartCook.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.DBManipulation.Services
{
    public class DBRecipeService : IDBRecipeService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DBRecipeService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<bool> AddFavoriteRecipe(DBRecipeDTO favoriteRecipe, string email)
        {
            DBRecipe recipe = _mapper.Map<DBRecipe>(favoriteRecipe);
            bool isAddFavoriteRecipeSuccess = await _mediator.Send(new AddFavoriteRecipeCommand(recipe, email));
            return isAddFavoriteRecipeSuccess;

        }

        public async Task<List<DBRecipeDTO>> GetUserFavoriteRecipes(string email)
        {
            List<DBRecipe> favoriteRecipes = await _mediator.Send(new GetUserFavoriteRecipesQuery(email));
            if(favoriteRecipes == null)
            {
                return null;
            }
            return _mapper.Map<List<DBRecipeDTO>>(favoriteRecipes);
        }

        public async Task<bool> RemoveFavoriteRecipe(DBRecipeDTO favoriteRecipe, string email)
        {
            DBRecipe recipe = _mapper.Map<DBRecipe>(favoriteRecipe);
            bool isRemoveFavoriteRecipeSuccess = await _mediator.Send(new RemoveFavoriteRecipeCommand(recipe, email));
            return isRemoveFavoriteRecipeSuccess;
        }
    }
}
