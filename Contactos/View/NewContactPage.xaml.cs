using System;
using System.Collections.Generic;
using Contactos.Model;
using Xamarin.Forms;

namespace Contactos.View
{
    public partial class NewContactPage : ContentPage
    {
        bool isEditing = false;
        Contact contact = null;

        public NewContactPage()
        {
            InitializeComponent();
        }

        public NewContactPage(Contact contact)
        {
            InitializeComponent();

            isEditing = true;
            this.contact = contact;

            nameEntry.Text = contact.Name;
            lastnameEntry.Text = contact.LastName;
            emailEntry.Text = contact.Email;
            phoneEntry.Text = contact.Phone;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            //TODO: Guardar en tabla Contacto
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable(typeof(Contact));

                int filasModificadas = 0;

                if (!isEditing)
                {
                    filasModificadas = conn.Insert(new Contact
                    {
                        Name = nameEntry.Text,
                        LastName = lastnameEntry.Text,
                        Email = emailEntry.Text,
                        Phone = phoneEntry.Text
                    });
                }
                else
                {
                    contact.Name = nameEntry.Text;
                    contact.LastName = lastnameEntry.Text;
                    contact.Email = emailEntry.Text;
                    contact.Phone = phoneEntry.Text;
                    filasModificadas = conn.Update(contact);
                }

                if (filasModificadas > 0)
                    Navigation.PopAsync();
                else
                    DisplayAlert("Error", "Error al modificar", "Ok");
            }
        }
    }
}
