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
            //CurrentRcp = new Recipe()
            //{
            //    RecipeName = App.CurrentRecipe.RecipeName;
            //};
  
            StepRcp = new ObservableCollection<Step>();
            IngredRcp = new ObservableCollection<Ingredient>();
        }

        private Recipe _currentrcp;
        public Recipe CurrentRcp
        {
            get { return _currentrcp; }
            set { SetProperty(ref _currentrcp, value); }
        }

        private ObservableCollection<Step> _stepRcp;
        public ObservableCollection<Step> StepRcp
        {
            get { return _stepRcp; }
            set { SetProperty(ref _stepRcp, value); }
        }

        private ObservableCollection<Ingredient> _ingredRcp;
        public ObservableCollection<Ingredient> IngredRcp
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

            // GetRcpAsync();
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
            IngredRcp.Clear();

            var ingredList = await App.cabeMgr.RefreshIngredientsAsync(currentRecipeID);

            foreach (var item in ingredList)
            {
                IngredRcp.Add(item);
            }
        }
    }
}
