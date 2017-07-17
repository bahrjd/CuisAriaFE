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

        private int _ingredHeight;
        public int IngredHeight
        {
            get { return _ingredHeight; }
            set { SetProperty(ref _ingredHeight, value); }
        }

        private int _stepHeight;
        public int StepHeight
        {
            get { return _stepHeight; }
            set { SetProperty(ref _stepHeight, value); }
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

        private bool _isShared;
        public bool IsShared
        {
            get { return _isShared; }
            set { SetProperty(ref _isShared, value); }
        }

        private bool _isSharedVisible;
        public bool IsSharedVisible
        {
            get { return _isSharedVisible; }
            set { SetProperty(ref _isSharedVisible, value); }
        }

        private bool _addSharedVisible;
        public bool AddSharedVisible
        {
            get { return _addSharedVisible; }
            set { SetProperty(ref _addSharedVisible, value); }
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
            StepHeight = 15;

            var stepList = await App.cabeMgr.RefreshStepsAsync(currentRecipeID);

            foreach (var item in stepList)
            {
                StepRcp.Add(item);
                StepHeight += (Constants.rcpDispRowHeight * ((item.Instruction.Length / Constants.rcpStepCharsPerLine) + 1) + 10); 
            }
        }

        public async Task RefreshIngredientsAsync()
        {
            IngredRcp.Clear();
            IngredHeight = 30;

            var ingredList = await App.cabeMgr.RefreshIngredientsAsync(currentRecipeID);
            
            foreach (var item in ingredList)
            {
                IngredRcp.Add(item);
                IngredHeight += Constants.rcpDispRowHeight * ((item.IngredName.Length / Constants.rcpIngredCharsPerLine) + 1);
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

        public void ShareCheck(bool IsShared)
        {
            if (Data.CABEServices.UserDetails.ID.ToString() == CurrentRcp.OwnerId)
            {
                if (IsShared)
                {
                    IsSharedVisible = true;
                    AddSharedVisible = false;
                }
                else
                {
                    IsSharedVisible = false;
                    AddSharedVisible = true;
                }
            }
            else
            {
                IsSharedVisible = false;
                AddSharedVisible = false;
            }

        }
 
    }
}
