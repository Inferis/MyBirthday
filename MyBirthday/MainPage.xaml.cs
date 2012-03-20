﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
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
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //if (!App.ViewModel.IsDataLoaded) {
            //    App.ViewModel.LoadData();
            //}
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