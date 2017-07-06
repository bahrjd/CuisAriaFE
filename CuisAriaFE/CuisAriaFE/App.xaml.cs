using CuisAriaFE.Data;
using CuisAriaFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;


namespace CuisAriaFE
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public static Recipe CurrentRecipe { get; set; }
        public static UserRecipeFavorite NewUserRecipeFav { get; set; }
        public static RecipeVM NewRecipe { get; set; }
        public static MenuRecipe CurrentMenu { get; set; }
        public static CABEMgr cabeMgr { get; private set; }
        public static ViewModels.MainViewModel MainViewModel { get; set; }
        public static ViewModels.MenuViewModel MenuViewModel { get; set; }
        public static ViewModels.RecipeViewModel RecipeViewModel { get; set; }
        public static ViewModels.ShopListViewModel ShopListViewModel { get; set; }
        public static ViewModels.AddRecipeViewModel AddRecipeViewModel { get; set; }
        public static string shopListName { get; set; }

        public App()
        {
            InitializeComponent();

            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new Pages.LoginPage()) { BackgroundColor = Color.FromHex("#FAF8FA"), BarBackgroundColor = Color.FromHex("#9A6AD6"), BarTextColor = Color.FromHex("#FFE900") };
            }
            else
            {
                MainPage = new NavigationPage(new MainPage()) { BackgroundColor = Color.FromHex("#FAF8FA"), BarBackgroundColor = Color.FromHex("#9A6AD6"), BarTextColor = Color.FromHex("#FFE900") };
            }

            cabeMgr = new CABEMgr(new CABEServices());        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
