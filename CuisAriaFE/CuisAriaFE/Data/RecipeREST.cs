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
	public class RecipeREST : IRecipeREST
{
    HttpClient client;

    public List<Recipe> Items { get; private set; }

    public RecipeREST()
    {
        // var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
        // var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

        client = new HttpClient();
        client.MaxResponseContentBufferSize = 256000;
        // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
    }

    public async Task<List<Recipe>> RefreshDataAsync()
    {
        Items = new List<Recipe>();

            // RestUrl = http://cuisariabe.azurewebsites.net/api/recipes
            var uri = new Uri(string.Format(Constants.RecipeUrl, string.Empty));

        try
        {
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Items = JsonConvert.DeserializeObject<List<Recipe>>(content);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"				ERROR {0}", ex.Message);
        }

        return Items;
    }

    public async Task SaveRecipeAsync(Recipe item, bool isNewItem = false)
    {
            // RestUrl = http://cuisariabe.azurewebsites.net/api/recipes
            var uri = new Uri(string.Format(Constants.RecipeUrl, item.ID));

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
            var uri = new Uri(string.Format(Constants.RecipeUrl, ID));

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
}
}
