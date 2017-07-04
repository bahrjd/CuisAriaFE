using CuisAriaFE.Models;
using CuisAriaFE.Data;
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
    public partial class InstructionsPage : ContentPage
    {

        public InstructionsPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            instructionsListView.ItemsSource = await App.cabeMgr.RefreshStepIngredientsAsync(App.CurrentRecipe.RecipeID);
        }

        private void OnInstructionSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var instructionItem = e.SelectedItem as StepIngredients;
            var toSpeak = instructionItem.Instruction;
            var ts = new TTSpeech();
            ts.Speak(toSpeak);
        }
    }
}