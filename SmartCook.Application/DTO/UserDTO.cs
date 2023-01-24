using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.DTO
{
    public class UserDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public List<DBRecipeDTO> FavoriteRecipes { get; set; } = new List<DBRecipeDTO>();
        public PreferencesDTO UserPreferences { get; set; } = new PreferencesDTO();
    }
}
