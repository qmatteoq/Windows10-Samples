using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarvelPortable.Model;
using Xamarin.Forms;
using XamarinForms.Step2.Views;

namespace XamarinForms.Step2
{
    public class App : Application
    {
        public Character SelectedCharacter { get; set; }

        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new MainView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
