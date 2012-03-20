using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyBirthday.Models
{
    public class BirthdayList
    {
        public string Title { get; private set; }
        private ObservableCollection<Birthday> birthdays;
        public ObservableCollection<Birthday> Birthdays
        {
            get { return birthdays; }
            private set { birthdays = value; }
        }

        public BirthdayList(IEnumerable<Birthday> birthdays)
        {
            if (birthdays == null || !birthdays.Any()) {
                Title = "???";
                Birthdays = new ObservableCollection<Birthday>();
            }
            else
            {
                Title = birthdays.First().Category.Name;
                Birthdays = new ObservableCollection<Birthday>(birthdays);
            }
        }
    }
}
