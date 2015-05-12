using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MarvelPortable;
using MarvelPortable.Model;
using Xamarin.Forms;
using XamarinForms.Step4.Helpers;

namespace XamarinForms.Step4.Views
{
    public partial class MainView : ContentPage
    {

        private bool isFirstLoad;

        public MainView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            if (!isFirstLoad)
            {
                LoadingIndicator.IsRunning = true;

                MarvelClient client = new MarvelClient(Constants.ApiKey, Constants.PrivateKey);
                CharacterResponse response = await client.GetCharactersForSeriesAsync(1067);
                IEnumerable<Character> filteredList = response.Results.Where(x => x.Thumbnail != null);
                ObservableCollection<Character> characters = new ObservableCollection<Character>(filteredList);
                CharactersList.ItemsSource = characters;

                LoadingIndicator.IsRunning = false;
                isFirstLoad = true;
            }
        }

        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Character character = CharactersList.SelectedItem as Character;
            if (character != null)
            {
                ((App)Application.Current).SelectedCharacter = character;

                TabbedPage tabbedPage = new TabbedPage();
                tabbedPage.Children.Add(new DetailView());
                tabbedPage.Children.Add(new ComicsView());
                tabbedPage.Title = character.Name;

                await Navigation.PushAsync(tabbedPage);
            }
        }

        private async void OnSearchClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }
    }
}
