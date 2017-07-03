using CuisAriaFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.Data
{
    public class CABEMgr
    {
        ICABEServices restService;

        public CABEMgr(ICABEServices service)
        {
            restService = service;
        }

        public Task<List<Recipe>> RefreshMyRcpAsync(string ownerID)
        {
            return restService.RefreshMyRcpAsync(ownerID);
        }

        public Task<List<Recipe>> RefreshSharedRcpAsync(string userID)
        {
            return restService.RefreshSharedRcpAsync(userID);
        }

        public Task<List<Recipe>> RefreshFavRcpAsync(string userID)
        {
            return restService.RefreshFavRcpAsync(userID);
        }

        public Task<Recipe> GetRcpAsync(string userID)
        {
            return restService.GetRcpAsync(userID);
        }
        
        public Task<List<StepIngredients>> RefreshStepIngredientsAsync(string recipeID)
        {
            return restService.RefreshStepIngredientsAsync(recipeID);
        }

        public Task<List<MenuRecipe>> RefreshMenuRcpAsync(string userID, string menuID)
        {
            return restService.RefreshMenuRcpAsync(userID, menuID);
        }

        public Task SaveTaskAsync(Recipe item, bool isNewItem = false)
        {
            return restService.SaveRecipeAsync(item, isNewItem);
        }

        public Task DeleteRecipeAsync(Recipe item)
        {
            return restService.DeleteRecipeAsync(item.UserID);
        }

        public Task GetUserByNameAsync(string userName)
        {
            return restService.GetUserByNameAsync(userName);
        }

        public Task<User> AddEditUserAsync(User user, bool isNew)
        {
            return restService.AddEditUserAsync(user, isNew);
        }
    }
}