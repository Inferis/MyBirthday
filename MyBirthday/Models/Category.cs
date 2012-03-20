using System.Data.Linq.Mapping;
using MyBirthday.Helpers;

namespace MyBirthday.Models
{
    [Table]
    public class Category : NotifyPropertyChangedBase
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        public Category()
        {
            
        }

        public Category(string name)
        {
            Name = name;
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
    }
}