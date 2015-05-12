using System;
using MarvelPortable.Model;
using Xamarin.Forms;
using XamarinForms.Step3;
using XamarinForms.Step3.Services;

namespace XamarinForms.Step3.Views
{
    public partial class DetailView : ContentPage
    {

        private Character character;

        public DetailView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            character = ((App)Application.Current).SelectedCharacter;
            CharacterName.Text = character.Name;
            CharacterDescription.Text = character.Description;
        }

        public void OnReadTextClicked(object sender, EventArgs e)
        {
            ITextToSpeech speech = DependencyService.Get<ITextToSpeech>();
            speech.Speak(character.Description);
        }
    }
}
