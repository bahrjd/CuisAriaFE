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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        async void OnRegisterClicked(object sender, EventArgs e)
        {
            var newUser = new UserRegistration
            {
                UserNameEntered = userNameEntry.Text,
                PasswordEntered = passwordEntry.Text,
                PasswordEntered2 = passwordEntry2.Text
            };

            await App.cabeMgr.GetUserByNameAsync(newUser.UserNameEntered);

            var userExists = DoesUserExist(newUser);
            if (userExists)
            {
                messageLabel.Text = "User name already taken. Please choose a different user name or login as user. ";
            }
            if (passwordEntry.Text != passwordEntry2.Text)
            {
                messageLabel.Text = messageLabel.Text + "Passwords do not match. Please re-enter passwords.";
            }
            if (!userExists && (passwordEntry.Text == passwordEntry2.Text))
            {
                // Store new user data
                var user = new User();
                user.ID = 0;
                user.UserName = userNameEntry.Text;
                user.Password = passwordEntry.Text;
                var isNewUser = true;

                user = await App.cabeMgr.AddEditUserAsync(user, isNewUser);

                if (user.ID != 0)
                {
                    App.IsUserLoggedIn = true;
                    Navigation.InsertPageBefore(new MainPage(), this);
                    await Navigation.PopAsync();
                }
            }

            bool DoesUserExist(UserRegistration user)
            {
                return user.UserNameEntered == Data.CABEServices.UserDetails.UserName;
            }
        }

        async void OnGoToLoginClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }
    }
}