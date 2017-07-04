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
    public partial class FavoritesPage : ContentPage
    {
        public FavoritesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        //protected async override void OnAppearing()
        {
            this.BindingContext = App.MainViewModel;

            base.OnAppearing();


            //Direct Model usage to ItemSource, needs x:name="favRcpListView" in ListView control if active//
            //favRcpListView.ItemsSource = await App.cabeMgr.RefreshFavRcpAsync(Constants.UserTestID);

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
            App.CurrentRecipe = e.SelectedItem as Recipe;
            Navigation.PushAsync(new Pages.RecipePage());
        }
    }
}