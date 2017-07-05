using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;

namespace CuisAriaFE
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if (App.MainViewModel == null)
            {                               
                App.MainViewModel = new ViewModels.MainViewModel();
                App.MainViewModel.RefreshRcpAsync();
            }
        }

        


        private async void OnSettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.SettingsPage());
        }
        private async void OnNewRecipeClicked(object sender, EventArgs e)
        {
            //App.CurrentRecipe.Favorite = false;
            //App.CurrentRecipe.RecipeID = "";
            //App.CurrentRecipe.RecipeName = "";
            //App.CurrentRecipe.Description = "";
            //App.CurrentRecipe.OwnerId = "";
            //App.CurrentRecipe.Shared = false;
            //App.CurrentRecipe.Notes = "";
            //App.CurrentRecipe.MyRating = 0;
            //App.CurrentRecipe.ShareRating = 0m;
            //App.CurrentRecipe.NumShareRatings = 0m;
            //App.CurrentRecipe.RecipePic = "";
            //App.CurrentRecipe.PrepTime = 0m;
            //App.CurrentRecipe.CookTime = 0m;
            //App.CurrentRecipe.RecipeServings = 0m;
            //App.CurrentRecipe.ServingSize = "";

            await Navigation.PushAsync(new Pages.RecipePage());
        }
        private async void OnAdvancedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.AdvSearchPage());
        }
        private async void OnMenuClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.CurrentMenuPage());
        }
        private async void OnFavoritesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.FavoritesPage());
        }
        public async void OnLogOutClicked(object sender, EventArgs e)
        {
            Data.CABEServices.UserDetails.Password = "";
            App.IsUserLoggedIn = false;
            App.MainViewModel = null;
            Navigation.InsertPageBefore(new Pages.LoginPage(), this);
            await Navigation.PopAsync();
        }
        //{
        //    await Navigation.PushAsync(new Pages.LoginPage());
        //}
        private async void OnShoppingClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.ShoppingListPage());
        }

        //private void MainSearchBar_SearchButtonPressed(object sender, EventArgs e)
        //{
        //    string RecipeKeyWords = MainSearchBar.Text;


        //}
    }
}
