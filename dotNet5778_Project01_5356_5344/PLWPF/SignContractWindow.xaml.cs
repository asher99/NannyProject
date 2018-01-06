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
    /// Interaction logic for SignContractWindow.xaml
    /// </summary>
    public partial class SignContractWindow : Window
    {
        static IBL myBL = BL_Factory.Get_BL;

        Contract thisContract;
        Mother thisMother;
        Nanny thisNanny;

        public SignContractWindow(Mother mother, Nanny nanny)
        {
            InitializeComponent();

            thisMother = mother;
            thisNanny = nanny;

            if (nanny.doesWorkPerHour == false)
                byHour.IsEnabled = false;

            int distanceBetweenAddresses = 0;
        }

        private void Terms_accepted_Checked(object sender, RoutedEventArgs e)
        {
            thisContract = new Contract(thisNanny.id);
            thisContract.childId = int.Parse(childIDNUmber.Text);
            thisContract.isMonthContract = !byHour.IsChecked.Value;
            if(thisContract.isMonthContract)
            {
                thisContract.monthSalary = myBL.calculateSalary(thisContract, thisNanny);
                thisContract.moneyPerHour = 0;
            }
            else
            {
                thisContract.monthSalary = 0;
                thisContract.moneyPerHour = myBL.calculateSalary(thisContract, thisNanny);
            }
        }
    }
}
