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
        static IBL myBL = BL_Factory.Get_BL;

        public MainWindow()
        {
            InitializeComponent();
            Nanny Sarit = new Nanny("Friedman", "Sarit", "Tal Institute - College of Technology", 758556411, new DateTime(1995, 7, 15), "0508494561", true, 40, 1700, 12, 4, 24);
            myBL.addNanny(Sarit);
            Nanny Chagit = new Nanny("Cohen", "Chagit", "jaffa street 31 Jerusalem", 647859321, new DateTime(1992, 11, 2), "0504741121", true, 75, 1400, 6, 10, 36);
            myBL.addNanny(Chagit);
            Mother Hadasa = new Mother("Hadasa", "Weiss", "King George 20 Jerusalem", 316522107, "0523566464");
            myBL.addMother(Hadasa);
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
