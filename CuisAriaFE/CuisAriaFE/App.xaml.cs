using CuisAriaFE.Data;
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
        public static CABEMgr cabeMgr { get; private set; }
        public static ViewModels.MainViewModel MainViewModel { get; set; }

        public App()
        {
            InitializeComponent();

            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new Pages.LoginPage()) { BackgroundColor = Color.FromHex("#C0C0C0"), BarBackgroundColor = Color.FromHex("#9A6AD6"), BarTextColor = Color.FromHex("#FFE900") };
            }
            else
            {
                MainPage = new NavigationPage(new MainPage()) { BackgroundColor = Color.FromHex("#C0C0C0"), BarBackgroundColor = Color.FromHex("#9A6AD6"), BarTextColor = Color.FromHex("#FFE900") };
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
