using MyBirthday.Helpers;
using MyBirthday.Models;

namespace MyBirthday.ViewModels
{
    public class BirthdayPageViewModel : NotifyPropertyChangedBase
    {
        private Birthday birthday;
        public Birthday Birthday
        {
            get { return birthday; }
            set
            {
                OnPropertyChanged("Birthday");
                birthday = value;
            }
        }
    }
}
