using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartCook.Application.DTO;
using SmartCook.Application.Spoonacular.Interfaces;
using SmartCook.Domain.SpoonacularEntities;
using SmartCook.Domain.SpoonacularEntities.RecipeDetails;
using System.Collections.Generic;

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
            List<Recipes> recipes = new List<Recipes>();
            Recipes r = new Recipes()
            {
                Id = 637624,
                Title =  "Cheesecake Ice-Cream With Mango Syrup",
                Image = "https://spoonacular.com/recipeImages/637624-556x370.jpg"
            };
            recipes.Add(r);
            recipes.Add(r);
            recipes.Add(r);
            //return Ok(recipes);
            return Ok(await _service.GetRandomRecipes());
        }

        [HttpGet("GetRecipesByTimeOfDay")]
        public async Task<ActionResult<List<Recipes>>> GetRecipesByTimeOfDay(string userTime)
        {
            return Ok(await _service.GetRecipesByTime(userTime));
        }

        [HttpGet("GetRecipeDetails")]
        public async Task<ActionResult<DetailedRecipe>> GetRecipeDetails(long recipeId)
        {
            return Ok(await _service.GetRecipeDetails(recipeId));
        }

        [HttpGet("GetRecipeByCuisineType")]
        public async Task<ActionResult<List<Recipes>>> GetRecipesByCuisineType(string cuisineType, int limit, string email)
        {
            List<Recipes> recipes = new List<Recipes>();
            Recipes r = new Recipes()
            {
                Id = 637624,
                Title = "Cheesecake Ice-Cream With Mango Syrup",
                Image = "https://spoonacular.com/recipeImages/637624-556x370.jpg"
            };
            recipes.Add(r);
            recipes.Add(r);
            recipes.Add(r);
            recipes.Add(r);
            recipes.Add(r);
            recipes.Add(r);
            recipes.Add(r);
            recipes.Add(r);
            //return Ok(recipes);
            return Ok(await _service.GetRecipesByCuisineType(cuisineType, limit, email));
        }

        [HttpPost("GetRecommendedRecipes")]
        public async Task<ActionResult<List<Recipes>>> GetRecommendedRecipes(string email)
        {
            return Ok(await _service.GetRecommendedRecipes(email));
        }

        [HttpPost("SearchRecipe")]
        public async Task<ActionResult<List<Recipes>>> SearchRecipe([FromBody] SearchRecipeDTO searchRecipeDTO)
        {
            return Ok(await _service.SearchRecipe(searchRecipeDTO.QuerySearch, searchRecipeDTO.limit));
        }

        [HttpGet("SearchRecipeByCuisineType")]
        public async Task<ActionResult<List<Recipes>>> SearchRecipeByCuisineType(string cuisineType)
        {
            return Ok(await _service.SearchRecipeByCuisine(cuisineType));
        }

        [HttpPost("RecipeByIngredient")]
        public async Task<ActionResult<List<Recipes>>> GetRecipesFromIngredients(string[] ingredients)
        {
            return Ok(await _service.GetRecipeByIngredients(ingredients));
        }

        
    }
}
