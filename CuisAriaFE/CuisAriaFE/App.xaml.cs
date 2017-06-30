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
        public static CABEMgr cabeMgr { get; private set; }
        public static ViewModels.MainViewModel MainViewModel { get; set; }

        public App()
        {            
            InitializeComponent();

            MainPage = new NavigationPage(new Pages.LoginPage()) { BackgroundColor = Color.FromHex("#A60000") };
            cabeMgr = new CABEMgr(new CABEServices());           

        }
        
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
