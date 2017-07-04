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
                        
        public RecipeViewModel()
        {
            CurrentRcp = new Recipe()
            {
                RecipeName = App.CurrentRecipe;
            };
  
            StepRcp = new ObservableCollection<StepIngredients>();
            IngredRcp = new ObservableCollection<Ingredients>();
        }

        private Recipe _currentrcp;
        public Recipe CurrentRcp
        {
            get { return _currentrcp; }
            set { SetProperty(ref _currentrcp, value); }
        }

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

            GetRcpAsync();
            await RefreshStepsAsync();
            await RefreshIngredientsAsync();
            
            IsBusy = false;
        }

        public async Task RefreshStepsAsync()
        {
            StepRcp.Clear();

            var stepList = await App.cabeMgr.RefreshStepsAsync(currentRecipeID);

            foreach (var item in stepList)
            {
                StepRcp.Add(item);
            }
        }

        public async Task RefreshIngredientsAsync()
        {
            StepRcp.Clear();
            IngredRcp.Clear();

            var ingredList = await App.cabeMgr.RefreshIngredientsAsync(currentRecipeID);

            foreach (var item in ingredList)
            {
                IngredRcp.Add(item);
            }
        }
    }
}
