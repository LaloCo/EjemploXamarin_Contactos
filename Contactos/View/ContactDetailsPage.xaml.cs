using System;
using System.Collections.Generic;
using Contactos.Model;
using SQLite;
using Xamarin.Forms;

namespace Contactos.View
{
    public partial class ContactDetailsPage : ContentPage
    {
        Contact selectedContact;

        public ContactDetailsPage()
        {
            InitializeComponent();
        }

        public ContactDetailsPage(Contact selectedContact)
        {
            InitializeComponent();

            this.selectedContact = selectedContact;

            nameLabel.Text = selectedContact.Name;
            lastNameLabel.Text = selectedContact.LastName;
            emailLabel.Text = selectedContact.Email;
            phoneLabel.Text = selectedContact.Phone;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.Delete(selectedContact);
                Navigation.PopAsync();
            }
        }
    }
}
