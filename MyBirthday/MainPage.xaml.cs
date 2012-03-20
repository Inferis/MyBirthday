using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using MyBirthday.Models;
using MyBirthday.ViewModels;

namespace MyBirthday
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            Loaded += (s, e) => {
                ((MainPageViewModel)DataContext).Refresh();
            };
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/BirthdayPage.xaml", UriKind.Relative));
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = e.AddedItems[0] as Birthday;
            if (item == null)
                return;
            NavigationService.Navigate(new Uri(string.Format("/BirthdayPage.xaml?id={0}", item.Id), UriKind.Relative));
        }
    }
}