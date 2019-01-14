using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Contactos.Model;
using Contactos.View;
using Contactos.ViewModel.Commands;
using SQLite;
using Xamarin.Forms;

namespace Contactos.ViewModel
{
    public class ContactsVM : INotifyPropertyChanged
    {
        public NewContactCommand NewContactCommand { get; set; }

        public ICommand EditContactCommand { get; set; }

        public ICommand DeleteContactCommand { get; set; }

        public ObservableCollection<Contact> Contactos { get; set; }

        private Contact selectedContact;
        public Contact SelectedContact
        {
            get { return selectedContact; }
            set
            {
                selectedContact = value;
                OnPropertyChanged("SelectedContact");
                App.Current.MainPage.Navigation.PushAsync(new ContactDetailsPage(selectedContact));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ContactsVM()
        {
            Contactos = new ObservableCollection<Contact>();

            NewContactCommand = new NewContactCommand(this);
            EditContactCommand = new Command<Contact>(EditarContacto);
            DeleteContactCommand = new Command<Contact>(BorrarContacto);
        }

        private void BorrarContacto(Contact contacto)
        {
            contacto.DeleteContact();
            ReadContacts();
        }

        void EditarContacto(Contact contacto)
        {
            App.Current.MainPage.Navigation.PushAsync(new NewContactPage(contacto));
        }

        public void ReadContacts()
        {
            var contactos = Contact.ReadContacts();
            Contactos.Clear();
            foreach (var contacto in contactos)
            {
                Contactos.Add(contacto);
            }
        }

        public void NewContact()
        {
            App.Current.MainPage.Navigation.PushAsync(new NewContactPage(), true);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
