using System;
using System.Windows.Input;

namespace Contactos.ViewModel.Commands
{
    public class NewContactCommand : ICommand
    {
        public ContactsVM ViewModel { get; set; }

        public NewContactCommand(ContactsVM vM)
        {
            ViewModel = vM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.NewContact();
        }
    }
}
