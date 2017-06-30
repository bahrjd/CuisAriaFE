using CuisAriaFE.Common;
using CuisAriaFE.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.ViewModels
{
    public class MainViewModel : ObservableBase
    {
        private string userDetailsID = CABEServices.UserDetails.ID.ToString();
        
        public MainViewModel()
        {
            this.TestRcp = new ObservableCollection<Models.Recipe>();
            this.MyRcp = new ObservableCollection<Models.Recipe>();
            this.SharedRcp = new ObservableCollection<Models.Recipe>();
            this.FavRcp = new ObservableCollection<Models.Recipe>();     
        }

        private ObservableCollection<Models.Recipe> _testRcp;
        public ObservableCollection<Models.Recipe> TestRcp
        {
            get { return this._testRcp; }
            set { this.SetProperty(ref this._testRcp, value); }
        }

        private ObservableCollection<Models.Recipe> _myRcp;
        public ObservableCollection<Models.Recipe> MyRcp
        {
            get { return this._myRcp; }
            set { this.SetProperty(ref this._myRcp, value); }
        }

        private ObservableCollection<Models.Recipe> _sharedRcp;
        public ObservableCollection<Models.Recipe> SharedRcp
        {
            get { return this._sharedRcp; }
            set { this.SetProperty(ref this._sharedRcp, value); }
        }

        private ObservableCollection<Models.Recipe> _favRcp;
        public ObservableCollection<Models.Recipe> FavRcp
        {
            get { return this._favRcp; }
            set { this.SetProperty(ref this._favRcp, value); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return this._isBusy; }
            set { this.SetProperty(ref this._isBusy, value); }
        }

        public async void RefreshRcpAsync()
        {
            this.IsBusy = true;

            await RefreshTestRcpAsync();
            await RefreshMyRcpAsync();
            await RefreshSharedRcpAsync();
            await RefreshFavRcpAsync();

            this.IsBusy = false;
        }

        public async Task RefreshTestRcpAsync()
        {
            this.TestRcp.Clear();

            var rcpList = await App.cabeMgr.RefreshMyRcpAsync(userDetailsID);

            foreach (var item in rcpList)
            {
                this.TestRcp.Add(item);
            }
        }

        public async Task RefreshMyRcpAsync()
        {
            this.MyRcp.Clear();

            var rcpList = await App.cabeMgr.RefreshMyRcpAsync(userDetailsID);

            foreach (var item in rcpList)
            {
                this.MyRcp.Add(item);
            }
        }
        public async Task RefreshSharedRcpAsync()
        {
            this.SharedRcp.Clear();

            var rcpList = await App.cabeMgr.RefreshSharedRcpAsync(userDetailsID);

            foreach (var item in rcpList)
            {
                this.SharedRcp.Add(item);
            }
        }

        public async Task RefreshFavRcpAsync()
        {
            this.FavRcp.Clear();

            var rcpList = await App.cabeMgr.RefreshFavRcpAsync(userDetailsID);

            foreach (var item in rcpList)
            {
                this.FavRcp.Add(item);
            }
        }


    }
}
