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
    /// Interaction logic for loginAdminWindow.xaml
    /// </summary>
    public partial class loginAdminWindow : Window
    {
        static IBL myBL = BL_Factory.Get_BL;

        /// <summary>
        /// build admin window. set the default on nanny list
        /// </summary>
        public loginAdminWindow()
        {
            InitializeComponent();
            var myList = myBL.getListOfNanny();
            // var myList = displayList();
            dataGrid.ItemsSource = myList;
            Nannylist.IsChecked = true;
        }

        /*private IEnumerable<object> displayList()
        {
            if (Nannylist.IsChecked == true)
            {
                return myBL.getListOfNanny();
            }

            if (Motherlist.IsChecked == true)
            {
                return myBL.getListOfMother();
            }

            if (Childlist.IsChecked == true)
            {
                return myBL.getListOfChild();
            }

            if (Contractlist.IsChecked == true)
            {
                return myBL.getListOfContract();
            }
 
            return null; 
        }*/


        /// <summary>
        /// multiple events for the right list to show.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Nannylist_Checked(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = myBL.getListOfNanny();
        }

        private void Motherlist_Checked(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = myBL.getListOfMother();
        }

        private void Childlist_Checked(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = myBL.getListOfChild();
        }

        private void Contractlist_Checked(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = myBL.getListOfContract();
        }


        /// <summary>
        /// Event: double click the grid when show nanny or mother list open the update details window of those object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Nannylist.IsChecked.Value)
            {
                var details = dataGrid.CurrentItem as Nanny;
                Window update_details = new nanny_update_details(details);
                update_details.ShowDialog();
            }

            if (Motherlist.IsChecked.Value)
            {
                var details = dataGrid.CurrentItem as Mother;
                Window update_details = new mother_update_details(details);
                update_details.ShowDialog();
            }
            else return;
        }
    }
}
