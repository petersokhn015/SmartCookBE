namespace SmartCook.API.Controllers
{
    public class TestModel
    {
        public int preparationMinutes { get; set; }
        public int cookingMinutes { get; set; }
        public Extendedingredient[] extendedIngredients { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public int readyInMinutes { get; set; }
        public int servings { get; set; }
        public string image { get; set; }
        public string instructions { get; set; }
        public object[] analyzedInstructions { get; set; }

        public Nutrition nutrition { get; set; }
    }
}
public class Caloricbreakdown
{
    public float percentProtein { get; set; }
    public float percentFat { get; set; }
    public float percentCarbs { get; set; }
}

public class Nutrition
{
    public Nutrient[] nutrients { get; set; }
}

public class Nutrient
{
    public string name { get; set; }
    public float amount { get; set; }
    public string unit { get; set; }
    public float percentOfDailyNeeds { get; set; }
}

public class Weightperserving
{
    public int amount { get; set; }
    public string unit { get; set; }
}

public class Extendedingredient
{
    public int id { get; set; }
    public string image { get; set; }
    public string nameClean { get; set; }
    public float amount { get; set; }
    public string[] meta { get; set; }
}


