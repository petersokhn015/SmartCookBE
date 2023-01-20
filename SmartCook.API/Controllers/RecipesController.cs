using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCook.Application.Spoonacular.Interfaces;
using SmartCook.Domain.Entities;
using SmartCook.Domain.Entities.RecipeDetails;

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

        [HttpGet("GetRecipesByTimeOfDay")]
        public async Task<ActionResult<List<Recipes>>> GetRecipesByTimeOfDay(string tags)
        {
            return Ok(await _service.GetRecipesByTime(tags));
        }

        [HttpGet("GetRecipeDetails")]
        public async Task<ActionResult<DetailedRecipe>> GetRecipeDetails(int recipeId)
        {
            return Ok(await _service.GetRecipeDetails(recipeId));
        }

        [HttpPost("GetRecommendedRecipes")]
        public async Task<ActionResult<DetailedRecipe>> GetRecommendedRecipes(int[] recipeIds)
        {
            return Ok(await _service.GetRecommendedRecipes(recipeIds));
        }

        [HttpPost("RecipeByIngredient")]
        public async Task<ActionResult<List<Recipes>>> GetRecipesFromIngredients(string[] ingredients)
        {
            return Ok(await _service.GetRecipeByIngredients(ingredients));
        }
    }
}
