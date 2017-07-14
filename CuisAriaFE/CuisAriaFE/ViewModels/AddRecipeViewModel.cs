using CuisAriaFE.Common;
using CuisAriaFE.Data;
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
        private int userDetailsID = CABEServices.UserDetails.ID;

        public AddRecipeViewModel()
        {
            StepIngredList = new ObservableCollection<RecipeStepIngredientVM>();
            IngredientsList = new ObservableCollection<IngredientListVM>();
            Keywords = new ObservableCollection<Keyword>();

            NewUserRcpFav = new UserRecipeFavorite()
            {
                UserId = userDetailsID,
                Favorite = false,
                RecipeId = 0
            };

            NewRcp = new RecipeVM()
            {
                RecipeName = "",
                Description = "",
                OwnerId = userDetailsID,
                Shared = false,
                Notes = "",
                //MyRating = 0,
                //ShareRating = 0,
                //NumShareRatings = 0,
                RecipePic = "",
                //PrepTime = 0,
                //CookTime = 0,
                ServingSize = ""
            };
        }

        private UserRecipeFavorite _newUserRcpFav;
        public UserRecipeFavorite NewUserRcpFav
        {
            get { return _newUserRcpFav; }
            set { SetProperty(ref _newUserRcpFav, value); }
        }

        private RecipeVM _newRcp;
        public RecipeVM NewRcp
        {
            get { return _newRcp; }
            set { SetProperty(ref _newRcp, value); }
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

        private ObservableCollection<RecipeStepIngredientVM> _stepIngredList;
        public ObservableCollection<RecipeStepIngredientVM> StepIngredList
         {
            get { return _stepIngredList; }
            set { SetProperty(ref _stepIngredList, value); }
        }

        private ObservableCollection<IngredientListVM> _ingredientsList;
        public ObservableCollection<IngredientListVM> IngredientsList
        {
            get { return _ingredientsList; }
            set { SetProperty(ref _ingredientsList, value); }
        }

        private ObservableCollection<Keyword> _keywords;
        public ObservableCollection<Keyword> Keywords
        {
            get { return _keywords; }
            set { SetProperty(ref _keywords, value); }
        }

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