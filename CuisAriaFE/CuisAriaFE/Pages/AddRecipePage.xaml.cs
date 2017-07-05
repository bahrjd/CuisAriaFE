using CuisAriaFE.Data;
using CuisAriaFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CuisAriaFE.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddRecipePage : ContentPage
    {
        private int userDetailsID = CABEServices.UserDetails.ID;

        public AddRecipePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            App.AddRecipeViewModel = new ViewModels.AddRecipeViewModel();
            //App.AddRecipeViewModel.RefreshMenuAsync();

            BindingContext = App.AddRecipeViewModel;

            base.OnAppearing();
        }
        async void OnSaveRecipeClicked(object sender, EventArgs e)
        {

            var newRecipe = new AddEditRecipe();
            var isNewRecipe = true;
            //var response = "";
            var newUserRecFav = new UserRecipeFavorite();
            newUserRecFav.UserId = userDetailsID;
            newUserRecFav.RecipeId = 0;
            newUserRecFav.Favorite = false;
            newRecipe.userRecipeFavorite = newUserRecFav;

            var tempRecipe = new RecipeVM();
            tempRecipe.OwnerId = userDetailsID;
            tempRecipe.RecipeName = "New Recipe Test 1";
            tempRecipe.Shared = false;
            tempRecipe.MyRating = 0;
            tempRecipe.ShareRating = 0;
            tempRecipe.NumShareRatings = 0;
            tempRecipe.PrepTime = 0;
            tempRecipe.CookTime = 0;
            tempRecipe.RecipeServings = 1;
            newRecipe.recipe = tempRecipe;

            var ingred = new IngredientListVM();
            ingred.IngredName = "Flour";
            ingred.IngredQty = 1;
            ingred.IngredUnit = "cup";
            List<IngredientListVM> ingredientList = new List<IngredientListVM>();
            ingredientList.Add(ingred);


            var step = new RecipeStepIngredientVM();
            step.StepNumber = 1;
            step.Instruction = "Test step instruction 1.";
            step.IngredientList = ingredientList;
            List<RecipeStepIngredientVM> stepList = new List<RecipeStepIngredientVM>();
            stepList.Add(step);
            newRecipe.RecipeStepIngredients = stepList;

            var keyword = new Keyword();
            keyword.SearchWord = "test";
            List<Keyword> keywords = new List<Keyword>();
            keywords.Add(keyword);

            newRecipe.Keywords = keywords;


            //await App.cabeMgr.SaveRecipeAsync(newRecipe, isNewRecipe);

            //var userExists = DoesUserExist(newUser);
            //if (userExists)
            //{
            //    messageLabel.Text = "User name already taken. Please choose a different user name or login as user. ";
            //}
            //if (passwordEntry.Text != passwordEntry2.Text)
            //{
            //    messageLabel.Text = messageLabel.Text + "Passwords do not match. Please re-enter passwords.";
            //}
            //if (!userExists && (passwordEntry.Text == passwordEntry2.Text))
            //{
            //    // Store new user data
            //    var user = new User();
            //    user.ID = 0;
            //    user.UserName = userNameEntry.Text;
            //    user.Password = passwordEntry.Text;
            //    var isNewUser = true;

            //    user = await App.cabeMgr.AddEditUserAsync(user, isNewUser);

            //    if (user.ID != 0)
            //    {
            //        App.IsUserLoggedIn = true;
            //        Navigation.InsertPageBefore(new MainPage(), this);
            //        await Navigation.PopAsync();
            //    }
            //}

            //bool DoesUserExist(UserRegistration user)
            //{
            //    return user.UserNameEntered == Data.CABEServices.UserDetails.UserName;
            //}
        }


        public async void OnLogOutClicked(object sender, EventArgs e)
        {
            Data.CABEServices.UserDetails.Password = "";
            App.IsUserLoggedIn = false;
            App.MainViewModel = null;
            Navigation.InsertPageBefore(new Pages.LoginPage(), this);
            await Navigation.PopAsync();
        }

        private async void OnFavIconClicked(object sender, EventArgs e)
        {
            await App.cabeMgr.FavRecipeToggleAsync(Data.CABEServices.UserDetails.ID.ToString(), App.RecipeViewModel.CurrentRcp.RecipeID);
        }

        private async void OnShareIconClicked(object sender, EventArgs e)
        {
            await App.cabeMgr.ShareRecipeToggleAsync(App.RecipeViewModel.CurrentRcp.RecipeID);
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {

        }
        private void On_Saved(object sender, EventArgs e)
        {

        }
        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}