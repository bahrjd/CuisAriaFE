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

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            rcpIngredTestLisView.ItemsSource = await App.cabeMgr.GetStepsAsync(Constants.RecipeTestID);
            rcpInstructTestListView.ItemsSource = rcpIngredTestLisView.ItemsSource;
        }

        private async void EditRecipeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.AddRecipePage());
        }

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