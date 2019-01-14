using System;
using System.Collections.Generic;
using Contactos.Model;
using Contactos.ViewModel;
using Xamarin.Forms;

namespace Contactos.View
{
    public partial class NewContactPage : ContentPage
    {
        NewContactVM viewModel;

        public NewContactPage()
        {
            InitializeComponent();
        }

        public NewContactPage(Contact contact)
        {
            InitializeComponent();

            viewModel = Resources["vm"] as NewContactVM;

            viewModel.IsEditing = true;
            viewModel.Contacto = contact;
        }
    }
}
