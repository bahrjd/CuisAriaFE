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
	public class UserREST : IUserREST
{
    HttpClient client;

    public List<User> Items { get; private set; }

    public UserREST()
    {
        // var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
        // var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

        client = new HttpClient();
        client.MaxResponseContentBufferSize = 256000;
        // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
    }

    public async Task<List<User>> RefreshDataAsync()
    {
        Items = new List<User>();

            // RestUrl = http://cuisariabe.azurewebsites.net/api/users
            var uri = new Uri(string.Format(Constants.UserByNameUrl, string.Empty));

        try
        {
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Items = JsonConvert.DeserializeObject<List<User>>(content);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"				ERROR {0}", ex.Message);
        }

        return Items;
    }

    public async Task SaveUserAsync(User item, bool isNewItem = false)
    {
            // RestUrl = http://cuisariabe.azurewebsites.net/api/users
            var uri = new Uri(string.Format(Constants.UserByNameUrl, item.id));

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

    public async Task DeleteUserAsync(int id)
    {
            // RestUrl = http://cuisariabe.azurewebsites.net/api/users
            var uri = new Uri(string.Format(Constants.UserByNameUrl, id.ToString()));

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
