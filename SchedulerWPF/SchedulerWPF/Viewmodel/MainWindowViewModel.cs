using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SchedulerWPF
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Meeting> meetings;
        private List<string> eventNameCollection;
        public MainWindowViewModel()
        {
            this.Meetings = new ObservableCollection<Meeting>();
            this.AddAppointmentDetails();
            this.AddAppointments();
        }
        public ObservableCollection<Meeting> Meetings
        {
            get
            {
                return this.meetings;
            }

            set
            {
                this.meetings = value;
                this.RaiseOnPropertyChanged("Meetings");
            }
        }
        private void AddAppointmentDetails()
        {
            this.eventNameCollection = new List<string>();
            this.eventNameCollection.Add("General Meeting");
            this.eventNameCollection.Add("Plan Execution");
            this.eventNameCollection.Add("Project Plan");
            this.eventNameCollection.Add("Consulting");
            this.eventNameCollection.Add("Support");
            this.eventNameCollection.Add("Development Meeting");
            this.eventNameCollection.Add("Scrum");
            this.eventNameCollection.Add("Project Completion");
            this.eventNameCollection.Add("Release updates");
            this.eventNameCollection.Add("Performance Check");
        }
        private void AddAppointments()
        {
            var today = DateTime.Now.Date;
            var random = new Random();
            var meeting = new Meeting();
            meeting.From = today.AddHours(11);
            meeting.To = meeting.From.AddHours(1);
            meeting.EventName = this.eventNameCollection[random.Next(7)];
            meeting.Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#889e81"));
            this.Meetings.Add(meeting);

            var meeting1 = new Meeting();
            meeting1.From = today.AddHours(13);
            meeting1.To = meeting1.From.AddHours(2);
            meeting1.EventName = this.eventNameCollection[random.Next(7)];
            meeting1.Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#889e81"));
            this.Meetings.Add(meeting1);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
