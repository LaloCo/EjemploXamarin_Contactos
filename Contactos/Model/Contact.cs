using System;
using System.Collections.Generic;
using SQLite;

namespace Contactos.Model
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        private string fullName;
        public string FullName
        {
            get { return $"{Name} {LastName}"; }
        }

        public Contact()
        {

        }

        public static int InsertContact(Contact contact)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Contact>();
                return conn.Insert(contact);
            }
        }

        public int UpdateContact()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Contact>();
                return conn.Update(this);
            }
        }

        public int DeleteContact()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Contact>();
                return conn.Delete(this);
            }
        }

        public static List<Contact> ReadContacts()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Contact>();
                return conn.Table<Contact>().ToList();
            }
        }
    }
}
