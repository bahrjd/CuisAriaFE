using CuisAriaFE.Common;
//using CuisAriaFE.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE.ViewModels
{
    public class TestRecipesViewModel : ObservableBase
    {
        public TestRecipesViewModel()
        {
            this.TestRcp = new ObservableCollection<Models.Recipe>();
            //this.TechnologyNews = new ObservableCollection<News.NewsInformation>();
            //this.TrendingNews = new ObservableCollection<News.NewsInformation>();
        }

        private ObservableCollection<Models.Recipe> _testRcp;
        public ObservableCollection<Models.Recipe> TestRcp
        {
            get { return this._testRcp; }
            set { this.SetProperty(ref this._testRcp, value); }
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

            await RefreshMyRcpAsync();
            //await RefreshTechnologyNewsAsync();
            //await RefreshTrendingNewsAsync();

            this.IsBusy = false;
        }

        public async Task RefreshMyRcpAsync()
        {
            this.TestRcp.Clear();

            var rcpList = await App.cabeMgr.RefreshMyRcpAsync(Constants.OwnerTestID);

            foreach (var item in rcpList)
            {
                this.TestRcp.Add(item);
            }
        }


    }
}
