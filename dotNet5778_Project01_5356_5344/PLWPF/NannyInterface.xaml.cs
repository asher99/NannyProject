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
            switch (Options.SelectedIndex)
            {
                case 0: showDetails(); break; // update details
                case 1: dataGrid.ItemsSource = myBL.getListOfChildrenOfNanny(thisNanny.id); break;                 // view group
                case 2: dataGrid.ItemsSource = myBL.ListOfContractsById(thisNanny.id);
                    double salarySum = 0;
                    foreach (Contract c in myBL.ListOfContractsById(thisNanny.id))
                    { salarySum += c.monthSalary;  };
                    textBox.Text = Convert.ToString(salarySum); 
                    salary.Visibility = Visibility.Visible;
                    textBox.Visibility = Visibility.Visible; break;                  // view contracts
                case 3: nannyLeave(); break;  // delete user
            }
        }

        // nanny leave procedure
        private void nannyLeave()
        {
            // giving last chance
            MessageBoxResult whatNow = MessageBox.Show("Are You Sure you want to delete your user?", "", MessageBoxButton.OKCancel);
            switch (whatNow)
            {
                case MessageBoxResult.Cancel: return;
            }

            if (thisNanny.numberOfSignedContracts != 0)
            {
               MessageBoxResult whatNow2 = MessageBox.Show("You still have signed contracts! \nIf you leave, you will be charged 30% canceling fee ",
                    "warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                switch (whatNow2)
                {
                    case MessageBoxResult.Cancel: return;
                }
            }

            myBL.deleteNanny(thisNanny);
            MessageBox.Show("GoodBye", "", MessageBoxButton.OK);
            Close();

        }

        // show details, some of the details can't be changed
        private void showDetails()
        {
            Window nannyDetails = new nanny_update_details(thisNanny);
            nannyDetails.ShowDialog();

        }
    }
}
