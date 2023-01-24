using SmartCook.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.DBManipulation.Interfaces
{
    public interface IDBRecipeService
    {
        Task<bool> AddFavoriteRecipe(DBRecipeDTO favoriteRecipe, string email);
        Task<List<DBRecipeDTO>> GetUserFavoriteRecipes(string email);
        Task<bool> RemoveFavoriteRecipe(DBRecipeDTO favoriteRecipe, string email);
    }
}
