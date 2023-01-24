using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCook.Application.Spoonacular.Interfaces;
using SmartCook.Domain.SpoonacularEntities;
using SmartCook.Domain.SpoonacularEntities.RecipeDetails;

namespace SmartCook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpoonacularRecipesController : ControllerBase
    {
        private readonly IRecipeService _service;

        public SpoonacularRecipesController(IRecipeService service)
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
        public async Task<ActionResult<DetailedRecipe>> GetRecipeDetails(long recipeId)
        {
            return Ok(await _service.GetRecipeDetails(recipeId));
        }

        [HttpGet("GetRecipeByCuisineType")]
        public async Task<ActionResult<List<Recipes>>> GetRecipesByCuisineType(string cuisineType)
        {
            return Ok(await _service.GetRecipesByCuisineType(cuisineType));
        }

        [HttpPost("GetRecommendedRecipes")]
        public async Task<ActionResult<List<Recipes>>> GetRecommendedRecipes(string email)
        {
            return Ok(await _service.GetRecommendedRecipes(email));
        }

        [HttpPost("RecipeByIngredient")]
        public async Task<ActionResult<List<Recipes>>> GetRecipesFromIngredients(string[] ingredients)
        {
            return Ok(await _service.GetRecipeByIngredients(ingredients));
        }
    }
}
