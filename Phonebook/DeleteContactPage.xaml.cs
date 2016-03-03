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
    public sealed partial class DeleteContactPage : Page
    {
        private string _roast;
        private string _sweetener;
        private string _cream;
        public DeleteContactPage()
        {
            this.InitializeComponent();
            FullNameTextBlock.Visibility = Visibility.Collapsed;
            FullNameTextBox.Visibility = Visibility.Collapsed;
            PhoneNumberTextBlock.Visibility = Visibility.Collapsed;
            PhoneNumberTextBox.Visibility = Visibility.Collapsed;
        }

        private void DeleteGroupName_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if ((bool)ByNameRadioButton.IsChecked)
            {
                FullNameTextBlock.Visibility = Visibility.Visible;
                FullNameTextBox.Visibility = Visibility.Visible;
                PhoneNumberTextBlock.Visibility = Visibility.Collapsed;
                PhoneNumberTextBox.Visibility = Visibility.Collapsed;
            }
            else if ((bool)ByNumberRadioButton.IsChecked)
            {
                PhoneNumberTextBlock.Visibility = Visibility.Visible;
                PhoneNumberTextBox.Visibility = Visibility.Visible;
                FullNameTextBlock.Visibility = Visibility.Collapsed;
                FullNameTextBox.Visibility = Visibility.Collapsed;

            }
            else if ((bool)BothRadioButton.IsChecked)
            {
                FullNameTextBlock.Visibility = Visibility.Visible;
                FullNameTextBox.Visibility = Visibility.Visible;
                PhoneNumberTextBlock.Visibility = Visibility.Visible;
                PhoneNumberTextBox.Visibility = Visibility.Visible;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)ByNameRadioButton.IsChecked)
            {
                if (String.IsNullOrEmpty(FullNameTextBox.Text))
                    ResultTextBlock.Text = "Please fill in the blank !";
                else
                {
                    var item = App.Contacts.FirstOrDefault(o => o.Name.ToUpper() == FullNameTextBox.Text.ToUpper());
                    if (item != null)
                    {
                        App.Contacts.Remove(item);
                        ResultTextBlock.Text = "Contact is successfully deleted !";
                        FullNameTextBox.Text = "";
                    }
                    else
                    {
                        ResultTextBlock.Text = "Contact can't be found try again !";
                        FullNameTextBox.Text = "";
                    }
                }
               
            }
            else if ((bool)ByNumberRadioButton.IsChecked)
            {
                if (String.IsNullOrEmpty(PhoneNumberTextBox.Text))
                    ResultTextBlock.Text = "Please fill in the blank !";
                else
                {
                    var item = App.Contacts.FirstOrDefault(o => o.Number == PhoneNumberTextBox.Text);
                    if (item != null)
                    {
                        App.Contacts.Remove(item);
                        ResultTextBlock.Text = "Contact is successfully deleted !";
                        PhoneNumberTextBox.Text = "";
                    }
                    else
                    {
                        ResultTextBlock.Text = "Contact can't be found try again !";
                        PhoneNumberTextBox.Text = "";
                    }
                }

            }
            else if ((bool)BothRadioButton.IsChecked)
            {
                if (String.IsNullOrEmpty(PhoneNumberTextBox.Text) || String.IsNullOrEmpty(FullNameTextBox.Text))
                    ResultTextBlock.Text = "Please fill in the blank !";
                else
                {
                    var item = App.Contacts.FirstOrDefault(o => o.Number == PhoneNumberTextBox.Text);
                    var item1 = App.Contacts.FirstOrDefault(o => o.Name.ToUpper() == FullNameTextBox.Text.ToUpper());
                    if (item != null && item1 != null)
                    {
                        App.Contacts.Remove(item);
                        ResultTextBlock.Text = "Contact is successfully deleted !";
                        PhoneNumberTextBox.Text = "";
                        FullNameTextBox.Text = "";
                    }
                    else
                    {
                        ResultTextBlock.Text = "Contact can't be found try again !";
                        PhoneNumberTextBox.Text = "";
                        FullNameTextBox.Text = "";
                    }
                }
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            MyFlyout.Hide();
        }
    }
}
