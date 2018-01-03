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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void goToMotherPage(object sender, RoutedEventArgs e)
        {
            Window motherPage = new MotherWindow();
            motherPage.ShowDialog();
        }

        private void goToNannyPage(object sender, RoutedEventArgs e)
        {
            Window nannyPage = new NannyWindow();
           nannyPage.ShowDialog();
        }
        private void admin_login(object sender, RoutedEventArgs e)
        {
            Window login = new loginAdminWindow();
            login.ShowDialog();
        }
    }
}
