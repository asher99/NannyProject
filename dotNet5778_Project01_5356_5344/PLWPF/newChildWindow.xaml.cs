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
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for newChildWindow.xaml
    /// </summary>
    public partial class newChildWindow : Window
    {
        static IBL myBL = BL_Factory.Get_BL;

        Child child = new Child();

        public newChildWindow()
        {
            InitializeComponent();
            ChildDetailsGrid.DataContext = child;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
