using AVFoundation;
using XamarinForms.Step3.iOS.Services;
using XamarinForms.Step3.Services;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeech))]
namespace XamarinForms.Step3.iOS.Services
{
    public class TextToSpeech: ITextToSpeech
    {
        public TextToSpeech()
        {
            
        }

        public void Speak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();

            var speechUtterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                Volume = 0.5f,
                PitchMultiplier = 1.0f
            };

            speechSynthesizer.SpeakUtterance(speechUtterance);
        }
    }
}