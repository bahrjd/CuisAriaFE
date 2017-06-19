using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.Models
{
    public class Recipe
    {
        public string ID { get; set; }

        public string RecipeName { get; set; }

        public string Description { get; set; }

        public int OwnerId { get; set; }

        public bool shared { get; set; }

        public string notes { get; set; }

        public int myRating { get; set; }

        public int shareRating { get; set; }

        public int numShareRatings { get; set; }

        public string recipePics { get; set; }

        public int prepTime { get; set; }

        public int cookTime { get; set; }

        public int recipeServings { get; set; }

        public string servingSize { get; set; }

        //public ICollection userRecipeFavorites { get; set; }

        //public ICollection steps { get; set; }

        //public ICollection recipeKeywords { get; set; }

    }
}
