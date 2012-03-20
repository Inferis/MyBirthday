using System;
using System.Collections.Generic;
using System.Linq;
using MyBirthday.Helpers;
using MyBirthday.Models;

namespace MyBirthday.ViewModels
{
    public class BirthdayPageViewModel : NotifyPropertyChangedBase
    {
        private Birthday birthday;

        public BirthdayPageViewModel(int id)
        {
            using (var context = new Context()) {
                birthday = context.GetOrCreateBirthday(id);
                Categories = context.Categories.Select(x => x.Name).ToList();
            }
        }

        public string Title
        {
            get { return string.IsNullOrEmpty(birthday.Name) ? "?" : birthday.Name; }
        }

        public string BirthName
        {
            get { return birthday.Name; }
            set
            {
                birthday.Name = value;
                OnPropertyChanged("BirthName");
                OnPropertyChanged("Title");
            }
        }

        public DateTime BirthDate
        {
            get { return birthday.Date; }
            set
            {
                birthday.Date = value;
                OnPropertyChanged("BirthDate");
            }
        }

        public string BirthCategory
        {
            get { return birthday.Category == null ? null : birthday.Category.Name; }
            set
            {
                using (var context = new Context()) {
                    birthday.Category = context.Categories.First(x => x.Name == value);
                }
                OnPropertyChanged("BirthCategory");
            }
        }

        public List<string> Categories { get; private set; }

        public void Save()
        {
            using (var context = new Context())
            {
                context.Birthdays.InsertOnSubmit(birthday);
                context.SubmitChanges();
            }
        }
    }
}
