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
    /// Interaction logic for MotherUserEntry.xaml
    /// </summary>
    public partial class MotherUserEntry : Window
    {

        static IBL myBL = BL_Factory.Get_BL;

        /// <summary>
        /// window constructor
        /// </summary>
        public MotherUserEntry()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// receive data from window and enter to user interface
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MotherEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                // if mother in list
                int id = Convert.ToInt32(idTextBox.Text);
                string name = nameTextBox.Text;

                if (!myBL.isMotherInList(id))
                    throw new Exception("You are not in the system.");

                Mother thisMother = myBL.getMotherByID(id);
                Window motherInfo = new MoterInterface(thisMother);
                Close();
                motherInfo.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
