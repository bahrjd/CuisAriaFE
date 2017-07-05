using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.Models
{
    public class AddEditGetMenu
    {
        public string MenuId { get; set; }
        public string RecipeId { get; set; }
        public decimal MenuServings { get; set; }
        public string UserId { get; set; }
        public string MenuName { get; set; }
    }
}
