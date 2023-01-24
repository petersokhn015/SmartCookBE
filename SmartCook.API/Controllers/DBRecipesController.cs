using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCook.Application.DBManipulation.Interfaces;
using SmartCook.Application.DBManipulation.Services;
using SmartCook.Application.DTO;
using SmartCook.Domain.SpoonacularEntities;

namespace SmartCook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBRecipesController : ControllerBase
    {
        private readonly IDBRecipeService _dBRecipeService;

        public DBRecipesController(IDBRecipeService dBRecipeService)
        {
            _dBRecipeService = dBRecipeService;
        }

        [HttpGet("GetUserFavoriteRecipes")]
        public async Task<ActionResult<List<DBRecipeDTO>>> GetUserFavoriteRecipes(string email)
        {
            List<DBRecipeDTO> favoriteRecipes = await _dBRecipeService.GetUserFavoriteRecipes(email);
            if (favoriteRecipes == null)
            {
                return NotFound("Couldn't fetch favorite recipes, user not found");
            }
            else if (favoriteRecipes.Count == 0)
            {
                return NotFound("the user has no favorites");
            }
            else
            {
                return Ok(favoriteRecipes);
            }
            
        }

        [HttpPost("AddFavoriteRecipe")]
        public async Task<ActionResult> AddFavoriteRecipe([FromBody] DBRecipeDTO favoriteRecipe, string email)
        {
            bool isFavoriteRecipeAddedSuccess = await _dBRecipeService.AddFavoriteRecipe(favoriteRecipe, email);
            if (!isFavoriteRecipeAddedSuccess) 
            {
                return NotFound("Couldn't add recipe to favorites, the user doesn't exist");
            }
            return Ok("Recipe added to favorites");
        }

        [HttpDelete("RemoveFavoriteRecipe")]
        public async Task<ActionResult> RemoveFavoriteRecipe([FromBody] DBRecipeDTO favoriteRecipe, string email)
        {
            bool isRemoveFavoriteRecipeSuccess = await _dBRecipeService.RemoveFavoriteRecipe(favoriteRecipe, email);
            if (!isRemoveFavoriteRecipeSuccess)
            {
                return NotFound("Couldn't remove recipe from favorites, the user doesn't exist");
            }
            return Ok("Recipe removed from favorites");
        }
    }
}
