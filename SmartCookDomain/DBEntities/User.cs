using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Domain.DBEntities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Username { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
        [Required]
        public bool IsLoggedIn { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public List<DBRecipe>  FavoriteRecipes { get; set; } = new List<DBRecipe>();
        public Preferences UserPreferences { get; set; } = new Preferences();

    }
}
