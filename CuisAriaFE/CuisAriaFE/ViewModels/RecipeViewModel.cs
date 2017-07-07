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

            StepRcp = new ObservableCollection<Step>();
            IngredRcp = new ObservableCollection<Ingredient>();
            CurrentRcp = new Recipe()
            {
                UserID = App.CurrentRecipe.UserID,
                Favorite = App.CurrentRecipe.Favorite,
                RecipeID = App.CurrentRecipe.RecipeID,
                RecipeName = App.CurrentRecipe.RecipeName,
                Description = App.CurrentRecipe.Description,
                OwnerId = App.CurrentRecipe.OwnerId,
                Shared = App.CurrentRecipe.Shared,
                Notes = App.CurrentRecipe.Notes,
                MyRating = App.CurrentRecipe.MyRating,
                ShareRating = App.CurrentRecipe.ShareRating,
                NumShareRatings = App.CurrentRecipe.NumShareRatings,
                RecipePic = App.CurrentRecipe.RecipePic,
                PrepTime = App.CurrentRecipe.PrepTime,
                CookTime = App.CurrentRecipe.CookTime,
                RecipeServings = App.CurrentRecipe.RecipeServings,
                ServingSize = App.CurrentRecipe.ServingSize
            };
        }

        private Recipe _currentRcp;
        public Recipe CurrentRcp
        {
            get { return _currentRcp; }
            set { SetProperty(ref _currentRcp, value); }
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

        // Toolbar Icon Visibility Toggles

        private bool _isFav;
        public bool IsFav
        {
            get { return _isFav; }
            set { SetProperty(ref _isFav, value); }
        }

        private bool _isFavVisible;
        public bool IsFavVisible
        {
            get { return _isFavVisible; }
            set { SetProperty(ref _isFavVisible, value); }
        }

        private bool _addFavVisible;
        public bool AddFavVisible
        {
            get { return _addFavVisible; }
            set { SetProperty(ref _addFavVisible, value); }
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

        public void FavCheck(bool IsFav)
        {
            if (IsFav)
            {
                IsFavVisible = true;
                AddFavVisible = false;
            }
            else
            {
                IsFavVisible = false;
                AddFavVisible = true;
            }
        }
    }
}
