using MediatR;
using SmartCook.Domain.SpoonacularEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Mediator.Queries.Spoonacular
{
    public record GetRecommendedRecipesQuery(string email) : IRequest<List<Recipes>>;
}
