using CuisAriaFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.Data
{
    public interface IUserREST
    {
        Task<List<User>> RefreshDataAsync();

        Task SaveUserAsync(User item, bool isNewItem);

        Task DeleteUserAsync(string id);
    }
}