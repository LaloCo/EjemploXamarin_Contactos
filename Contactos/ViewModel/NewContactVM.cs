using System;
using System.ComponentModel;
using System.Windows.Input;
using Contactos.Model;
using SQLite;
using Xamarin.Forms;

namespace Contactos.ViewModel
{
    public class NewContactVM : INotifyPropertyChanged
    {
        private bool isEditing;
        public bool IsEditing
        {
            get { return isEditing; }
            set
            {
                isEditing = value;
                OnPropertyChanged("IsEditing");
            }
        }

        private Contact contacto;
        public Contact Contacto
        {
            get { return contacto; }
            set
            {
                contacto = value;
                Name = contacto.Name;
                Lastname = contacto.LastName;
                Email = contacto.Email;
                Phone = contacto.Phone;
                OnPropertyChanged("Contacto");
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string lastname;
        public string Lastname
        {
            get { return lastname; }
            set
            {
                lastname = value;
                OnPropertyChanged("Lastname");
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public ICommand SaveContactCommand { get; set; }

        public NewContactVM()
        {
            IsEditing = false;
            SaveContactCommand = new Command(SaveContact);
        }

        void SaveContact(object parameter)
        {
            int filasModificadas = 0;

            if (!IsEditing)
            {
                Contact contact = new Contact
                {
                    Name = Name,
                    LastName = Lastname,
                    Email = Email,
                    Phone = Phone
                };

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
                {
                    conn.CreateTable<Contact>();
                    filasModificadas = conn.Insert(contact);
                }
            }
            else
            {
                Contacto.Name = Name;
                Contacto.LastName = Lastname;
                Contacto.Email = Email;
                Contacto.Phone = Phone;

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
                {
                    conn.CreateTable<Contact>();
                    filasModificadas = conn.Update(Contacto);
                }
            }

            if (filasModificadas > 0)
                App.Current.MainPage.Navigation.PopAsync();
            else
                App.Current.MainPage.DisplayAlert("Error", "No se modificó la tabla", "Ok");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
