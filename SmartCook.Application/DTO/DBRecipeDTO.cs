using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.DTO
{
    public class DBRecipeDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public long SpoonacularRecipeId { get; set; }
        List<UserDTO> Users { get; set; } = new List<UserDTO>();
    }
}
