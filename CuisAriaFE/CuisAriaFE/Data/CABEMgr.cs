﻿using CuisAriaFE.Models;
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

        public Task ShareRecipeToggleAsync(string recipeID)
        {
            return restService.ShareRecipeToggleAsync(recipeID);
        }

        public Task FavRecipeToggleAsync(string userID, string recipeID)
        {
            return restService.FavRecipeToggleAsync(userID, recipeID);
        }
        
        public Task<List<Step>> RefreshStepsAsync(string recipeID)
        {
            return restService.RefreshStepsAsync(recipeID);
        }

        public Task<List<Ingredient>> RefreshIngredientsAsync(string recipeID)
        {
            return restService.RefreshIngredientsAsync(recipeID);
        }

        public Task<List<MenuRecipe>> RefreshMenuRcpAsync(string userID, string menuID)
        {
            return restService.RefreshMenuRcpAsync(userID, menuID);
        }

        public Task<List<ShopListItemVM>> RefreshShopListItemAsync(string userID)
        {
            return restService.RefreshShopListItemAsync(userID);
        }

        public Task AddEditShopListAsync(int userID, int menuID)
        {
            return restService.AddEditShopListAsync(userID, menuID);
        }

        public Task SaveRecipeAsync(AddEditRecipe item, bool isNewItem = false)
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

        public Task<AddEditGetMenu> AddEditGetMenuAsync(AddEditGetMenu rcpToMenu, bool isNew = true)
        {
            return restService.AddEditGetMenuAsync(rcpToMenu, isNew);
        }
    }
}
