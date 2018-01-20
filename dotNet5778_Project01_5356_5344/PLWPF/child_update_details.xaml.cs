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
    /// Interaction logic for child_update_details.xaml
    /// </summary>
    public partial class child_update_details : Window
    {

        static IBL myBL = BL_Factory.Get_BL;
        Child child;

        /// <summary>
        /// Construct the Window
        /// </summary>
        /// <param name="thisChild"></param>
        public child_update_details(Child thisChild)
        {
            InitializeComponent();
            child = thisChild;
            ChildDetailsGrid.DataContext = child;

            MinHeight = 300;
            MaxHeight = 300;
            MinWidth = 500;
            MaxWidth = 500;
        }


        /// <summary>
        /// close window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Event - update the child data calling the BL method. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_Click(object sender, RoutedEventArgs e)
        {
            myBL.updateChild(child);
            MessageBox.Show("Child details were updated!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

    }
}
