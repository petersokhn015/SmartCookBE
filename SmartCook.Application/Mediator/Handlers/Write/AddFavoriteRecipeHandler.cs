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
    public class AddFavoriteRecipeHandler : IRequestHandler<AddFavoriteRecipeCommand, bool>
    {
        private readonly IDBRecipeRepository _dBRepository;

        public AddFavoriteRecipeHandler(IDBRecipeRepository dBRepository)
        {
            _dBRepository = dBRepository;
        }

        public Task<bool> Handle(AddFavoriteRecipeCommand request, CancellationToken cancellationToken)
        {
            return _dBRepository.AddFavoriteRecipe(request.recipe, request.email);
        }
    }
}
