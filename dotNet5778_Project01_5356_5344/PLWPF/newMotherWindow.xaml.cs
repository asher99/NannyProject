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
    /// Interaction logic for newMotherWindow.xaml
    /// </summary>
    public partial class newMotherWindow : Window
    {
        Mother mother;
        IBL myBL;

        /// <summary>
        /// window constructor. set data context to Mother object.
        /// </summary>
        public newMotherWindow()
        {
            InitializeComponent();
            this.MaxHeight = 700;
            this.MaxWidth = 555;

            this.MinHeight = 700;
            this.MinWidth = 555;

            myBL = BL_Factory.Get_BL;
            mother = new Mother();
            this.MotherDetailsGrid.DataContext = mother;
        }

        /// <summary>
        /// Event: when clicking the button - add Mother details to DS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void continue_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // check the details
                checkDetailsMother();

                // enter the working hours.
                ReadHoursByNanny();
                ReadDaysCheckboxs();

                // adding nanny to DS
                myBL.addMother(mother);

                MessageBox.Show("Your Detail now stored in our system! you can enter your personal zone any time to change them!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();


            }
            catch (Exception error_str)
            {
                MessageBox.Show(error_str.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Event: when click - exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// check if the details from the window are legal
        /// </summary>
        private void checkDetailsMother()
        {

            // personal details:
            if (firstNameInput.Text == "")
                throw new Exception("First Name Is Missing");

            if (lastNameInput.Text == "")
                throw new Exception("Last Name Is Missing");

            if (mother_id.Text == "")
                throw new Exception("ID number is Missing!");

            if (mother_address.Text == "")
                throw new Exception("Address is Missing!");

            if (mother_phone.Text == "")
                throw new Exception("Phone Number is Missing!");



            // professional details

            if (distance.Text == "")
                throw new Exception("There is no radius search for Nanny");

            // work details:
            if (sunday_start.Text == "")
                throw new Exception("There is no start time on Sunday");

            if (monday_start.Text == "")
                throw new Exception("There is no start time on Monday");

            if (tuesday_start.Text == "")
                throw new Exception("There is no start time on Tuesday");

            if (wednesday_start.Text == "")
                throw new Exception("There is no start time on Wednesday");

            if (thrusday_start.Text == "")
                throw new Exception("There is no start time on Thursday");

            if (friday_start.Text == "")
                throw new Exception("There is no start time on Friday");
            //**************************

            if (sunday_finish.Text == "")
                throw new Exception("There is no finish time on Sunday");

            if (monday_finish.Text == "")
                throw new Exception("There is no finish time on Monday");

            if (tuesday_finish.Text == "")
                throw new Exception("There is no finish time on Tuesday");

            if (wednesday_finish.Text == "")
                throw new Exception("There is no finish time on Wednesday");

            if (thrusday_finish.Text == "")
                throw new Exception("There is no finish time on Thursday");

            if (friday_finish.Text == "")
                throw new Exception("There is no finish time on Friday");
            //**************************

            // illegal inputs! working time input checked in the Day class constructor.

            if (!firstNameInput.Text.All(char.IsLetter))
                throw new Exception("First name input is illegal!");

            if (!lastNameInput.Text.All(char.IsLetter))
                throw new Exception("First name input is illegal!");


            if (!mother_id.Text.All(Char.IsDigit))
                throw new Exception("ID number input is illegal!");

            if (!mother_phone.Text.All(Char.IsDigit))
                throw new Exception("Phone Number input is illegal!");

            if (!mother_id.Text.All(Char.IsDigit))
                throw new Exception("ID number input is illegal!");

            if(!distance.Text.All(Char.IsDigit))
                throw new Exception("Distance radious must be in meters!");

            // check th address in Google maps, if it can't recognize it, an exception will occur!
            //myBL.findAddress(nanny_address.Text); -->this option is disabled because it take to much time to run.

        }

        /// <summary>
        /// reading the working hours from the window and assign it to the Nanny object
        /// </summary>
        /// <param name="nanny"></param>
        private void ReadHoursByNanny()
        {
            mother.hoursByNanny[0] = new Day(sunday_start.Text, sunday_finish.Text);
            mother.hoursByNanny[1] = new Day(monday_start.Text, monday_finish.Text);
            mother.hoursByNanny[2] = new Day(tuesday_start.Text, tuesday_finish.Text);
            mother.hoursByNanny[3] = new Day(wednesday_start.Text, wednesday_finish.Text);
            mother.hoursByNanny[4] = new Day(thrusday_start.Text, thrusday_finish.Text);
            mother.hoursByNanny[5] = new Day(friday_start.Text, friday_finish.Text);
        }

        // since converter does not work
        private void ReadDaysCheckboxs()
        {
            mother.daysOfNanny[0] = sunday.IsChecked.Value;
            mother.daysOfNanny[1] = monday.IsChecked.Value;
            mother.daysOfNanny[2] = tuesday.IsChecked.Value;
            mother.daysOfNanny[3] = wednesday.IsChecked.Value;
            mother.daysOfNanny[4] = thrusday.IsChecked.Value;
            mother.daysOfNanny[5] = friday.IsChecked.Value;
        }
    }
}
