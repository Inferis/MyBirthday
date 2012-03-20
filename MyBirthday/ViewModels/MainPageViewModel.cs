using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using MyBirthday.Models;

namespace MyBirthday.ViewModels
{
    public class MainPageViewModel
    {
        public ObservableCollection<BirthdayList> BirthdayLists { get; private set; }

        public MainPageViewModel()
        {
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
            BirthdayLists = new ObservableCollection<BirthdayList>(new[]
                                                                      {
                                                                          new BirthdayList(demo.Where(x => x.Category == "general")), 
                                                                          new BirthdayList(demo.Where(x => x.Category == "family")), 
                                                                          new BirthdayList(demo.Where(x => x.Category == "friends")), 
                                                                      });
        }
    }
}
