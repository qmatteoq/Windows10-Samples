using System;
using Windows.Phone.Speech.Synthesis;
using XamarinForms.Step3.Services;
using XamarinForms.Step3.WinPhone.Services;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeech))]
namespace XamarinForms.Step3.WinPhone.Services
{
    public class TextToSpeech: ITextToSpeech
    {
        public async void Speak(string text)
        {
            SpeechSynthesizer speech = new SpeechSynthesizer();
            await speech.SpeakTextAsync(text);
        }
    }
}
