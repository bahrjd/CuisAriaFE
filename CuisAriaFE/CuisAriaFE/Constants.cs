using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE
{
	public static class Constants
    {
        private static string BaseUrl = "http://cuisariabe.azurewebsites.net/";
        //private static string BaseUrl = "localhost:63488/";

        // URL of Recipe Services
        public static string SharedRcpUrl = BaseUrl + "GetSharedRecipes/{0}";
        public static string MyRcpUrl = BaseUrl + "GetMyRecipes/{0}";
        public static string FavRcpUrl = BaseUrl + "GetFavRecipes/{0}";
        public static string RcpUrl = BaseUrl + "GetRecipe/{0}";
        public static string RcpStepsUrl = BaseUrl + "GetRecipeSteps/{0}";
        public static string RcpAddEditUrl = BaseUrl + "AddEditRecipe";

        public static string UserByNameUrl = BaseUrl + "GetUserByName/{0}";

        // URL for GetMenu // USAGE: Set MenuID = 0 to get current menu or menuId to get specific menu
        public static string MenuRcpUrl = BaseUrl + "GetMenu/{0}/{1}";

        // URL for GetSavedMenus // Input UserId. Returns list of user menus.
        public static string SavedMenusUrl = BaseUrl + "GetSavedMenus/{0}";

        // URL for AddEditMenu // USAGE: Pass a JSON object of type AddEditGetMenu
        public static string AddEditMenuUrl = BaseUrl + "AddMenuRecipe";

        // URL for Add/Edit User // USAGE: Set Id = 0 to add a user // Set Id = userID to edit user data
        public static string UserAddEditUrl = BaseUrl + "AddEditUser";

        // URL to toggle shared recipes // USAGE: Passing a recipeID toggles bit
        public static string ToggleShareUrl = BaseUrl + "ShareRecipeToggle/{0}";

        // URL to toggle user favorite recipes // USAGE: Passing a userID and recipeID toggles bit
        public static string ToggleFavUrl = BaseUrl + "FavRecipeToggle/{0}/{1}";

        // URL to get shopping list // USAGE: Passing a UserId retrieves shoppinglist
        public static string ShopListUrl = BaseUrl + "GetShoppingList/{0}";

        // URL to add a shopping list // USAGE: Pass /UserId/Menu to add a Menu to a ShoppingList
        public static string AddEditShopListUrl = BaseUrl + "AddEditShoppingList/{0}/{1}";

        // Credentials that are hard coded //
        public static string RecipeTestID = "47";
        public static string UserTestID = "48";
        // public static string UserTestID = Data.CABEServices.UserDetails.ID.ToString();
        public static string OwnerTestID = "48";
        // public static string OwnerTestID = Data.CABEServices.UserDetails.ID.ToString();
        public static string MenuId = "0";

        // Fraction conversion lists
        public static string[] FracList = { "1/8", "1/4", "3/8", "1/2", "5/8", "3/4", "7/8" };
        //public static string[] FracList = { "   ", "1/8", "1/4", "1/3", "3/8", "1/2", "5/8", "2/3", "3/4", "7/8" };
        public static decimal[] FracDecimals = { 0m, 0.125m, 025m, 0.333m, 0.375m, 0.5m, 0.625m, 0.666m, 0.75m, 0.875m };

        // Add Recipe display row height
        public static int addRcpDispRowHeight = 41;

        // Recipe display row height
        public static int rcpDispRowHeight = 17;

        // Characters per line
        public static int rcpIngredCharsPerLine = 27;
        public static int rcpStepCharsPerLine = 52;

    }
}