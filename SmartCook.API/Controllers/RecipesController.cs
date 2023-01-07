using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCook.Application.Spoonacular.Interfaces;
using SmartCook.Domain.Entities;

namespace SmartCook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _service;

        public RecipesController(IRecipeService service)
        {
            _service = service;
        }

        [HttpGet("GetRandomRecipes")]
        public async Task<ActionResult<List<Recipes>>> GetRandomRecipes()
        {
            return Ok(await _service.GetRandomRecipes());
        }

        [HttpPost("RecipeByIngredient")]
        public async Task<ActionResult<List<Recipes>>> GetRecipesFromIngredients(string[] ingredients)
        {
            return Ok(await _service.GetRecipeByIngredients(ingredients));
        }
    }
}
