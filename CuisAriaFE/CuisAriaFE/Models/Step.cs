using CuisAriaFE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.Models
{
    public class Step : ObservableBase
    {
        public string RecipeID { get; set; }

        public string StepID { get; set; }

        public string StepNumber { get; set; }

        public string Instruction { get; set; }
    }
}
