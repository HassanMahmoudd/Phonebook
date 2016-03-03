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
    public sealed partial class ViewContactsPage : Page
    {
        public ViewContactsPage()
        {
            this.InitializeComponent();
            displayContacts();
        }
        public void displayContacts()
        {
            App.i = 0;
            List<Contact> SortedList = App.Contacts.OrderBy(o => o.Name).ToList();
            var recordsAsString = string.Join(Environment.NewLine,
            SortedList.Select(p => p.ToString()));
            ResulTextBlock.Text = "             Name\n" + recordsAsString;
            var recordsAsString1 = string.Join(Environment.NewLine,
            SortedList.Select(p => p.ToString1()));
            ResulTextBlock1.Text = "              Number\n" + recordsAsString1;
        }
    }
}
