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
    public class RecipeViewModel : ObservableBase
    {
        private string currentRecipeID = App.CurrentRecipe.RecipeID;
        
        public RecipeViewModel()
        {
            this.CurrentRcp = new ObservableCollection<Models.Recipe>();
            this.StepIngredRcp = new ObservableCollection<Models.StepIngredients>();
        }

        private ObservableCollection<Models.Recipe> _currentRcp;
        public ObservableCollection<Models.Recipe> CurrentRcp
        {
            get { return this._currentRcp; }
            set { this.SetProperty(ref this._currentRcp, value); }
        }

        private ObservableCollection<Models.StepIngredients> _stepIngredRcp;
        public ObservableCollection<Models.StepIngredients> StepIngredRcp
        {
            get { return this._stepIngredRcp; }
            set { this.SetProperty(ref this._stepIngredRcp, value); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return this._isBusy; }
            set { this.SetProperty(ref this._isBusy, value); }
        }

        public async void RefreshRcpDetailsAsync()
        {
            this.IsBusy = true;

            await GetRcpAsync();
            await RefreshStepIngredientsAsync();

            this.IsBusy = false;
        }

        public async Task GetRcpAsync()
        {
            this.CurrentRcp.Clear();

            // this.CurrentRcp = await App.cabeMgr.GetRcpAsync(currentRecipeID);                       
        }

        public async Task RefreshStepIngredientsAsync()
        {
            this.StepIngredRcp.Clear();

            var rcpList = await App.cabeMgr.RefreshStepIngredientsAsync(currentRecipeID);

            foreach (var item in rcpList)
            {
                this.StepIngredRcp.Add(item);
            }
        }
    }
}
