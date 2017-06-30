using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.Models
{
    public class GetRecipeSteps
    {
        public string RecipeID { get; set; }

        public string StepID { get; set; }

        public string StepNumber { get; set; }

        public string Instruction { get; set; }

        public List<Ingredients> IngredientList { get; set; }
    }

    public class Ingredients
    {
        public string IngredientID { get; set; }

        public string IngredName { get; set; }

        public decimal IngredQty { get; set; }

        public string IngredUnit { get; set; }
    }
}
