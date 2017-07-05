using CuisAriaFE.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.Models
{

    public class Recipe : ObservableBase
    {
        public string UserID { get; set; }
        public bool Favorite { get; set; }
        public string RecipeID { get; set; }
        public string RecipeName { get; set; }
        public string Description { get; set; }
        public string OwnerId { get; set; }
        public bool Shared { get; set; }
        public string Notes { get; set; }
        public int MyRating { get; set; }
        public decimal ShareRating { get; set; }
        public decimal NumShareRatings { get; set; }
        public string RecipePic { get; set; }
        public decimal PrepTime { get; set; }
        public decimal CookTime { get; set; }
        public decimal RecipeServings { get; set; }
        public string ServingSize { get; set; }
    }

}
