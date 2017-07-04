using CuisAriaFE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.Models
{
    public class ShopDispItem : ObservableBase
    {
        public string ItemName { get; set; }
        public decimal ItemQty { get; set; }
        public string ItemUnit { get; set; }
        public string QtyInt { get; set; }
        public string QtyFrac { get; set; }
    }
}
