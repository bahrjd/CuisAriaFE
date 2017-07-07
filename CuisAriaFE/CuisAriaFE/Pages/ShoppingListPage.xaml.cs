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
    public partial class ShoppingListPage : ContentPage
    {
        public ShoppingListPage()
        {
            InitializeComponent();
        }

        // Nee to add checkboxes and checkbox onClick processing

        protected override void OnAppearing()
        //protected async override void OnAppearing()
        {
        //    if (App.ShopListViewModel == null)
            //{
                App.ShopListViewModel = new ViewModels.ShopListViewModel();
                App.ShopListViewModel.RefreshShopListAsync();
            //}

            BindingContext = App.ShopListViewModel;

            base.OnAppearing();

        }

        private async void OnRecipesHomeClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private async void OnNewRecipeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.AddRecipePage());
        }

        private async void OnMenuClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.CurrentMenuPage());
        }

        public async void OnLogOutClicked(object sender, EventArgs e)
        {
            Data.CABEServices.UserDetails.Password = "";
            App.IsUserLoggedIn = false;
            App.MainViewModel = null;
            Navigation.InsertPageBefore(new Pages.LoginPage(), this);
            await Navigation.PopAsync();
        }
    }
}