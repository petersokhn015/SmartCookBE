using MediatR;
using SmartCook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Spoonacular.Read.Queries
{
    public record GetRandomRecipesQuery() : IRequest<List<Recipes>>;

}
