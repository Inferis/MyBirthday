using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using MyBirthday.Models;

namespace MyBirthday.ViewModels
{
    public class MainPageViewModel
    {
        public ObservableCollection<BirthdayList> BirthdayLists { get; private set; }

        public MainPageViewModel()
        {
            Context.InitializeIfEmpty();
            
            using (var context = new Context())
            {
                BirthdayLists = new ObservableCollection<BirthdayList>(context
                    .GetCategories().Select(category => new BirthdayList(context.BirthdaysForCategory(category))));
            }
        }

        public void AddBirthday()
        {
            ((App)Application.Current).RootFrame.Navigate(new Uri("/BirthdayPage.xaml"));
        }

        public void ViewBirthday(Birthday item)
        {
            if (item == null)
                return;
            ((App)Application.Current).RootFrame.Navigate(new Uri(string.Format("/BirthdayPage.xaml?id={0}", item.Id)));
        }
    }
}
