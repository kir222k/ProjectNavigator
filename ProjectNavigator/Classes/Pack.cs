using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjectNavigator
{
    public class Pack : IPack, INotifyPropertyChanged
    {
        // ПОЛЯ.
        private string packName;
        private string note;

        // СВОЙСТВА.
        public int ID { get; set; }
        public string PackName
        {
            get { return packName; }
            set
            {
                packName = value;
                OnPropertyChanged("PackName");
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