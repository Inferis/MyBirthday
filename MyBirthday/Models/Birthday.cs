using System;
using System.Data.Linq.Mapping;
using MyBirthday.Helpers;

namespace MyBirthday.Models
{
    [Table]
    public class Birthday : NotifyPropertyChangedBase
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        private string category;
        [Column]
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
        [Column]
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
        [Column]
        public DateTime Date
        {
            get { return date; }
            set
            {
                OnPropertyChanged("Date");
                date = value;
            }
        }

        private string pictureUri;
        [Column]
        public string PictureUri
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
