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
    public partial class MyRecipesPage : ContentPage
    {
    bool alertShown = false;

    public MyRecipesPage()
    {
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        if (Constants.RestUrl.Contains("developer.xamarin.com"))
        {
            if (!alertShown)
            {
                await DisplayAlert(
                    "Hosted Back-End",
                    "This app is running against Xamarin's read-only REST service. To create, edit, and delete data you must update the service endpoint to point to your own hosted REST service.",
                    "OK");
                alertShown = true;
            }
        }

        myRcpListView.ItemsSource = await App.userMgr.GetTasksAsync();
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
	    }
}