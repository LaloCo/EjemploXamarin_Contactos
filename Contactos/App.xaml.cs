using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Contactos.View;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Contactos
{
    public partial class App : Application
    {
        public static string DatabasePath;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ContactsPage());
        }

        public App(string databasePath)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ContactsPage());

            DatabasePath = databasePath;
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
