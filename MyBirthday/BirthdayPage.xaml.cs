using System;
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
using MyBirthday.ViewModels;

namespace MyBirthday
{
    public partial class BirthdayPage : PhoneApplicationPage
    {
        public BirthdayPage()
        {
            InitializeComponent();

            Loaded += (s, e) => {
                int id = 0;
                if (NavigationContext.QueryString.ContainsKey("id") && !string.IsNullOrEmpty(NavigationContext.QueryString["id"]))
                    int.TryParse(NavigationContext.QueryString["id"], out id);
                DataContext = new BirthdayPageViewModel(id);
            };
        }
    }
}