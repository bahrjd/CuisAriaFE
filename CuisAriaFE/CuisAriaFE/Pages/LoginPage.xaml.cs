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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnLoginClicked(object sender, EventArgs e)
        {
            var user = new UserLogin
            {
                UserNameEntered = userNameEntry.Text,
                PasswordEntered = passwordEntry.Text
            };

            await App.cabeMgr.GetUserByNameAsync(user.UserNameEntered);

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {                
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }

            //var mainPage = new MainPage();
            //App.cabeMgr.GetUserByNameAsync(userNameEntered);
            //Navigation.PushAsync(mainPage);

        }
        
        bool AreCredentialsCorrect (UserLogin user)
        {
            return user.UserNameEntered == Data.CABEServices.UserDetails.UserName && user.PasswordEntered == Data.CABEServices.UserDetails.Password;
        }

        private void OnGoToRegClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}