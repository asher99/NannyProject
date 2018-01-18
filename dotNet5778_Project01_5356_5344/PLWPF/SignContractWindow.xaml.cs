using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
        float static_distance_field;

        /// <summary>
        /// build the sign contract window. initial objects.
        /// </summary>
        /// <param name="mother"></param>
        /// <param name="nanny"></param>
        public SignContractWindow(Mother mother, Nanny nanny, float distance_input)
        {
            try
            {
                InitializeComponent();

                //
                /*Thread MyThread = new Thread(() => { thisContract.Distance = myBL.distanceBetweenAddresses(mother.address, nanny.address); });
                MyThread.Start();
                MyThread.Join();*/


                thisMother = mother;
                thisNanny = nanny;
                static_distance_field = distance_input;



                if (nanny.doesWorkPerHour == false)
                    byHour.IsEnabled = false;

                // find the children that suitable for nanny age-scale
                var datagridChildren = myBL.checkAgeOfKids(myBL.getListOfChildByMother(thisMother), thisNanny).ToList();

                // remove children that already got contract
                foreach (Child kid in datagridChildren.ToList())
                {
                    bool kidAlreadyHaveNanny = true;
                    foreach (Child otherKid in myBL.ChildrenWithoutNanny())
                    {
                        if (kid.id == otherKid.id)
                            kidAlreadyHaveNanny = false;
                    }

                    if (kidAlreadyHaveNanny)
                        datagridChildren.Remove(kid);
                }

                dataGrid.ItemsSource = datagridChildren;

                contract_distance.Text = distance_input.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        /// <summary>
        /// Event: when accepting terms - the Contract object got their values, and financial details show in window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Terms_accepted_Checked(object sender, RoutedEventArgs e)
        {
            // initial dates, id of nanny and more
            thisContract = new Contract(thisNanny.id);
            thisContract.Distance = static_distance_field;


            // calculate salary and salary type, also enter child ID
            try
            {

                if (!childIDNUmber.Text.All(Char.IsDigit) || childIDNUmber.Text == "")
                    throw new Exception("Child Id input is illegal!");

                thisContract.childId = int.Parse(childIDNUmber.Text);
                thisContract.isMonthContract = !byHour.IsChecked.Value;
                if (thisContract.isMonthContract)
                {
                    thisContract.monthSalary = myBL.calculateSalary(thisContract, thisNanny);
                    thisContract.moneyPerHour = 0;
                }
                else
                {
                    thisContract.monthSalary = 0;
                    thisContract.moneyPerHour = myBL.calculateSalary(thisContract, thisNanny);
                }

                try
                {
                    thisContract.ExpirationDate = datePicker.SelectedDate.Value;
                }
                catch
                {
                    MessageBox.Show("No Expiration Date!");
                    Terms_accepted.IsChecked = false;
                    return;
                }

                if (!isExpDataLegal())
                {
                    throw new Exception("Expiration Date must be at least in next month.");
                }

                // enter expiration Date
                thisContract.ExpirationDate = datePicker.SelectedDate.Value;
                // add data to text block
                Schedule.Text = Schedule_ToString();



                Billing.Text = FinancialBilling_toString();

                Additional.Text = AdditionalDetails_ToString();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                // if the process fell, make it possible to re-check.
                Terms_accepted.IsChecked = false;
            }

        }

        /// <summary>
        /// make sure the expiration date is at least in the next month
        /// </summary>
        /// <returns></returns>
        private bool isExpDataLegal()
        {
            DateTime inserted_date = datePicker.SelectedDate.Value;

            if (inserted_date.Year < DateTime.Now.Year) // check year
                return false;
            if (inserted_date.Year == DateTime.Now.Year && inserted_date.Month <= DateTime.Now.Month) // check month
                return false;


            else return true;
        }



        /// <summary>
        /// Event: ITS TIME TO SIGN! add contract to DS.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sign_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                myBL.addContract(thisContract);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                Terms_accepted.IsChecked = false;
            }

            MessageBox.Show("Contract signed! you can see the contract details any time in your interface -> view contracts"
                , "SUCCESS!", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        /// <summary>
        /// return a string that describe the schedule of the contract
        /// </summary>
        /// <returns></returns>
        private string Schedule_ToString()
        {
            string[] dayOfTheWeek = new string[6] { "Sunday: ", "Monday: ", "Tuesday: ", "Wednesday: ", "Thrusady: ", "Friday: " };

            string schedule = "Contract schedule:\n";
            for (int i = 0; i < 6; i++)
            {
                schedule += dayWork_toString(i, dayOfTheWeek[i]);
            }

            return schedule;
        }


        /// <summary>
        /// return a string that describe the schedule of one day in the week
        /// </summary>
        /// <param name="index"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        private string dayWork_toString(int index, string day)
        {
            string thisDay = day;
            if (thisMother.daysOfNanny[index])
            {
                thisDay += thisMother.hoursByNanny[index].string_start;
                thisDay += "  <-->  ";
                thisDay += thisMother.hoursByNanny[index].string_finish;
                thisDay += "\n";
            }
            else
            {
                thisDay += "children is not going to nanny\n";
            }
            return thisDay;
        }


        /// <summary>
        /// return a string describe the financial billing of the mother
        /// </summary>
        /// <returns></returns>
        private string FinancialBilling_toString()
        {
            if (thisContract.isMonthContract)
            {
                return "Monthly wage of " + thisContract.monthSalary.ToString() + " NIS";
            }
            else
            {
                return "Salary per hour is: " + thisContract.moneyPerHour.ToString() + " NIS";
            }
        }


        /// <summary>
        /// return a string with additional data like expiration date or brothers
        /// </summary>
        /// <returns></returns>
        private string AdditionalDetails_ToString()
        {
            string additional = " ";
            if (thisContract.isMonthContract)
            {
                additional += "Contract expiration date: " + thisContract.ExpirationDate.ToShortDateString() + "\n";
            }
            int brothers = myBL.brothersByNanny(thisNanny, thisMother.id);
            if (brothers >= 1)
            {
                additional += "Since this Child have " + brothers.ToString() + "brother(s) with this nanny, you got a discount of " + (brothers * 2).ToString() + " percents \n";
            }

            return additional;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
