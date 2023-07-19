using Microsoft.EntityFrameworkCore;
using SmartCook.Application.DBManipulation.Interfaces;
using SmartCook.Domain.DBEntities;
using SmartCook.Infrastructure.DBManipulation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Infrastructure.DBManipulation.Repositories
{
    public class DBRecipeRepository : IDBRecipeRepository
    {
        private readonly ApplicationDBContext _context;

        public DBRecipeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddFavoriteRecipe(DBRecipe recipe, string email)
        {
            User? user = await _context.Users
                .Include(p => p.FavoriteRecipes)
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return false;
            }

            user.FavoriteRecipes.Add(recipe);
            await _context.SaveChangesAsync();
            return true;


        }

        public async Task<List<DBRecipe>> GetUserFavoriteRecipes(string email)
        {
            User? user = await _context.Users
                .Include(p => p.FavoriteRecipes)
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null) 
            {
                return null;
            }

            return user.FavoriteRecipes;
        }

        public async Task<bool> RemoveFavoriteRecipe(DBRecipe recipe, string email)
        {
            User? user = await _context.Users
                .Include(p => p.FavoriteRecipes)
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return false;
            }

            var recipeToRemove = user.FavoriteRecipes.FirstOrDefault(r => r.SpoonacularRecipeId == recipe.SpoonacularRecipeId);
            if (recipeToRemove != null)
            {
                user.FavoriteRecipes.Remove(recipeToRemove);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

    }
}
