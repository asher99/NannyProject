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
    /// Interaction logic for Nanny_Sign_in.xaml
    /// </summary>
    public partial class Nanny_Sign_in : Window
    {
        static IBL myBL = BL_Factory.Get_BL;

        /// <summary>
        /// window constructor
        /// </summary>
        public Nanny_Sign_in()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event: when clicking on the button - enter to user interface.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MotherEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                // if Nanny in list
                int id = Convert.ToInt32(idTextBox.Text);
                string name = nameTextBox.Text;
                if (!myBL.isNannyInList(id))
                    throw new Exception("You are not in the system.");

                Nanny thisNanny = myBL.nannyById(id);

                if (thisNanny.firstName != name)
                    throw new Exception("You are not in the system.");
                Window nannyInfo = new NannyInterface(thisNanny);
                Close();
                nannyInfo.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               // Close();
            }
        }
    }
}
