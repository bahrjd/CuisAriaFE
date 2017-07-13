﻿using CuisAriaFE.Models;
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
    public partial class RecipePage : ContentPage
    {
        public RecipePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            App.RecipeViewModel = new ViewModels.RecipeViewModel();
            App.RecipeViewModel.RefreshRcpDetailsAsync();
            App.OriginalServings = Data.CABEServices.ItemRcp.RecipeServings;
            App.RecipeViewModel.FavCheck(App.RecipeViewModel.CurrentRcp.Favorite);
            App.RecipeViewModel.ShareCheck(App.RecipeViewModel.CurrentRcp.Shared);

            BindingContext = App.RecipeViewModel;

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {

            base.OnDisappearing();
        }

        private async void OnFavIconClicked(object sender, EventArgs e)
        {
            await App.cabeMgr.FavRecipeToggleAsync(Data.CABEServices.UserDetails.ID.ToString(), App.RecipeViewModel.CurrentRcp.RecipeID);
            App.RecipeViewModel.FavCheck(App.RecipeViewModel.CurrentRcp.Favorite);
            App.RecipeViewModel.RefreshRcpDetailsAsync();
        }

        private async void OnShareIconClicked(object sender, EventArgs e)
        {
            await App.cabeMgr.ShareRecipeToggleAsync(App.RecipeViewModel.CurrentRcp.RecipeID);
            App.RecipeViewModel.ShareCheck(App.RecipeViewModel.CurrentRcp.Shared);
            App.RecipeViewModel.RefreshRcpDetailsAsync();
        }

        private async void OnEditRecipeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.AddRecipePage());
        }

        public AddEditGetMenu RcpToMenu { get; set; }
        public string CurrentUserID = Data.CABEServices.UserDetails.ID.ToString();

        private async void OnAddToMenuClicked(object sender, EventArgs e)
        {
            if (App.CurrentMenu == null)
            {
                // Establish CurrentMenu items
                await App.cabeMgr.RefreshMenuRcpAsync(CurrentUserID, Constants.MenuId);
                App.CurrentMenu = Data.CABEServices.menuRcpList.FirstOrDefault();
                AddRcpToMenu();
            }
            else
            {
                AddRcpToMenu();
            }

            await Navigation.PushAsync(new Pages.CurrentMenuPage());
        }

        public async void AddRcpToMenu()
        {
            RcpToMenu = new AddEditGetMenu()
            {
                MenuId = App.CurrentMenu.MenuId,
                RecipeId = Convert.ToInt32(App.RecipeViewModel.CurrentRcp.RecipeID),
                MenuServings = App.RecipeViewModel.CurrentRcp.RecipeServings,
                UserId = Data.CABEServices.UserDetails.ID,
                MenuName = App.CurrentMenu.MenuName
            };
            await App.cabeMgr.AddEditGetMenuAsync(RcpToMenu);
        }

        //App.MenuViewModel = new ViewModels.MenuViewModel();
        //App.MenuViewModel.RefreshMenuAsync();

        private async void OnInstructionsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.InstructionsPage());
        }

        //private async void OnSettingsClicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new SettingsPage());
        //}

        private async void OnNewRecipeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.AddRecipePage());
        }

        private async void OnMenuClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.CurrentMenuPage());
        }

        private async void OnShoppingClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.ShoppingListPage());
        }

        private async void OnLogOutClicked(object sender, EventArgs e)
        {
            Data.CABEServices.UserDetails.Password = "";
            App.IsUserLoggedIn = false;
            App.MainViewModel = null;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        public decimal ScaleFactor { get; set; }

        private void OnServingsChanged(object sender, TextChangedEventArgs e)
        {
            var currentVal = Decimal.Parse(e.NewTextValue);
            ScaleFactor = App.OriginalServings / currentVal;

            foreach (var item in IngredRcp)
            {
                item.IngredQty *= ScaleFactor;
            }
        }

        //private void OnServingsChanged(object sender, PropertyChangingEventArgs e)
        //{
        //    App.RecipeViewModel.ScaleIngredients();
        //}

    }
}
