using MediatR;
using SmartCook.Domain.SpoonacularEntities.RecipeDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Mediator.Queries.Spoonacular
{
    public record GetRecipeDetailsQuery(long recipeID) : IRequest<DetailedRecipe>;

}
