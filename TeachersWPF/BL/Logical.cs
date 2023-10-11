using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using TeachersWPF.Domain;
using TeachersWPF.Helpers;

namespace TeachersWPF.BL
{
    internal class Logical : INotifyPropertyChanged
    {
        public Logical()
        {
            Teachers.Add(new Teacher("Klaus Schmidt", Services[0], Institutes[0]));
            Teachers.Add(new Teacher("Otto Lau", Services[1], Institutes[1]));
            Teachers.Add(new Teacher("Klara Ort", Services[0], Institutes[3]));
            Teachers.Add(new Teacher("Monika From", Services[3], Institutes[2]));
            Teachers.Add(new Teacher("Mia Most", Services[2], Institutes[1]));

            AddTeacherCommand = new RelayCommand(AddNewTeacher);
            GetTopServicesCommand = new RelayCommand(GetTopServices);
            ChangeNameCommand = new RelayCommand(ChangeName);
            DeleteTeacherCommand = new RelayCommand(DeleteTeacher);

            NewTeacher = new Teacher();

        }

        public ObservableCollection<Teacher> Teachers { get; set; }
            = new ObservableCollection<Teacher>();


        public List<TopServiceItem> TopServices

        {
            get { return _topServices; }
            set
            {
                _topServices = value;
                OnPropertyChanged("TopServices");
            }
        }
        private List<TopServiceItem> _topServices;


        public RelayCommand AddTeacherCommand { get; set; }
        public RelayCommand GetTopServicesCommand { get; set; }
        public RelayCommand ChangeNameCommand { get; set; }
        public RelayCommand DeleteTeacherCommand { get; set; }


        public List<Institute> Institutes { get; set; } = new List<Institute>()
       {
           new Institute(){Name="Dortmund Uni"},
           new Institute(){Name="Bochum Uni"},
           new Institute(){Name="Essen Uni"},
           new Institute(){Name="Dusseldorf Uni"}
       };

        public List<DistanceLearningService> Services { get; set; } = new List<DistanceLearningService>()
       {
           new DistanceLearningService(){Name="Discord"},
           new DistanceLearningService(){Name="Zoom"},
           new DistanceLearningService(){Name="Skype"},
           new DistanceLearningService(){Name="WebinarUni"}
       };


        public Teacher SelectedTeacher { get; set; }

        public Teacher NewTeacher
        {
            get { return _newTeacher; }
            set
            {
                _newTeacher = value;
                OnPropertyChanged("NewTeacher");
            }
        }
        private Teacher _newTeacher;

        #region INotifyPropertyChanged        

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        #endregion

        private void GetTopServices()
        {
            TopServices = new List<TopServiceItem>(
                Teachers.GroupBy(p => p.Service).
                Select(g => new TopServiceItem
                {
                    ServiceName = g.Key.Name,
                    CountOfUsing = g.Count(),
                }).
                OrderByDescending(t => t.CountOfUsing).
                Take(3).
                ToList());
        }

        private void AddNewTeacher()
        {
            Teachers.Add(new Teacher(NewTeacher.FullName.GetShortName(),
                NewTeacher.Service, NewTeacher.Institute));

            NewTeacher = new Teacher();
        }

        private void ChangeName()
        {

            SelectedTeacher.Institute.Name = "IKIT";
        }
        private void DeleteTeacher()
        {
            Teachers.Remove(SelectedTeacher);

        }
    }


}
