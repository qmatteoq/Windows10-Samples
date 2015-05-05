using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Marvelpedia.Windows10.Helpers;
using MarvelPortable;
using MarvelPortable.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Marvelpedia.Windows10.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            IsLoading.IsActive = true;

            MarvelClient client = new MarvelClient(Constants.ApiKey, Constants.PrivateKey);
            CharacterResponse response = await client.GetCharactersForSeriesAsync(1067);
            IEnumerable<Character> filteredList = response.Results.Where(x => x.Thumbnail != null);
            ObservableCollection<Character> characters = new ObservableCollection<Character>(filteredList);
            CharactersView.ItemsSource = characters;

            IsLoading.IsActive = false;
        }
    }
}
