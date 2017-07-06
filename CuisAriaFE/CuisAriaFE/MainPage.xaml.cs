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
            //if (App.MainViewModel == null)
            //{                               
                App.MainViewModel = new ViewModels.MainViewModel();
                App.MainViewModel.RefreshRcpAsync();
            //}
        }

        


        private async void OnSettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.SettingsPage());
        }
        private async void OnNewRecipeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.AddRecipePage());
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
