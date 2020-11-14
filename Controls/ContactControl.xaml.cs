using System.Reflection.Metadata.Ecma335;
using System.Windows;
using System.Windows.Controls;
using DesktopContactsApp.Classes;

namespace DesktopContactsApp.Controls
{
    public partial class ContactControl : UserControl
    {    

        public Contact Contact
        {
            get {return (Contact)GetValue(ContactProperty);}
            set {SetValue(ContactProperty, value);}
        }       
        
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(new Contact() {Name="Name LastName", Phone="(123) 456 7890", Email="example@domain.com"}, SetText));
        
        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl control = d as ContactControl;
            if(control != null)
            {
                control.nameTextBlock.Text = (e.NewValue as Contact).Name;
                control.emailTextBlock.Text = (e.NewValue as Contact).Email;
                control.phoneTextBlock.Text = (e.NewValue as Contact).Phone;

            }
        }
        
        public ContactControl()
        {
            InitializeComponent();
        }

    }
}
