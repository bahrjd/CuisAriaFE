using CuisAriaFE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.Models
{
    public class AddEditRecipe : ObservableBase
    {
        public UserRecipeFavorite userRecipeFavorite { get; set; }
        public RecipeVM recipe { get; set; }
        public List<RecipeStepIngredientVM> RecipeStepIngredients { get; set; }
        public List<IngredientListVM> IngredientList { get; set; }
        public List<Keyword> Keywords { get; set; }
    }

    public class UserRecipeFavorite : ObservableBase
    {
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public bool Favorite { get; set; }
    }

    public class RecipeVM : ObservableBase
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
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

    public class RecipeStepIngredientVM : ObservableBase
    {
        public int RecipeId { get; set; }

        public int StepId { get; set; }
        public int StepNumber { get; set; }
        public string Instruction { get; set; }

        public List<IngredientListVM> IngredientList { get; set; }
    }

    public class IngredientListVM : ObservableBase
    {
        public int? IngredientId { get; set; }
        public string IngredName { get; set; }
        public decimal IngredQty { get; set; }
        public string IngredUnit { get; set; }
    }

    public class Keyword : ObservableBase
    {
        public int Id { get; set; }
        public string SearchWord { get; set; }
    }
}
