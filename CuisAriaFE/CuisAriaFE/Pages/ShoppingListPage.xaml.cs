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

        // Add hamburger?
        // Checkbox onClick processing?

        protected override void OnAppearing()
        //protected async override void OnAppearing()
        {
            if (App.ShopListViewModel == null)
            {
                App.ShopListViewModel = new ViewModels.ShopListViewModel();
                App.ShopListViewModel.RefreshShopListAsync();
            }

            this.BindingContext = App.ShopListViewModel;

            base.OnAppearing();

        }








    }
}