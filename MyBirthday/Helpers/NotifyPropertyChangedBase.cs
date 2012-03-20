using System.ComponentModel;

namespace MyBirthday.Helpers
{
    /// <summary>
    /// no comment.
    /// Base class for INotifyPropertyChanged implementation.
    /// </summary>
    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public static PropertyChangedEventHandler AutoPropagate(INotifyPropertyChanged x)
        {
            return (s, e) => x.NotifyPropertyChanged(e.PropertyName);
        }
    }
}