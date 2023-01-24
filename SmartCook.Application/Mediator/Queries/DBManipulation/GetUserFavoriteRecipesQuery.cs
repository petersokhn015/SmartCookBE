using MediatR;
using SmartCook.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Mediator.Queries.DBManipulation
{
    public record GetUserFavoriteRecipesQuery(string email) : IRequest<List<DBRecipe>>;
    
}
