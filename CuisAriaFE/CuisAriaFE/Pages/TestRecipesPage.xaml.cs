using CuisAriaFE;
using CuisAriaFE.Models;
using CuisAriaFE.Data;
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
    public partial class TestRecipesPage : ContentPage
    {
        public TestRecipesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        //protected async override void OnAppearing()
        {

            this.BindingContext = App.MainViewModel;

            base.OnAppearing();

            //Direct Model usage to ItemSource, needs x:name="testRcpListView" in ListView control if active//
            //testRcpListView.ItemsSource = await App.cabeMgr.RefreshMyRcpAsync(Constants.OwnerTestID);
            //testRcpListView.ItemsSource = await App.cabeMgr.RefreshSharedRcpAsync(Constants.UserTestID);
            //testRcpListView.ItemsSource = await App.cabeMgr.RefreshFavRcpAsync(Constants.UserTestID);

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

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var recipeItem = e.SelectedItem as Recipe;
            var recipePage = new RecipePage();
            recipePage.BindingContext = recipeItem;
            Navigation.PushAsync(recipePage);
        }
    }
}