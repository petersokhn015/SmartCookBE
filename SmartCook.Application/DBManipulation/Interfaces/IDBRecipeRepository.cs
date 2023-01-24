using SmartCook.Domain.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.DBManipulation.Interfaces
{
    public interface IDBRecipeRepository
    {
        Task<bool> AddFavoriteRecipe(DBRecipe recipe, string email);
        Task<List<DBRecipe>> GetUserFavoriteRecipes(string email);
        Task<bool> RemoveFavoriteRecipe(DBRecipe recipe, string email);
    }
}
