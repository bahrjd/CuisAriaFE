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
            if (App.MenuViewModel == null)
            {
                App.MenuViewModel = new ViewModels.MenuViewModel();
                App.MenuViewModel.RefreshMenuAsync();
            }

            this.BindingContext = App.MenuViewModel;

            base.OnAppearing();


            //Direct Model usage to ItemSource, needs x:name="myRcpListView" in ListView control if active//
            //myRcpListView.ItemsSource = await App.cabeMgr.RefreshMyRcpAsync(Constants.OwnerTestID);

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