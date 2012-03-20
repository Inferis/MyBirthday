using System;
using MyBirthday.Helpers;

namespace MyBirthday.Models
{
    public class Birthday : NotifyPropertyChangedBase
    {
        private string category;
        public string Category
        {
            get { return category; }
            set
            {
                OnPropertyChanged("Category");
                category = value;
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                OnPropertyChanged("Name");
                name = value;
            }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                OnPropertyChanged("Date");
                date = value;
            }
        }

        private Uri pictureUri;
        public Uri PictureUri
        {
            get { return pictureUri; }
            set
            {
                OnPropertyChanged("PictureUri");
                pictureUri = value;
            }
        }
    }
}
