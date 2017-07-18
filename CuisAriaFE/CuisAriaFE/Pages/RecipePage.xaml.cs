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
            App.RecipeViewModel.FavCheck(App.RecipeViewModel.CurrentRcp.Favorite);
            App.RecipeViewModel.ShareCheck(App.RecipeViewModel.CurrentRcp.Shared);

            App.RecipeViewModel.RcpScaleFactor = 1m;
            App.RecipeViewModel.RcpServings = App.RecipeViewModel.CurrentRcp.RecipeServings;

            BindingContext = App.RecipeViewModel;
            rcpIngredListView.ItemsSource = App.RecipeViewModel.IngredRcp;

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
        public int CurrentUserID = Data.CABEServices.UserDetails.ID;

        private async void OnAddToMenuClicked(object sender, EventArgs e)
        {
            RcpToMenu = new AddEditGetMenu()
            {
                RecipeId = Convert.ToInt32(App.RecipeViewModel.CurrentRcp.RecipeID),
                MenuServings = App.RecipeViewModel.CurrentRcp.RecipeServings,
                UserId = Data.CABEServices.UserDetails.ID,
            };
            if (App.CurrentMenu == null)
            {
                var tempMenuId = 0;
                var tempMenuName = "";

                // Establish CurrentMenu
                var menuList = await App.cabeMgr.GetSavedMenusAsync(CurrentUserID);
                if (menuList.Count > 0)
                {
                    foreach (Menu menu in menuList)
                    {
                        if (menu.CurrentMenu == true)
                        {
                            tempMenuId = menu.Id;
                            tempMenuName = menu.MenuName;
                        }
                    }
                }
                RcpToMenu.MenuId = tempMenuId;
                RcpToMenu.MenuName = tempMenuName;
                if (tempMenuId != 0)
                {
                    var tempCurrentMenu = new MenuRecipe();
                    tempCurrentMenu.MenuId = tempMenuId;
                    tempCurrentMenu.MenuName = tempMenuName;
                    App.CurrentMenu = tempCurrentMenu;
                }
                await App.cabeMgr.AddEditGetMenuAsync(RcpToMenu);
            }
            else
            {
                RcpToMenu.MenuName = App.CurrentMenu.MenuName;
                RcpToMenu.MenuId = App.CurrentMenu.MenuId;
                await App.cabeMgr.AddEditGetMenuAsync(RcpToMenu);
            }

            await Navigation.PushAsync(new Pages.CurrentMenuPage());
        }

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

        private async void OnRcpServingsEntry(object sender, EventArgs e)
        {
            if (App.CurrentRecipe.RecipeServings > 0)
            {
                App.RecipeViewModel.RcpScaleFactor = App.RecipeViewModel.RcpServings / App.RecipeViewModel.CurrentRcp.RecipeServings;
            }

            // Update ingredient qtys
            foreach (Ingredient ingred in App.RecipeViewModel.IngredRcp)
            {
                ingred.IngredQty = ingred.IngredQty * App.RecipeViewModel.RcpScaleFactor;
            }
            rcpIngredListView.ItemsSource = null;
            rcpIngredListView.ItemsSource = App.RecipeViewModel.IngredRcp;
            App.RecipeViewModel.CurrentRcp.RecipeServings = App.RecipeViewModel.RcpServings;
        }

        private void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            ((ListView)sender).SelectedItem = null;
        }

        

    }
}
