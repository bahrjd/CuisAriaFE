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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = App.RecipeViewModel;
            //Title = App.RecipeViewModel.StepRcp.FirstOrDefault().StepNumber;
            // instructionsListView.ItemsSource = await App.cabeMgr.RefreshStepsAsync(App.CurrentRecipe.RecipeID);
        }

        //private void OnInstructionSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var instructionItem = e.SelectedItem as Step;
        //    var toSpeak = instructionItem.Instruction;
        //    var ts = new TTSpeech();
        //    ts.Speak(toSpeak);
        //}

        //void ConfigureButtons()
        //{
        //    prevBtn.IsVisible = App.RecipeViewModel.Position > 0;
        //    nextBtn.IsVisible = _vm.Position < _vm.ItemsSource?.Count - 1;
        //}

        //public void PositionSelected(object sender, int position)
        //{
        //    ConfigureButtons();
        //    Debug.WriteLine("Position " + myCarousel.Position + " selected");

        //}

        //public void OnPrev(object sender, TappedEventArgs e)
        //{
        //    if (stepCarousel.Position > 0)
        //        stepCarousel.Position--;
        //}

        //public void OnNext(object sender, TappedEventArgs e)
        //{
        //    if (stepCarousel.Position < stepCarousel.ItemsSource?.Count - 1)
        //        stepCarousel.Position++;
        //}
    }
}