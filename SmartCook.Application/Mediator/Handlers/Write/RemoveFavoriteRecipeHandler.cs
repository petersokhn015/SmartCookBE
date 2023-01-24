using MediatR;
using SmartCook.Application.DBManipulation.Interfaces;
using SmartCook.Application.Mediator.Commands.DBManipulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Mediator.Handlers.Write
{
    public class RemoveFavoriteRecipeHandler : IRequestHandler<RemoveFavoriteRecipeCommand, bool>
    {
        private readonly IDBRecipeRepository _dBRecipeRepository;

        public RemoveFavoriteRecipeHandler(IDBRecipeRepository dBRecipeRepository)
        {
            _dBRecipeRepository = dBRecipeRepository;
        }

        public Task<bool> Handle(RemoveFavoriteRecipeCommand request, CancellationToken cancellationToken)
        {
            return _dBRecipeRepository.RemoveFavoriteRecipe(request.recipe, request.email);
        }
    }
}
