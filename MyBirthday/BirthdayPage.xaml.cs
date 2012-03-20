using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using MyBirthday.Helpers;
using MyBirthday.ViewModels;

namespace MyBirthday
{
    public partial class BirthdayPage : PhoneApplicationPage, INotifyPropertyChanged
    {
        public BirthdayPage()
        {
            InitializeComponent();

            Loaded += (s, e) => {
                if (DataContext == null)
                {
                    int id = 0;
                    if (NavigationContext.QueryString.ContainsKey("id") && !string.IsNullOrEmpty(NavigationContext.QueryString["id"]))
                        int.TryParse(NavigationContext.QueryString["id"], out id);
                    DataContext = new BirthdayPageViewModel(id);
                }
            };
        }

        private string birthName;
        public string BirthName
        {
            get { return birthName; }
            set
            {
                birthName = value;
                this.NotifyPropertyChanged("BirthName");
            }
        }

        private DateTime date;
        public DateTime BirthDate
        {
            get { return date; }
            set
            {
                date = value;
                this.NotifyPropertyChanged("BirthDate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate {};

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            ((BirthdayPageViewModel)DataContext).Save();
            NavigationService.GoBack();
        }
    }
}