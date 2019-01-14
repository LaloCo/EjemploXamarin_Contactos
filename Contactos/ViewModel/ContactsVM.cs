using System;
using Contactos.View;
using Contactos.ViewModel.Commands;

namespace Contactos.ViewModel
{
    public class ContactsVM
    {
        public NewContactCommand NewContactCommand { get; set; }

        public ContactsVM()
        {
            NewContactCommand = new NewContactCommand(this); 
        }

        public void NewContact()
        {
            App.Current.MainPage.Navigation.PushAsync(new NewContactPage(), true);
        }
    }
}
