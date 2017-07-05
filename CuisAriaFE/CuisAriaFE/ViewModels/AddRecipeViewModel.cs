using CuisAriaFE.Common;
using CuisAriaFE.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CuisAriaFE.ViewModels
{
    public class AddRecipeViewModel : ObservableBase
    {
        public AddRecipeViewModel()
        {


            NewRcp = new ObservableCollection<AddEditRecipe>();


            //StepRcp = new ObservableCollection<Step>();
            //IngredRcp = new ObservableCollection<Ingredient>();
            //CurrentRcp = new Recipe()
            //{
            //    UserID = App.CurrentRecipe.UserID,
            //    Favorite = App.CurrentRecipe.Favorite,
            //    RecipeID = App.CurrentRecipe.RecipeID,
            //    RecipeName = App.CurrentRecipe.RecipeName,
            //    Description = App.CurrentRecipe.Description,
            //    OwnerId = App.CurrentRecipe.OwnerId,
            //    Shared = App.CurrentRecipe.Shared,
            //    Notes = App.CurrentRecipe.Notes,
            //    MyRating = App.CurrentRecipe.MyRating,
            //    ShareRating = App.CurrentRecipe.ShareRating,
            //    NumShareRatings = App.CurrentRecipe.NumShareRatings,
            //    RecipePic = App.CurrentRecipe.RecipePic,
            //    PrepTime = App.CurrentRecipe.PrepTime,
            //    CookTime = App.CurrentRecipe.CookTime,
            //    ServingSize = App.CurrentRecipe.ServingSize
            //};
        }

        //private Recipe _currentRcp;
        //public Recipe CurrentRcp
        //{
        //    get { return _currentRcp; }
        //    set { SetProperty(ref _currentRcp, value); }
        //}

        private ObservableCollection<AddEditRecipe> _newRcp;
        public ObservableCollection<AddEditRecipe> NewRcp
        {
            get { return _newRcp; }
            set { SetProperty(ref _newRcp, value); }
        }

        //private ObservableCollection<Ingredient> _ingredRcp;
        //public ObservableCollection<Ingredient> IngredRcp
        //{
        //    get { return _ingredRcp; }
        //    set { SetProperty(ref _ingredRcp, value); }
        //}

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        //public async void RefreshRcpDetailsAsync()
        //{
        //    IsBusy = true;

        //    await RefreshStepsAsync();
        //    await RefreshIngredientsAsync();

        //    IsBusy = false;
        //}

        //public async Task RefreshStepsAsync()
        //{
        //    StepRcp.Clear();

        //    var stepList = await App.cabeMgr.RefreshStepsAsync(currentRecipeID);

        //    foreach (var item in stepList)
        //    {
        //        StepRcp.Add(item);
        //    }
        //}

        //public async Task RefreshIngredientsAsync()
        //{
        //    IngredRcp.Clear();

        //    var ingredList = await App.cabeMgr.RefreshIngredientsAsync(currentRecipeID);

        //    foreach (var item in ingredList)
        //    {
        //        IngredRcp.Add(item);
        //    }
        //}
    }
}