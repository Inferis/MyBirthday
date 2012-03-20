using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace MyBirthday.Models
{
    public class Context : DataContext
    {

        public Table<Category> Categories { get { return GetTable<Category>(); } }
        public Table<Birthday> Birthdays { get { return GetTable<Birthday>(); } }

        public Context()
            : base("Data Source=isostore:/Birthdays.sdf")
        {
        }

        public static void InitializeIfEmpty()
        {
            using (var context = new Context())
            {
                if (!context.DatabaseExists()) {
                    // create database if it does not exist
                    context.CreateDatabase();
                }

                if (context.Birthdays.Any()) return;

                var categories = new Category[]
                                     {
                                         new Category("general"),
                                         new Category("friends"),
                                         new Category("family"),
                                     };
                var demo = new Birthday[]
                           {
                               new Birthday() { Name = "Jos", Category = categories[0], Date = new DateTime(2011, 03, 11) }, 
                               new Birthday() { Name = "Frank", Category = categories[0], Date = new DateTime(2010, 4, 22) }, 
                               new Birthday() { Name = "Lowie", Category = categories[1], Date = new DateTime(2009, 4, 30) }, 
                               new Birthday() { Name = "Ludovic", Category = categories[2], Date = new DateTime(1975, 8, 29) }, 
                               new Birthday() { Name = "Jan", Category = categories[0], Date = new DateTime(1983, 11, 1) }, 
                               new Birthday() { Name = "Erik", Category = categories[2], Date = new DateTime(1967, 10, 9) }, 
                               new Birthday() { Name = "Lisa", Category = categories[1], Date = new DateTime(1994, 12, 3) }, 
                               new Birthday() { Name = "Bertha", Category = categories[2], Date = new DateTime(2003, 03, 5) }, 
                               new Birthday() { Name = "Ellen", Category = categories[0], Date = new DateTime(2005, 04, 11) }, 
                           };

                foreach (var category in categories) {
                    context.Categories.InsertOnSubmit(category);
                }
                foreach (var birthday in demo)
                {
                    context.Birthdays.InsertOnSubmit(birthday);
                }
                context.SubmitChanges();
            }
        }

        public List<string> GetCategories()
        {
            return Birthdays.Select(x => x.Category).Distinct().Select(x => x.Name).ToList();
        }

        public IEnumerable<Birthday> BirthdaysForCategory(string category)
        {
            var result = Birthdays.Where(bd => bd.Category.Name == category).OrderBy(x => x.Date).ThenBy(x => x.Name).ToList();
            return result;
        }
    }
}
