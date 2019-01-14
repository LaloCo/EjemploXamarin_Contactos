using System;
using System.Windows.Input;
using Contactos.Model;
using Contactos.View;
using Contactos.ViewModel.Commands;
using Xamarin.Forms;

namespace Contactos.ViewModel
{
    public class ContactsVM
    {
        public NewContactCommand NewContactCommand { get; set; }

        public ICommand EditContactCommand { get; set; }

        public ContactsVM()
        {
            NewContactCommand = new NewContactCommand(this);
            EditContactCommand = new Command<Contact>(EditarContacto);
        }

        void EditarContacto(Contact contacto)
        {
            App.Current.MainPage.Navigation.PushAsync(new NewContactPage(contacto));
        }

        public void NewContact()
        {
            App.Current.MainPage.Navigation.PushAsync(new NewContactPage(), true);
        }
    }
}
