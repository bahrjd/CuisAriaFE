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
    public partial class CurrentMenuPage : ContentPage
    {
        public CurrentMenuPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        //protected async override void OnAppearing()
        {
            //if (App.MenuViewModel == null)
            //{
                App.MenuViewModel = new ViewModels.MenuViewModel();
                App.MenuViewModel.RefreshMenuAsync();
            //}

            //this.BindingContext = App.MenuViewModel;
            BindingContext = App.MenuViewModel;

            base.OnAppearing();


            //Direct Model usage to ItemSource, needs x:name="myRcpListView" in ListView control if active//
            //myRcpListView.ItemsSource = await App.cabeMgr.RefreshMyRcpAsync(Constants.OwnerTestID);

        }

        private async void OnCreateShoppingListClicked(object sender, EventArgs e)
        {
            if (App.CurrentMenu == null)
            {

                // Establish CurrentMenu items                
                await App.cabeMgr.RefreshMenuRcpAsync(Data.CABEServices.UserDetails.ID.ToString(), Constants.MenuId);
                App.CurrentMenu = Data.CABEServices.menuRcpList.FirstOrDefault();
            }

            await App.cabeMgr.AddEditShopListAsync(Data.CABEServices.UserDetails.ID, App.CurrentMenu.MenuId);
            await Navigation.PushAsync(new ShoppingListPage());

        }

        private async void OnRecipesHomeClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private async void OnNewRecipeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.AddRecipePage());
        }

        private async void OnShoppingClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.ShoppingListPage());
        }

        public async void OnLogOutClicked(object sender, EventArgs e)
        {
            Data.CABEServices.UserDetails.Password = "";
            App.IsUserLoggedIn = false;
            App.MainViewModel = null;
            Navigation.InsertPageBefore(new Pages.LoginPage(), this);
            await Navigation.PopAsync();
        }

        //void OnAddItemClicked(object sender, EventArgs e)
        //{
        //    var user = new User()
        //    {
        //        id = Guid.NewGuid().ToString()
        //    };
        //    var recipePage = new RecipePage(true);
        //    recipePage.BindingContext = user;
        //    Navigation.PushAsync(recipePage);
        //}

        //void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var recipeItem = e.SelectedItem as Recipe;
        //    var recipePage = new RecipePage();
        //    recipePage.BindingContext = recipeItem;
        //    Navigation.PushAsync(recipePage);
        //}

        //private void Button_Clicked(object sender, EventArgs e)
        //{

        //}

    }
}