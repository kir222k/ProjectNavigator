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
    /// Interaction logic for PackWindow.xaml
    /// </summary>
    public partial class PackWindow : Window
    {
        public Pack Pack { get; private set; }
        public PackWindow(Pack p)
        {
            InitializeComponent();
            Pack = p;
            this.DataContext = Pack;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }

    /*
 public partial class BlockWindow : Window
{
    public Block Block { get; private set; }
    public BlockWindow(Block p)
    {

        InitializeComponent();
        Block = p;
        this.DataContext = Block;
    }

    private void Accept_Click(object sender, RoutedEventArgs e)
    {
        this.DialogResult = true;
    }
}
*/
}
