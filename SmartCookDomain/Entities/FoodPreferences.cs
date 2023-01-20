using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Domain.Entities
{
    public class FoodPreferences
    {
        public string? Diet { get; set; }

        public List<string>? Intolerances { get; set; }

        public List<string>? CuisineTypes { get; set; }
    }
}
