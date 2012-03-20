using System.Collections.ObjectModel;
using System.Linq;
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
    }
}
