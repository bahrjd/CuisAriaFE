using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Speech.Tts;
using CuisAriaFE.Interfaces;
using Xamarin.Forms;
using CuisAriaFE.Droid.DependencyServices;

[assembly: Xamarin.Forms.Dependency(typeof(Speech))]
namespace CuisAriaFE.Droid.DependencyServices
{
    public class Speech : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        TextToSpeech textToSpeech;
        string toSpeak;

        public void Speak(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                toSpeak = text;
                if (textToSpeech == null)
                {
                    textToSpeech = new TextToSpeech(Forms.Context, this);
                }
                else
                {
                    var p = new Dictionary<string, string>();
                    textToSpeech.Speak(toSpeak, QueueMode.Flush, p);
                }
            }
        }

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                var p = new Dictionary<string, string>();
                textToSpeech.Speak(toSpeak, QueueMode.Flush, p);
            }
        }
    }
}