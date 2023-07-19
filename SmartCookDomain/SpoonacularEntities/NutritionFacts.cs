using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Domain.SpoonacularEntities
{

    public class NutritionFacts
    {
       public Dish[] dishes { get; set; }
    }

    public class Dish
    {
        private string _caloric;
        private string _fat;
        private string _carbon;
        private string _protein;

        public string name { get; set; }

        public string caloric
        {
            get { return _caloric; }
            set { _caloric = value + " KCal"; }
        }

        public string fat
        {
            get { return _fat; }
            set { _fat = value + " g"; }
        }

        public string carbon
        {
            get { return _carbon; }
            set { _carbon = value + " g"; }
        }

        public string protein
        {
            get { return _protein; }
            set { _protein = value + " g"; }
        }
    }
}
