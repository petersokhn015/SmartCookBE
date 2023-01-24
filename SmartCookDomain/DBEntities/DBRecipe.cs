using System.ComponentModel.DataAnnotations;

namespace SmartCook.Domain.DBEntities
{
    public class DBRecipe
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(200)]
        public string Image { get; set; } = string.Empty;
        [Required]
        public long SpoonacularRecipeId { get; set; }
        List<User> Users { get; set; } = new List<User>();
    }
}