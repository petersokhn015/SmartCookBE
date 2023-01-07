using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Domain.Entities.RecipeDetails
{
    public class Nutrition
    {
        [JsonProperty("nutrients")]
        public List<Nutrient>? Nutrients { get; set; }
    }
}
