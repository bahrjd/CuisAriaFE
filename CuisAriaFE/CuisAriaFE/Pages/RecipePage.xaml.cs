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

            BindingContext = App.RecipeViewModel;

            base.OnAppearing();
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

            await Navigation.PushAsync(new Pages.CurrentMenuPage());
        }

        public async void AddRcpToMenu()
        {
            RcpToMenu = new AddEditGetMenu()
            {
                MenuId = App.CurrentMenu.MenuId,
                RecipeId = Convert.ToInt32(App.RecipeViewModel.CurrentRcp.RecipeID),
                MenuServings = 4m,
                UserId = Data.CABEServices.UserDetails.ID,
                MenuName = "Menu"
            };
            await App.cabeMgr.AddEditGetMenuAsync(RcpToMenu);
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
