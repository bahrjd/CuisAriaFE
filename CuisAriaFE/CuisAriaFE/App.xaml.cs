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
        public static UserMgr userMgr { get; private set; }
        public static RecipeMgr recipeMgr { get; private set; }

        public App()
        {            

            InitializeComponent();

            userMgr = new UserMgr(new UserREST());
            recipeMgr = new RecipeMgr(new RecipeREST());
            MainPage = new NavigationPage(new CuisAriaFE.MainPage());

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
