using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Phonebook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddContactPage : Page
    {
        public AddContactPage()
        {
            this.InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(FullNameTextBox.Text) && !String.IsNullOrEmpty(PhoneNumberTextBox.Text))
            {
                var item = App.Contacts.FirstOrDefault(o => o.Number == PhoneNumberTextBox.Text);
                var item1 = App.Contacts.FirstOrDefault(o => o.Name.ToUpper() == FullNameTextBox.Text.ToUpper());
                if (item == null && item1 == null)
                {
                    App.Contacts.Add(new Contact(FullNameTextBox.Text, PhoneNumberTextBox.Text));
                    ResultTextBlock.Text = "Contact is successfully added !";

                }
                else if(item != null)
                {
                    ResultTextBlock.Text = "Contact is already added with the same number !";
                }
                else if(item1 != null)
                {
                    ResultTextBlock.Text = "Contact is already added with the same name";
                }
                FullNameTextBox.Text = "";
                PhoneNumberTextBox.Text = "";
            }
            else
            {
             
                ResultTextBlock.Text = "Please fill in the blanks !";
            }
           

        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            MyFlyout.Hide();
        }
    }
}
