using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNavigator
{
    public class Notify
    {
        private string notifyText;

        public string NotifyText
        {
            get { return notifyText; }
            set 
            {
                if ( !String.IsNullOrEmpty(value) )
                {
                    notifyText = value; 
                }
                else
                {
                    notifyText = "nullable or Empty string!";
                }
            }
        }

    }
}
