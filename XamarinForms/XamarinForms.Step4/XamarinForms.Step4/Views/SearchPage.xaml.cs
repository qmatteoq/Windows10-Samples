using System;
using System.Collections.ObjectModel;
using MarvelPortable;
using MarvelPortable.Model;
using Xamarin.Forms;
using XamarinForms.Step4.Helpers;

namespace XamarinForms.Step4.Views
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        public async void OnSearchClicked(object sender, EventArgs e)
        {
            MarvelClient client = new MarvelClient(Constants.ApiKey, Constants.PrivateKey);
            CharacterResponse response = await client.GetCharactersAsync(SearchText.Text);
            ObservableCollection<Character> characters = new ObservableCollection<Character>(response.Results);
            CharactersList.ItemsSource = characters;
        }
    }
}
