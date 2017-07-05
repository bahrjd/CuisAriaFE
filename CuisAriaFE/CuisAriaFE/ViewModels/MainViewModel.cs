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
            //TestRcp = new ObservableCollection<Models.Recipe>();
            MyRcp = new ObservableCollection<Models.Recipe>();
            SharedRcp = new ObservableCollection<Models.Recipe>();
            FavRcp = new ObservableCollection<Models.Recipe>();     
        }

        //private ObservableCollection<Models.Recipe> _testRcp;
        //public ObservableCollection<Models.Recipe> TestRcp
        //{
        //    get { return _testRcp; }
        //    set { SetProperty(ref _testRcp, value); }
        //}

        private ObservableCollection<Models.Recipe> _myRcp;
        public ObservableCollection<Models.Recipe> MyRcp
        {
            get { return _myRcp; }
            set { SetProperty(ref _myRcp, value); }
        }

        private ObservableCollection<Models.Recipe> _sharedRcp;
        public ObservableCollection<Models.Recipe> SharedRcp
        {
            get { return _sharedRcp; }
            set { SetProperty(ref _sharedRcp, value); }
        }

        private ObservableCollection<Models.Recipe> _favRcp;
        public ObservableCollection<Models.Recipe> FavRcp
        {
            get { return _favRcp; }
            set { SetProperty(ref _favRcp, value); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public async void RefreshRcpAsync()
        {
            IsBusy = true;

            //await RefreshTestRcpAsync();
            await RefreshMyRcpAsync();
            await RefreshSharedRcpAsync();
            await RefreshFavRcpAsync();

            IsBusy = false;
        }

        //public async Task RefreshTestRcpAsync()
        //{
        //    TestRcp.Clear();

        //    var rcpList = await App.cabeMgr.RefreshMyRcpAsync(userDetailsID);

        //    foreach (var item in rcpList)
        //    {
        //        TestRcp.Add(item);
        //    }
        //}

        public async Task RefreshMyRcpAsync()
        {
            MyRcp.Clear();

            var rcpList = await App.cabeMgr.RefreshMyRcpAsync(userDetailsID);

            foreach (var item in rcpList)
            {
                MyRcp.Add(item);
            }
        }
        public async Task RefreshSharedRcpAsync()
        {
            SharedRcp.Clear();

            var rcpList = await App.cabeMgr.RefreshSharedRcpAsync(userDetailsID);

            foreach (var item in rcpList)
            {
                SharedRcp.Add(item);
            }
        }

        public async Task RefreshFavRcpAsync()
        {
            FavRcp.Clear();

            var rcpList = await App.cabeMgr.RefreshFavRcpAsync(userDetailsID);

            foreach (var item in rcpList)
            {
                FavRcp.Add(item);
            }
        }


    }
}
