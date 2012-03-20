using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace MyBirthday.Models
{
    public class Context : DataContext
    {

        public Table<Birthday> Birthdays { get { return GetTable<Birthday>(); } 
        }

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

                var demo = new Birthday[]
                           {
                               new Birthday() { Name = "Jos", Category = "general", Date = new DateTime(2011, 03, 11) }, 
                               new Birthday() { Name = "Frank", Category = "general", Date = new DateTime(2010, 4, 22) }, 
                               new Birthday() { Name = "Lowie", Category = "friends", Date = new DateTime(2009, 4, 30) }, 
                               new Birthday() { Name = "Ludovic", Category = "family", Date = new DateTime(1975, 8, 29) }, 
                               new Birthday() { Name = "Jan", Category = "general", Date = new DateTime(1983, 11, 1) }, 
                               new Birthday() { Name = "Erik", Category = "family", Date = new DateTime(1967, 10, 9) }, 
                               new Birthday() { Name = "Lisa", Category = "friends", Date = new DateTime(1994, 12, 3) }, 
                               new Birthday() { Name = "Bertha", Category = "family", Date = new DateTime(2003, 03, 5) }, 
                               new Birthday() { Name = "Ellen", Category = "friends", Date = new DateTime(2005, 04, 11) }, 
                           };

                foreach (var birthday in demo)
                {
                    context.Birthdays.InsertOnSubmit(birthday);
                }
                context.SubmitChanges();
            }
        }

        public List<string> GetCategories()
        {
            return Birthdays.Select(x => x.Category).Distinct().ToList();
        }

        public IEnumerable<Birthday> BirthdaysForCategory(string category)
        {
            var result = Birthdays.Where(bd => bd.Category == category).ToList();
            return result;
        }
    }
}
