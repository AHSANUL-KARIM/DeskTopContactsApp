using System.Diagnostics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DesktopContactsApp.Classes;


namespace DesktopContactsApp
{
    public partial class ContactDetailsWindow : Window
    {

        Contact contact;
        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();
            this.contact = contact;

            nameTextBox.Text = contact.Name;
            phoneNumberTextBox.Text = contact.Phone;
            emailTextBox.Text = contact.Email; 
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = nameTextBox.Text;
            contact.Phone = phoneNumberTextBox.Text;
            contact.Email = emailTextBox.Text;

            using(SQLite.SQLiteConnection connnection = new SQLite.SQLiteConnection(App.databasePath))
            {
              connnection.CreateTable<Contact>();
              connnection.Update(contact);
            }

            Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using(SQLite.SQLiteConnection connnection = new SQLite.SQLiteConnection(App.databasePath))
            {
              connnection.CreateTable<Contact>();
              connnection.Delete(contact);
            }

            Close();

        }


    }
}