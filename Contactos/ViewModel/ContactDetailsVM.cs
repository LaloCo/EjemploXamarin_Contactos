using System;
using System.ComponentModel;
using System.Windows.Input;
using Contactos.Model;
using SQLite;
using Xamarin.Forms;

namespace Contactos.ViewModel
{
    public class ContactDetailsVM : INotifyPropertyChanged
    {
        private Contact selectedContact;
        public Contact SelectedContact
        {
            get { return selectedContact; }
            set
            {
                selectedContact = value;
                Name = selectedContact.Name;
                Lastname = selectedContact.LastName;
                Email = selectedContact.Email;
                Phone = selectedContact.Phone;
                OnPropertyChanged("SelectedContact");
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

        public ICommand DeleteContactCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ContactDetailsVM()
        {
            DeleteContactCommand = new Command(DeleteContact);
        }

        void DeleteContact(object obj)
        {
            SelectedContact.DeleteContact();
            App.Current.MainPage.Navigation.PopAsync();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
