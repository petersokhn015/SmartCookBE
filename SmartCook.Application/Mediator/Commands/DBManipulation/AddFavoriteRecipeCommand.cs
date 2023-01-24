using MediatR;
using SmartCook.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Mediator.Commands.DBManipulation
{
    public record AddFavoriteRecipeCommand(DBRecipe recipe, string email) : IRequest<bool>;
}
