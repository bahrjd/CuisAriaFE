using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.Models
{
    public class User
    {
        public string id { get; set; }

        public string userName { get; set; }

        public string password { get; set; }

        public string email { get; set; }

        public string avatar { get; set; }

        public string userRecipeFavorites { get; set; }

        public string shoppingLists { get; set; }

    }
}
