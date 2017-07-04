using CuisAriaFE.Common;
using CuisAriaFE.Models;
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
        public Recipe CurrentRcp;
        public string RecipeName;
                
        public RecipeViewModel()
        {
            CurrentRcp = App.CurrentRecipe;
            RecipeName = CurrentRcp.RecipeName;
            StepRcp = new ObservableCollection<StepIngredients>();
            IngredRcp = new ObservableCollection<Ingredients>();
        }

        //private Recipe _currentRcp;
        //public Recipe CurrentRcp
        //{
        //    get { return _currentRcp; }
        //    set { SetProperty(ref _currentRcp, value); }
        //}

        private ObservableCollection<StepIngredients> _stepRcp;
        public ObservableCollection<StepIngredients> StepRcp
        {
            get { return _stepRcp; }
            set { SetProperty(ref _stepRcp, value); }
        }

        private ObservableCollection<Ingredients> _ingredRcp;
        public ObservableCollection<Ingredients> IngredRcp
        {
            get { return _ingredRcp; }
            set { SetProperty(ref _ingredRcp, value); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public async void RefreshRcpDetailsAsync()
        {
            IsBusy = true;

            //GetRcpAsync();
            await RefreshStepIngredientsAsync();

            IsBusy = false;
        }

        //public void GetRcpAsync()
        //{
        //    CurrentRcp = App.CurrentRecipe;
        //}

        public async Task RefreshStepIngredientsAsync()
        {
            StepRcp.Clear();
            IngredRcp.Clear();

            var stepList = await App.cabeMgr.RefreshStepIngredientsAsync(currentRecipeID);

            foreach (var item in stepList)
            {
                StepRcp.Add(item);
                
                //{
                //    IngredRcp.Add(ingred);
                //}
            }
        }
    }
}
