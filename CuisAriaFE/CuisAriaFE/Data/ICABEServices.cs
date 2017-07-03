using CuisAriaFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.Data
{
    public interface ICABEServices
    {
        Task<Recipe> GetRcpAsync(string recipeID);

        Task<List<Recipe>> RefreshMyRcpAsync(string ownerID);

        Task<List<Recipe>> RefreshSharedRcpAsync(string userID);

        Task<List<Recipe>> RefreshFavRcpAsync(string userID);

        Task SaveRecipeAsync(Recipe item, bool isNewItem);

        Task DeleteRecipeAsync(string id);

        Task<List<GetRecipeSteps>> RefreshStepsAsync(string recipeID);

        Task<User> GetUserByNameAsync(string userName);

        Task<User> AddEditUserAsync(User user, bool isNew);

        Task<List<MenuRecipe>> RefreshMenuRcpAsync(string userId, string menuID);
    }
}