using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjectNavigator
{
    public class Block : IBlock, INotifyPropertyChanged
    {
        // ПОЛЯ.
        private string blockName;
        private string note;

        // СВОЙСТВА.
        public int ID { get; set; }
        public string BlockName
        {
            get { return blockName; }
            set
            {
                blockName = value;
                OnPropertyChanged("BlockName");
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}