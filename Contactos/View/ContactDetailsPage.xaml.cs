using System;
using System.Collections.Generic;
using Contactos.Model;
using Xamarin.Forms;

namespace Contactos.View
{
    public partial class ContactDetailsPage : ContentPage
    {
        public ContactDetailsPage()
        {
            InitializeComponent();
        }

        public ContactDetailsPage(Contact selectedContact)
        {
            InitializeComponent();

            nameLabel.Text = selectedContact.Name;
            lastNameLabel.Text = selectedContact.LastName;
            emailLabel.Text = selectedContact.Email;
            phoneLabel.Text = selectedContact.Phone;
        }
    }
}
