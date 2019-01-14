using System;
using System.Collections.Generic;

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
    }
}
