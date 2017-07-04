using CuisAriaFE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.Models
{
    public class ShoppingList : ObservableBase

    {
        public int ShoppingListId { get; set; }
        public int UserId { get; set; }
        public string ListName { get; set; }

        public List<ShopListItemVM> Items { get; set; }
    }

    public class ShopListItemVM : ObservableBase
    {
        public string ItemName { get; set; }
        public decimal ItemQty { get; set; }
        public string ItemUnit { get; set; }
    }
}
