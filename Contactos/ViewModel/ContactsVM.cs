using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Contactos.Model;
using Contactos.View;
using Contactos.ViewModel.Commands;
using SQLite;
using Xamarin.Forms;

namespace Contactos.ViewModel
{
    public class ContactsVM
    {
        public NewContactCommand NewContactCommand { get; set; }

        public ICommand EditContactCommand { get; set; }

        public ICommand DeleteContactCommand { get; set; }

        public ObservableCollection<Contact> Contactos { get; set; }

        public ContactsVM()
        {
            Contactos = new ObservableCollection<Contact>();

            NewContactCommand = new NewContactCommand(this);
            EditContactCommand = new Command<Contact>(EditarContacto);
            DeleteContactCommand = new Command<Contact>(BorrarContacto);
        }

        private void BorrarContacto(Contact contacto)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.Delete(contacto);
                ReadContacts();
            }
        }

        void EditarContacto(Contact contacto)
        {
            App.Current.MainPage.Navigation.PushAsync(new NewContactPage(contacto));
        }

        public void ReadContacts()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable(typeof(Contact));
                var contactos = conn.Table<Contact>().ToList();

                Contactos.Clear();
                foreach(var contacto in contactos)
                {
                    Contactos.Add(contacto);
                }
            }
        }

        public void NewContact()
        {
            App.Current.MainPage.Navigation.PushAsync(new NewContactPage(), true);
        }
    }
}
