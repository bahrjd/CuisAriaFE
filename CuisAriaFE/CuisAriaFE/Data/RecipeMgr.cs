using CuisAriaFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.Data
{
    public class RecipeMgr
    {
        IRecipeREST restService;

        public RecipeMgr(IRecipeREST service)
        {
            restService = service;
        }

        public Task<List<Recipe>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(Recipe item, bool isNewItem = false)
        {
            return restService.SaveRecipeAsync(item, isNewItem);
        }

        public Task DeleteRecipeAsync(Recipe item)
        {
            return restService.DeleteRecipeAsync(item.ID);
        }
    }
}