using CuisAriaFE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuisAriaFE
{
    public class TTSpeech : ITextToSpeech
    {
        public void Speak(string text)
        {
            Xamarin.Forms.DependencyService.Get<ITextToSpeech>().Speak(text);
        }
    }
}
