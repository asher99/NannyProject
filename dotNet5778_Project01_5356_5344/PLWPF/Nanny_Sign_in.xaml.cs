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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Nanny_Sign_in.xaml
    /// </summary>
    public partial class Nanny_Sign_in : Window
    {
        static IBL myBL = BL_Factory.Get_BL;

        public Nanny_Sign_in()
        {
            InitializeComponent();
        }

        private void MotherEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                // if Nanny in list
                int id = Convert.ToInt32(idTextBox.Text);
                if (!myBL.isNannyInList(id))
                    throw new Exception("This Mother is not in the system.");
                Window nannyInfo = new MoterInfoWindow();
                Close();
                nannyInfo.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
