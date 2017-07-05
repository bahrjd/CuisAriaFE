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
            //if (App.CurrentRecipe.RecipeID == "")
            //{
            //    // Instantiate local recipe variable?
            //}
            //else
            //{
                App.RecipeViewModel.RefreshRcpDetailsAsync();
            //}
            
            BindingContext = App.RecipeViewModel;
            //rcpNameLabel.Text = App.CurrentRecipe.RecipeName;

            

            base.OnAppearing();

            // rcpIngredTestLisView.ItemsSource = await App.cabeMgr.GetStepsAsync(App.CurrentRecipe.RecipeID);
            // rcpInstructTestListView.ItemsSource = rcpIngredTestLisView.ItemsSource;
        }

        private async void OnFavIconClicked(object sender, EventArgs e)
        {
            await App.cabeMgr.FavRecipeToggleAsync(Data.CABEServices.UserDetails.ID.ToString(), App.RecipeViewModel.CurrentRcp.RecipeID);
        }

        private async void OnShareIconClicked(object sender, EventArgs e)
        {
            await App.cabeMgr.ShareRecipeToggleAsync(App.RecipeViewModel.CurrentRcp.RecipeID);
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
        }
        
        public void AddRcpToMenu()
        {
            RcpToMenu = new AddEditGetMenu()
            {
                MenuId = App.CurrentMenu.MenuId.ToString(),
                RecipeId = App.RecipeViewModel.CurrentRcp.RecipeID,
                MenuServings = App.RecipeViewModel.CurrentRcp.RecipeServings,
                UserId = CurrentUserID,
                MenuName = "Menu"
            };



        }
        
        //App.MenuViewModel = new ViewModels.MenuViewModel();
        //App.MenuViewModel.RefreshMenuAsync();

        private async void OnInstructionsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.InstructionsPage());
        }

        private async void OnSettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        private async void OnLogOutClicked(object sender, EventArgs e)
        {
            Data.CABEServices.UserDetails.Password = "";
            App.IsUserLoggedIn = false;
            App.MainViewModel = null;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }
    }
}