using CuisAriaFE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.Data
{
	public class CABEServices : ICABEServices
    {
        HttpClient client;

        public Recipe ItemRcp { get; private set; }

        public List<Recipe> ItemsMyRcp { get; private set; }

        public List<Recipe> ItemsSharedRcp { get; private set; }

        public List<Recipe> ItemsFavRcp { get; private set; }

        public List<GetRecipeSteps> RecipeSteps { get; private set; }

        public static User UserDetails { get; private set; }

        public List<MenuRecipe> menuRcpList { get; private set; }

        public ShoppingList shopList { get; private set; }

        public List<ShopDispItem> shopItemList { get; private set; }

        //public string shopListName { get; set; }



        // Connection Service
        public CABEServices()
        {
        // Values for BasicAuth
        // var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
        // var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

        client = new HttpClient();
        client.MaxResponseContentBufferSize = 256000;
        // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public async Task<Recipe> GetRcpAsync(string recipeID)
        {
            ItemRcp = new Recipe();

            var uri = new Uri(string.Format(Constants.RcpUrl, recipeID));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ItemRcp = JsonConvert.DeserializeObject<Recipe>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return ItemRcp;
        }
        
        public async Task<List<Recipe>> RefreshMyRcpAsync(string ownerID)
    {
            ItemsMyRcp = new List<Recipe>();

            var uri = new Uri(string.Format(Constants.MyRcpUrl, ownerID));

        try
        {
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                ItemsMyRcp = JsonConvert.DeserializeObject<List<Recipe>>(content);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"				ERROR {0}", ex.Message);
        }

        return ItemsMyRcp;
    }

        public async Task<List<Recipe>> RefreshSharedRcpAsync(string userID)
        {
            ItemsSharedRcp = new List<Recipe>();

            var uri = new Uri(string.Format(Constants.SharedRcpUrl, userID));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ItemsSharedRcp = JsonConvert.DeserializeObject<List<Recipe>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return ItemsSharedRcp;
        }

        public async Task<List<Recipe>> RefreshFavRcpAsync(string userID)
        {
            ItemsFavRcp = new List<Recipe>();

            var uri = new Uri(string.Format(Constants.FavRcpUrl, userID));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ItemsFavRcp = JsonConvert.DeserializeObject<List<Recipe>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return ItemsFavRcp;
        }

        public async Task<List<GetRecipeSteps>> RefreshStepsAsync(string recipeID)
        {
        RecipeSteps = new List<GetRecipeSteps>();

            var uri = new Uri(string.Format(Constants.RcpStepsUrl, recipeID));

        try
        {
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                RecipeSteps = JsonConvert.DeserializeObject<List<GetRecipeSteps>>(content);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"				ERROR {0}", ex.Message);
        }

        return RecipeSteps;
        }


        public async Task SaveRecipeAsync(Recipe item, bool isNewItem = false)
        {
            // RestUrl = http://cuisariabe.azurewebsites.net/api/recipes
            var uri = new Uri(string.Format(Constants.RcpUrl, item.UserID));

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				TodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        public async Task DeleteRecipeAsync(string ID)
        {
            // RestUrl = http://cuisariabe.azurewebsites.net/api/recipes
            var uri = new Uri(string.Format(Constants.RcpUrl, ID));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				TodoItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        public async Task<User> GetUserByNameAsync(string userName)
        {
            UserDetails = new User();

            var uri = new Uri(string.Format(Constants.UserByNameUrl, userName));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    UserDetails = JsonConvert.DeserializeObject<User>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return UserDetails;
        }

        public async Task<User> AddEditUserAsync(User user, bool isNewItem = false)
        {
            UserDetails = new User();
            var uri = new Uri(string.Format(Constants.UserAddEditUrl));

            try
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var newUser = await response.Content.ReadAsStringAsync();
                        UserDetails = JsonConvert.DeserializeObject<User>(newUser);
                    }

                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				new user successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return UserDetails;

        }

        public async Task<List<MenuRecipe>> RefreshMenuRcpAsync(string userID, string menuID)
        {
            menuRcpList = new List<MenuRecipe>();

            var uri = new Uri(string.Format(Constants.MenuRcpUrl, userID, menuID));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    menuRcpList = JsonConvert.DeserializeObject<List<MenuRecipe>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return menuRcpList;
        }

        public async Task<List<ShopDispItem>> RefreshShopListItemAsync(string userID)
        {
            shopList = new ShoppingList();
            shopItemList = new List<ShopDispItem>();

            var uri = new Uri(string.Format(Constants.ShopListUrl, userID));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    shopList = JsonConvert.DeserializeObject<ShoppingList>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            App.shopListName = shopList.ListName;
            List<ShopListItemVM> tempShopItemList = new List<ShopListItemVM>();
            tempShopItemList = shopList.Items;

            // Convert decimal numbers to fractions for display
            foreach (ShopListItemVM item in tempShopItemList)
            {
                var tempShopDispItem = new ShopDispItem();
                var fracListIndex = (int)((8 * (item.ItemQty % 1)) - 1);
                tempShopDispItem.ItemName  = item.ItemName;
                tempShopDispItem.ItemUnit = item.ItemUnit;
                tempShopDispItem.ItemQty = item.ItemQty;
                tempShopDispItem.QtyInt  = Math.Truncate(item.ItemQty).ToString();
                if (fracListIndex >= 0)
                {
                    tempShopDispItem.QtyFrac = Constants.FracList[fracListIndex];
                } else
                {
                    tempShopDispItem.QtyFrac = " ";
                }
                shopItemList.Add(tempShopDispItem);
            }

            return shopItemList;
        }
    }
}
