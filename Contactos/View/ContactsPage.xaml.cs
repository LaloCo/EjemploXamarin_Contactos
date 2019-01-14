using System;
using System.Collections.Generic;
using Contactos.Model;
using SQLite;
using Xamarin.Forms;

namespace Contactos.View
{
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            InitializeComponent();
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Contact selectedContact = contactsListView.SelectedItem as Contact;

            Navigation.PushAsync(new ContactDetailsPage(selectedContact));
        }

        void DeleteMenuItem_Handle_Clicked(object sender, System.EventArgs e)
        {
            Contact selectedContact = contactsListView.SelectedItem as Contact;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.Delete(selectedContact);
                Navigation.PopAsync();
            }
        }

        void EditMenuItem_Handle_Clicked(object sender, System.EventArgs e)
        {
            Contact selectedContact = contactsListView.SelectedItem as Contact;
            Navigation.PushAsync(new NewContactPage(selectedContact));
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
