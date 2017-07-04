using CuisAriaFE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.Models
{
    public class Ingredient : ObservableBase
    {
        public string IngredientID { get; set; }

        public string IngredName { get; set; }

        public decimal IngredQty { get; set; }

        public string IngredUnit { get; set; }
    }
}
