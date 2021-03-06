﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.Models
{
    public class User
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Avatar { get; set; }

        //public string UserRecipeFavorites { get; set; }

        //public string ShoppingLists { get; set; }

    }

    public class UserLogin
    {
        public string UserNameEntered { get; set; }

        public string PasswordEntered { get; set; }
    }

    public class UserRegistration
    {
        public string UserNameEntered { get; set; }

        public string PasswordEntered { get; set; }

        public string PasswordEntered2 { get; set; }

    }
}
