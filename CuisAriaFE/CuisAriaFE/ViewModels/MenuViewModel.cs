using CuisAriaFE.Common;
using CuisAriaFE.Data;
using CuisAriaFE.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CuisAriaFE.ViewModels
{
    public class MenuViewModel : ObservableBase
    {
        private string userDetailsID = CABEServices.UserDetails.ID.ToString();
        private string menuID = "0";

        public MenuViewModel()
        {
            //MenuRcp = new ObservableCollection<Models.MenuRecipe>();
            MenuRcp = new ObservableCollection<MenuRecipe>();
            CurMenu = App.CurrentMenu;
            //{
            //    MenuName = App.CurrentMenu.MenuName,
            //    MenuId = App.CurrentMenu.MenuId
            //};
        }

        private MenuRecipe _curMenu;
        public MenuRecipe CurMenu
        {
            get { return _curMenu; }
            set { SetProperty(ref _curMenu, value); }
        }

        private ObservableCollection<MenuRecipe> _menuRcp;
        public ObservableCollection<MenuRecipe> MenuRcp
        {
            get { return _menuRcp; }
            set { SetProperty(ref _menuRcp, value); }
        }
       
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public async void RefreshMenuAsync()
        {
            IsBusy = true;

            await RefreshMenuRcpAsync();

            IsBusy = false;
        }

        public async Task RefreshMenuRcpAsync()
        {
            MenuRcp.Clear();

            var rcpList = await App.cabeMgr.RefreshMenuRcpAsync(userDetailsID, menuID);

            foreach (var item in rcpList)
            {
                MenuRcp.Add(item);
            }
        }
    }
}