using System;
using MarvelPortable.Model;
using Xamarin.Forms;

namespace XamarinForms.Step2.Views
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
    }
}
