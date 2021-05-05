using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjectNavigator
{
    public class Dev : IDev, INotifyPropertyChanged
    {
        // ПОЛЯ.
        private string developer;
        private string fullCompanyName;
        private string contacts;
        private string designStatus;
        private string note;

        // СВОЙСТВА.
        public int ID { get; set; }
        public string Developer
        {
            get { return developer; }
            set
            {
                developer = value;
                OnPropertyChanged("Developer");
            }
        }
        public string FullCompanyName
        {
            get { return fullCompanyName; }
            set
            {
                fullCompanyName = value;
                OnPropertyChanged("FullCompanyName");
            }
        }
        public string Contacts
        {
            get { return contacts; }
            set
            {
                contacts = value;
                OnPropertyChanged("Contacts");
            }
        }
        public string DesignStatus
        {
            get { return designStatus; }
            set
            {
                designStatus = value;
                OnPropertyChanged("DesignStatus");
            }
        }
        public string Note
        {
            get { return note; }
            set
            {
                note = value;
                OnPropertyChanged("Note");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
