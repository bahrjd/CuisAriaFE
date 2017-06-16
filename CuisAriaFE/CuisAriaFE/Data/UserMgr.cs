using CuisAriaFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.Data
{
    public class UserMgr
    {
        IUserREST restService;

        public UserMgr(IUserREST service)
        {
            restService = service;
        }

        public Task<List<User>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(User item, bool isNewItem = false)
        {
            return restService.SaveUserAsync(item, isNewItem);
        }

        public Task DeleteTaskAsync(User item)
        {
            return restService.DeleteUserAsync(item.id);
        }
    }
}