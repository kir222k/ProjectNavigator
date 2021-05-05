using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectNavigator
{
    /// <summary>
    /// Interaction logic for DevWindow.xaml
    /// </summary>
    public partial class DevWindow : Window
    {
        public Dev Dev { get; private set; }

        public DevWindow(Dev p)
        {
            InitializeComponent();
            Dev = p;
            this.DataContext = Dev;

        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        /*
            public Phone Phone { get; private set; }
 
            public PhoneWindow(Phone p)
            {
                InitializeComponent();
                Phone= p;
                this.DataContext = Phone;
            }
 
            private void Accept_Click(object sender, RoutedEventArgs e)
            {
                this.DialogResult = true;
            }
        */
    }
}
