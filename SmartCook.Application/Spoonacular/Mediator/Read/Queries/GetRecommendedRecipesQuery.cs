using MediatR;
using SmartCook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Spoonacular.Mediator.Read.Queries
{
    public record GetRecommendedRecipesQuery(int[] recipeIds) : IRequest<List<Recipes>>;
}
