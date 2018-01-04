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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for NannyInterface.xaml
    /// </summary>
    public partial class NannyInterface : Window
    {
        static IBL myBL = BL_Factory.Get_BL;

        Nanny thisNanny;

        // initialize window
        public NannyInterface(Nanny nanny)
        {
            InitializeComponent();
            thisNanny = nanny;
        }

        // exit window
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Event: the user select option from the combo box!
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(Options.SelectedIndex)
            {
                case 0: showDetails(); break;
                case 1: break;
                case 2: nannyLeave(); break;
            }
        }

        // nanny leave procedure
        private void nannyLeave()
        {
            // giving last chance
            MessageBoxResult whatNow = MessageBox.Show("Are You Sure you want to delete your user?","",MessageBoxButton.OKCancel);
            switch(whatNow)
            {
                case MessageBoxResult.Cancel: return;
            }

            if (thisNanny.numberOfSignedContracts != 0)
            {
                MessageBox.Show("You still had signed contracts! \nIf you want to leave, you have to enter \"View Contracts\" and cancel the active contracts");
            }
            else myBL.deleteNanny(thisNanny);
            MessageBox.Show("GoodBye", "", MessageBoxButton.OK);
            Close();
        }

        // show detils, some of the details can't be changed
        private void showDetails()
        {
            Window nannyDetails = new nanny_update_details(thisNanny);
            this.Close();
            nannyDetails.ShowDialog();
          
        }
    }
}
