using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TeachersWPF.Domain
{
    internal class Institute : INotifyPropertyChanged
    {
        public string Name
        {
            get
            { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }
        private string _name;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
