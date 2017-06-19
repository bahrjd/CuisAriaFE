using CuisAriaFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.Data
{
    public interface IRecipeREST
    {
        Task<List<Recipe>> RefreshDataAsync();

        Task SaveRecipeAsync(Recipe item, bool isNewItem);

        Task DeleteRecipeAsync(string id);
    }
}