using System;
using System.Collections.Generic;
using Contactos.Model;
using Xamarin.Forms;

namespace Contactos.View
{
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewContactPage(), true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable(typeof(Contact));
                var contactos = conn.Table<Contact>().ToList();

                contactsListView.ItemsSource = contactos;
            }
        }
    }
}
