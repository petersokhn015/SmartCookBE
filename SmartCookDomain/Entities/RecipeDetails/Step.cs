using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Domain.Entities.RecipeDetails
{
    public class Step
    {
        [JsonProperty("step")]
        public string StepString { get; set; } = string.Empty;
    }
}
