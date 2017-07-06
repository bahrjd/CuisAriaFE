﻿using CuisAriaFE.Data;
using CuisAriaFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CuisAriaFE.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddRecipePage : ContentPage
    {
        private int userDetailsID = CABEServices.UserDetails.ID;
        public IngredientListVM Ingred2List { get; set; }
        public RecipeStepIngredientVM Steps2List { get; set; }

        public AddRecipePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            App.AddRecipeViewModel = new ViewModels.AddRecipeViewModel();
            //App.AddRecipeViewModel.RefreshMenuAsync();

            BindingContext = App.AddRecipeViewModel;

            Ingred2List = new IngredientListVM()
            {
                IngredName = "",
                IngredQty = 0m,
                IngredUnit = ""
            };
            App.AddRecipeViewModel.IngredientsList.Add(Ingred2List);

            Steps2List = new RecipeStepIngredientVM()
            {
                StepNumber = 1,
                Instruction = ""
            };
            App.AddRecipeViewModel.StepIngredList.Add(Steps2List);


            base.OnAppearing();
        }
        async void OnSaveRecipeClicked(object sender, EventArgs e)
        {
            var test = App.AddRecipeViewModel.NewRcp.RecipeName;

            //var AddRcp = new RecipeVM()
            //{
            //    RecipeName = App.AddRecipeViewModel.NewRcp.RecipeName,
            //    Description = "",
            //    OwnerId = userDetailsID,
            //    Shared = false,
            //    Notes = " ",
            //    MyRating = 0,
            //    ShareRating = 0,
            //    NumShareRatings = 0,
            //    RecipePic = " ",
            //    PrepTime = 0,
            //    CookTime = 0,
            //    ServingSize = " "
            //};


            var newRecipe = new AddEditRecipe();
            var isNewRecipe = true;
            var newUserRecFav = new UserRecipeFavorite();
            newUserRecFav.UserId = userDetailsID;
            newUserRecFav.RecipeId = 0;
            newUserRecFav.Favorite = false;
            newRecipe.userRecipeFavorite = newUserRecFav;

            var tempRecipe = new RecipeVM();
            tempRecipe.OwnerId = userDetailsID;
            tempRecipe.RecipeName = App.AddRecipeViewModel.NewRcp.RecipeName;
            tempRecipe.Description = App.AddRecipeViewModel.NewRcp.Description;
            tempRecipe.Shared = false;
            tempRecipe.MyRating = 0;
            tempRecipe.ShareRating = 0m;
            tempRecipe.NumShareRatings = 0m;
            tempRecipe.PrepTime = App.AddRecipeViewModel.NewRcp.PrepTime;
            tempRecipe.CookTime = App.AddRecipeViewModel.NewRcp.CookTime;
            tempRecipe.RecipeServings = App.AddRecipeViewModel.NewRcp.RecipeServings;
            tempRecipe.RecipePic = App.AddRecipeViewModel.NewRcp.RecipePic;

            newRecipe.recipe = tempRecipe;

            List<IngredientListVM> ingredientList = new List<IngredientListVM>();
            foreach (IngredientListVM tempIngred in App.AddRecipeViewModel.IngredientsList)
            {
                var ingred = new IngredientListVM();
                ingred.IngredName = tempIngred.IngredName;
                ingred.IngredQty = tempIngred.IngredQty;
                ingred.IngredUnit = tempIngred.IngredUnit;
                ingredientList.Add(ingred);
            }

            List<RecipeStepIngredientVM> stepList = new List<RecipeStepIngredientVM>();
            foreach (RecipeStepIngredientVM tempStep in App.AddRecipeViewModel.StepIngredList)
            {
                var step = new RecipeStepIngredientVM();
                List<IngredientListVM> emptyList = new List<IngredientListVM>();
                step.StepNumber = tempStep.StepNumber;
                step.Instruction = tempStep.Instruction;
                if (step.StepNumber == 1)
                {
                    step.IngredientList = ingredientList;
                }
                else
                {
                    step.IngredientList = emptyList;
                }
                stepList.Add(step);
            }
            newRecipe.RecipeStepIngredients = stepList;

            var keyword = new Keyword();
            keyword.SearchWord = " ";
            List<Keyword> keywords = new List<Keyword>();
            keywords.Add(keyword);

            newRecipe.Keywords = keywords;

            await App.cabeMgr.SaveRecipeAsync(newRecipe, isNewRecipe);
        }


        public async void OnLogOutClicked(object sender, EventArgs e)
        {
            Data.CABEServices.UserDetails.Password = "";
            App.IsUserLoggedIn = false;
            App.MainViewModel = null;
            Navigation.InsertPageBefore(new Pages.LoginPage(), this);
            await Navigation.PopAsync();
        }

        private async void OnFavIconClicked(object sender, EventArgs e)
        {
            await App.cabeMgr.FavRecipeToggleAsync(Data.CABEServices.UserDetails.ID.ToString(), App.RecipeViewModel.CurrentRcp.RecipeID);
        }

        private async void OnShareIconClicked(object sender, EventArgs e)
        {
            await App.cabeMgr.ShareRecipeToggleAsync(App.RecipeViewModel.CurrentRcp.RecipeID);
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {

        }
        private void On_Saved(object sender, EventArgs e)
        {

        }
        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void OnAddIngredClicked(object sender, EventArgs e)
        {
            Ingred2List = new IngredientListVM()
            {
                IngredName = "",
                IngredQty = 0m,
                IngredUnit = " "
            };
            App.AddRecipeViewModel.IngredientsList.Add(Ingred2List);
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            //DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            //comment out if you want to keep selections
            ListView rcpIngredListView = (ListView)sender;
            rcpIngredListView.SelectedItem = null;

            ListView rcpStepsListView = (ListView)sender;
            rcpStepsListView.SelectedItem = null;
            
        }

        private void OnAddStepClicked(object sender, EventArgs e)
        {
            Steps2List = new RecipeStepIngredientVM()
            {
                StepNumber = 1,
                Instruction = ""
            };
            App.AddRecipeViewModel.StepIngredList.Add(Steps2List);
        }
    }
}