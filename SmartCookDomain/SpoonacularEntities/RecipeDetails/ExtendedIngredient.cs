using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Domain.SpoonacularEntities.RecipeDetails
{
    public class ExtendedIngredient
    {
        [JsonProperty("image")]
        public string Image { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("measures")]
        public Measures? Measures { get; set; }
    }
}
