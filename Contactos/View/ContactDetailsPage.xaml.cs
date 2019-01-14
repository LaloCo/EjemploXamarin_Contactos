using System;
using System.Collections.Generic;
using Contactos.Model;
using Contactos.ViewModel;
using SQLite;
using Xamarin.Forms;

namespace Contactos.View
{
    public partial class ContactDetailsPage : ContentPage
    {
        ContactDetailsVM viewModel;

        public ContactDetailsPage()
        {
            InitializeComponent();
        }

        public ContactDetailsPage(Contact selectedContact)
        {
            InitializeComponent();

            viewModel = Resources["vm"] as ContactDetailsVM;

            viewModel.SelectedContact = selectedContact;
        }
    }
}
