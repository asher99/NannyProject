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
    /// Interaction logic for MotherWindow.xaml
    /// </summary>
    public partial class MotherWindow : Window
    {
        public MotherWindow()
        {
            InitializeComponent();
        }

        private void newMother_Click(object sender, RoutedEventArgs e)
        {
            Window newMother = new newMotherWindow();
            newMother.ShowDialog();
        }

        private void MotherUserEnter(object sender, RoutedEventArgs e)
        {
            Window userEntry = new MotherUserEntry();
            userEntry.ShowDialog();
        }
    }
}
