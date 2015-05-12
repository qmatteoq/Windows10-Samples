using System.Collections.ObjectModel;
using System.Diagnostics;
using MarvelPortable;
using MarvelPortable.Model;
using Xamarin.Forms;
using XamarinForms.Step3.Helpers;

namespace XamarinForms.Step3.Views
{
    public partial class ComicsView : ContentPage
    {
        public ComicsView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            LoadingIndicator.IsRunning = true;

            try
            {
                Character character = ((App) Application.Current).SelectedCharacter;
                MarvelClient client = new MarvelClient(Constants.ApiKey, Constants.PrivateKey);
                ComicResponse response = await client.GetComicsForCharacterAsync(character.Id);
                ObservableCollection<Comic> comics = new ObservableCollection<Comic>(response.Results);
                ComicsList.ItemsSource = comics;
            }
            catch
            {
                Debug.WriteLine("Error parsing the result");
            }

            LoadingIndicator.IsRunning = false;
        }
    }
}
