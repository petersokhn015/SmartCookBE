using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Domain.Entities.RecipeDetails
{
    public class Ingredient
    {
        public Ingredient(string image, double amount, string name, string unit)
        {

            ImageUrl = $"http://spoonacular.com/cdn/ingredients_100x100/{image}";
            Amount = amount;
            Name = name;
            Unit = unit;
        }

        public string ImageUrl { get; set; }

        public double Amount { get; set; }

        public string Name { get; set; }

        public string Unit { get; set; }
    }
}
