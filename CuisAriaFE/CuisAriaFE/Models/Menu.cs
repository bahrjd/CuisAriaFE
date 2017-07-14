using CuisAriaFE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.Models
{
    public class Menu : ObservableBase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public String MenuName { get; set; }
        public bool CurrentMenu { get; set; }
    }
}
