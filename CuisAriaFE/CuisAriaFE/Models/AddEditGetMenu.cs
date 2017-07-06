using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.Models
{
    public class AddEditGetMenu
    {
        public int MenuId { get; set; }
        public int RecipeId { get; set; }
        public decimal MenuServings { get; set; }
        public int UserId { get; set; }
        public string MenuName { get; set; }
    }
}
