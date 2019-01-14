using System;
using System.Collections.Generic;
using Contactos.Model;
using Xamarin.Forms;

namespace Contactos.View
{
    public partial class NewContactPage : ContentPage
    {
        public NewContactPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            //TODO: Guardar en tabla Contacto
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable(typeof(Contact));
                int filasInsertadas = conn.Insert(new Contact
                {
                    Name = nameEntry.Text,
                    LastName = lastnameEntry.Text,
                    Email = emailEntry.Text,
                    Phone = phoneEntry.Text
                });

                if (filasInsertadas > 0)
                    Navigation.PopAsync();
                else
                    DisplayAlert("Error", "No se insertó el contacto", "Ok");
            }
        }
    }
}
