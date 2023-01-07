using MediatR;
using SmartCook.Domain.Entities.RecipeDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.Spoonacular.Mediator.Read.Queries
{
    public record GetRecipeDetailsQuery(int recipeID) : IRequest<DetailedRecipe>;
    
}
