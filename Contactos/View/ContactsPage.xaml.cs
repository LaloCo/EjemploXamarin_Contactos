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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.ReadContacts();
        }
    }
}
