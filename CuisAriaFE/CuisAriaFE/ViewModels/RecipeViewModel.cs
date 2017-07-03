using CuisAriaFE.Common;
using CuisAriaFE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.ViewModels
{
    public class RecipeViewModel : ObservableBase
    {
        private string currentRecipeID = App.CurrentRecipeId;

        publicRecipeViewModel()
        {
            this.TestRcp = new ObservableCollection<Models.Recipe>();
            this.MyRcp = new ObservableCollection<Models.Recipe>();

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
    }
}
