using CuisAriaFE.Common;
using CuisAriaFE.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;


namespace CuisAriaFE.ViewModels
{
    public class ShopListViewModel : ObservableBase
    {
        private string userDetailsID = CABEServices.UserDetails.ID.ToString();

        public ShopListViewModel()
        {
            this.ShoppingList = new ObservableCollection<Models.ShopDispItem>();
        }

        private ObservableCollection<Models.ShopDispItem> _shoppingList;
        public ObservableCollection<Models.ShopDispItem> ShoppingList
        {
            get { return this._shoppingList; }
            set { this.SetProperty(ref this._shoppingList, value); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return this._isBusy; }
            set { this.SetProperty(ref this._isBusy, value); }
        }

        public async void RefreshShopListAsync()
        {
            this.IsBusy = true;

            await RefreshShopListItemAsync();

            this.IsBusy = false;
        }

        public async Task RefreshShopListItemAsync()
        {
            this.ShoppingList.Clear();

            var shpList = await App.cabeMgr.RefreshShopListItemAsync(userDetailsID);

            foreach (var item in shpList)
            {
                this.ShoppingList.Add(item);
            }
        }
    }
}