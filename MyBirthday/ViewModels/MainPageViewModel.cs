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

            Refresh();
        }

        public void Refresh()
        {
            using (var context = new Context()) {
                BirthdayLists = new ObservableCollection<BirthdayList>(context
                    .GetCategories().Select(category => new BirthdayList(context.BirthdaysForCategory(category))));
            }
        }

        public void AddBirthday()
        {
        }

        public void ViewBirthday(Birthday item)
        {
        }
    }
}
