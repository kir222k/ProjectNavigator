using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjectNavigator
{
    public class Doc : IDoc, INotifyPropertyChanged
    {
        // ПОЛЯ.
        private string block;
        private string level;
        private string pack;
        private string dev;
        private string codePack;
        private string numDoc;
        private string codeDoc;
        private string nameDoc;
        private string note;

        // СВОЙСТВА.
        public int ID { get; set; }
        public string Block
        {
            get { return block; }
            set
            {
                block = value;
                OnPropertyChanged("Block");
            }
        }
        public string Level
        {
            get { return level; }
            set
            {
                level = value;
                OnPropertyChanged("Level");
            }
        }
        public string Pack
        {
            get { return pack; }
            set
            {
                pack = value;
                OnPropertyChanged("Pack");
            }
        }
        public string Dev
        {
            get { return dev; }
            set
            {
                dev = value;
                OnPropertyChanged("Dev");
            }
        }
        public string CodePack
        {
            get { return codePack; }
            set
            {
                codePack = value;
                OnPropertyChanged("CodePack");
            }
        }
        public string NumDoc
        {
            get { return numDoc; }
            set
            {
                numDoc = value;
                OnPropertyChanged("NumDoc");
            }
        }
        public string CodeDoc
        {
            get { return codeDoc; }
            set
            {
                codeDoc = value;
                OnPropertyChanged("CodeDoc");
            }
        }
        public string NameDoc
        {
            get { return nameDoc; }
            set
            {
                nameDoc = value;
                OnPropertyChanged("NameDoc");
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