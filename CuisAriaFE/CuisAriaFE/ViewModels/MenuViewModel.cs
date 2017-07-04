using CuisAriaFE.Common;
using CuisAriaFE.Data;
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
            this.MenuRcp = new ObservableCollection<Models.MenuRecipe>();
        }

        private ObservableCollection<Models.MenuRecipe> _menuRcp;
        public ObservableCollection<Models.MenuRecipe> MenuRcp
        {
            get { return this._menuRcp; }
            set { this.SetProperty(ref this._menuRcp, value); }
        }
       
        private bool _isBusy;
        public bool IsBusy
        {
            get { return this._isBusy; }
            set { this.SetProperty(ref this._isBusy, value); }
        }

        public async void RefreshMenuAsync()
        {
            this.IsBusy = true;

            await RefreshMenuRcpAsync();

            this.IsBusy = false;
        }

        public async Task RefreshMenuRcpAsync()
        {
            this.MenuRcp.Clear();

            var rcpList = await App.cabeMgr.RefreshMenuRcpAsync(userDetailsID, menuID);

            foreach (var item in rcpList)
            {
                this.MenuRcp.Add(item);
            }
        }
    }
}