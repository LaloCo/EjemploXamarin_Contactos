using System;
using System.Collections.Generic;
using Contactos.Model;
using Contactos.ViewModel;
using SQLite;
using Xamarin.Forms;

namespace Contactos.View
{
    public partial class ContactsPage : ContentPage
    {
        ContactsVM viewModel;

        public ContactsPage()
        {
            InitializeComponent();

            viewModel = Resources["vm"] as ContactsVM;
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Contact selectedContact = contactsListView.SelectedItem as Contact;

            Navigation.PushAsync(new ContactDetailsPage(selectedContact));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.ReadContacts();
        }
    }
}
