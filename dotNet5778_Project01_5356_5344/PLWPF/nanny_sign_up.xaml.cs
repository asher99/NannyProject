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
using BE;
using BL;


namespace PLWPF
{


    /// <summary>
    /// Interaction logic for nanny_sign_up.xaml
    /// </summary>
    public partial class nanny_sign_up : Window
    {

        BE.Nanny nanny;
        BL.IBL myBL;

        /// <summary>
        /// window constructor. set the Data context (Binding) to Nanny object
        /// </summary>
        public nanny_sign_up()
        {
            InitializeComponent();

            this.MaxHeight = 700;
            this.MaxWidth = 555;

            this.MinHeight = 700;
            this.MinWidth = 555;

            myBL = BL_Factory.Get_BL;
            nanny = new BE.Nanny();
            this.NannyDetailsGrid.DataContext = nanny;
        }

        /// <summary>
        /// Event: when clicking on the button - go to the asked window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Clicking on Continue Button rising this event. here all the details been checked, and the hours are installed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void continue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // check the details
                checkDetailsNanny();

                // enter the working hours.
                ReadHoursOfWork();

                // adding nanny to DS
                myBL.addNanny(nanny);

                MessageBox.Show("Your Detail now stored in our system! you can enter your personal zone any time to change them!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();


            }
            catch (Exception error_str)
            {
                MessageBox.Show(error_str.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    /*    private void newAdrressTextChanged(object sender, TextChangedEventArgs arg)
        {
            ListBox suggesteAddress = adressAutoComplete;
            TextBox searchString = nanny_address;
            List<String> list = new List<String>();
            string str = searchString.Text;

            //if (t != null && t.IsAlive)
            //    t.Abort();
            Thread process = new System.Threading.Thread(() =>
            {
                try
                {
                    list = myBL.GetPlaceAutoComplete(str);
                }
                catch (Exception e)
                {
                    throw e;
                }
            });
            process.Start();
            process.Join();

            if (list.Count() > 0)
            {
                adressAutoComplete.ItemsSource = list;
                adressAutoComplete.Visibility = Visibility.Visible;
            }

            else
            {
                adressAutoComplete.Visibility = Visibility.Collapsed;
                adressAutoComplete.ItemsSource = null;
            }
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectionChangedhelp(adressAutoComplete, nanny_address, new TextChangedEventHandler(newAdrressTextChanged));
        }

        private void SelectionChangedhelp(ListBox adressAutoComplete, TextBox    nanny_address, TextChangedEventHandler e)
        {
            if (adressAutoComplete.ItemsSource != null)
            {
                adressAutoComplete.Visibility = Visibility.Collapsed;
                nanny_address.TextChanged -= e;

                if (adressAutoComplete.SelectedIndex != -1)
                {
                    nanny_address.Text = adressAutoComplete.SelectedItem.ToString();
                }
                nanny_address.TextChanged += e;
                nanny_address.Focus();

            }
        }*/

        /// <summary>
        /// check if the details from the window are legal
        /// </summary>
        private void checkDetailsNanny()
        {

            // personal details:
            if (firstNameInput.Text == "")
                throw new Exception("First Name Is Missing");

            if (lastNameInput.Text == "")
                throw new Exception("Last Name Is Missing");

            if (nanny_birthday.Text == "")
                throw new Exception("Birth Date is Missing!");

            if (nanny_id.Text == "")
                throw new Exception("ID number is Missing!");

            if (nanny_address.Text == "")
                throw new Exception("Address is Missing!");

            if (nanny_phone.Text == "")
                throw new Exception("Phone Number is Missing!");

            if (nanny_floor.Text == "")
                throw new Exception("Floor is Missing!");

            // professional details
            if (nanny_seniority.Text == "")
                throw new Exception("Experience is Missing!");


            if (nanny_maxAge.Text == "")
                throw new Exception("Kid Maximum age is Missing!");

            if (nanny_minAge.Text == "")
                throw new Exception("Kid Minimum age is Missing!");

            if (nanny_maxOfKids.Text == "")
                throw new Exception("Maximum Number Of Kids Is Missing");

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

            if (nanny_salary_month.Text == "")
                throw new Exception("Month wage Missing!!");

            if (workPerHour.IsChecked.Value)
                if (nanny_salary_hour.Text == "")
                    throw new Exception("Hour wage Missing!!");

            // illegal inputs! working time input checked in the Day class constructor.

            if (!firstNameInput.Text.All(char.IsLetter))
                throw new Exception("First name input is illegal!");

            if (!lastNameInput.Text.All(char.IsLetter))
                throw new Exception("First name input is illegal!");


            if (!nanny_id.Text.All(Char.IsDigit))
                throw new Exception("ID number input is illegal!");

            if (!nanny_phone.Text.All(Char.IsDigit))
                throw new Exception("Phone Number input is illegal!");

            if (!nanny_maxAge.Text.All(Char.IsDigit))
                throw new Exception("Kid Maximum age input is illegal!");

            if (!nanny_minAge.Text.All(Char.IsDigit))
                throw new Exception("Kid Minimum age input is illegal!");

            if (!nanny_maxOfKids.Text.All(Char.IsDigit))
                throw new Exception("Maximum number of kids input is illegal!");

            if (!nanny_id.Text.All(Char.IsDigit))
                throw new Exception("ID number input is illegal!");

            if (!nanny_seniority.Text.All(Char.IsDigit))
                throw new Exception("Experience input is illegal!");

            if (!nanny_salary_month.Text.All(Char.IsDigit))
                throw new Exception("Month Wage input is illegal!");

            if (workPerHour.IsChecked.Value)
                if (!nanny_salary_hour.Text.All(Char.IsDigit))
                    throw new Exception("ID number input is illegal!");

            if (!nanny_floor.Text.All(Char.IsDigit))
                throw new Exception("Floor number input is illegal!");

            // check th address in Google maps, if it can't recognize it, an exception will occur!
            //myBL.findAddress(nanny_address.Text); -->this option is disabled because it take to much time to run.

        }

        /// <summary>
        /// reading the data from the window and assign it to the Nanny object
        /// </summary>
        /// <param name="nanny"></param>
        /*private void readDetailsNanny(Nanny nanny)
        {
            //personal details
            nanny.firstName = firstNameInput.Text;
            nanny.familyName = lastNameInput.Text;
            nanny.id = int.Parse(nanny_id.Text);
            nanny.address = nanny_address.Text;
            nanny.phoneNumber = nanny_phone.Text;
            nanny.birthday = nanny_birthday.SelectedDate.Value;
            nanny.floorNumber = int.Parse(nanny_floor.Text);
            nanny.hasElevator = elevator.IsChecked.Value;

            // professional details:
            nanny.seniority = int.Parse(nanny_seniority.Text);
            nanny.maxOfKids = int.Parse(nanny_maxOfKids.Text);
            nanny.maxAgeOfKid = int.Parse(nanny_maxAge.Text);
            nanny.minAgeOfKid = int.Parse(nanny_minAge.Text);
            nanny.hasGovVacationDays = govVacations.IsChecked.Value;
            nanny.Recommendations = recommendations.Text;

            // work details
            nanny.daysOfWork = new bool[6];
            nanny.daysOfWork[0] = sunday.IsChecked.Value;
            nanny.daysOfWork[1] = monday.IsChecked.Value;
            nanny.daysOfWork[2] = tuesday.IsChecked.Value;
            nanny.daysOfWork[3] = wendsday.IsChecked.Value;
            nanny.daysOfWork[4] = thrusday.IsChecked.Value;
            nanny.daysOfWork[5] = friday.IsChecked.Value;

            nanny.hoursOfWork = new Day[6];

            nanny.hoursOfWork[0] = new Day(sunday_start.Text, sunday_finish.Text);
            nanny.hoursOfWork[1] = new Day(monday_start.Text, monday_finish.Text);
            nanny.hoursOfWork[2] = new Day(tuesday_start.Text, tuesday_finish.Text);
            nanny.hoursOfWork[3] = new Day(wednesday_start.Text, wednesday_finish.Text);
            nanny.hoursOfWork[4] = new Day(thrusday_start.Text, thrusday_finish.Text);
            nanny.hoursOfWork[5] = new Day(friday_start.Text, friday_finish.Text);


            nanny.doesWorkPerHour = workPerHour.IsChecked.Value;
            nanny.monthlyWage = int.Parse(nanny_salary_month.Text);
            if (workPerHour.IsChecked.Value)
                nanny.hourWage = int.Parse(nanny_salary_hour.Text);
            else nanny.hourWage = 0;
        }*/



        /// <summary>
        /// reading the working hours from the window and assign it to the Nanny object
        /// </summary>
        /// <param name="nanny"></param>
        private void ReadHoursOfWork()
        {
            nanny.hoursOfWork[0] = new Day(sunday_start.Text, sunday_finish.Text);
            nanny.hoursOfWork[1] = new Day(monday_start.Text, monday_finish.Text);
            nanny.hoursOfWork[2] = new Day(tuesday_start.Text, tuesday_finish.Text);
            nanny.hoursOfWork[3] = new Day(wednesday_start.Text, wednesday_finish.Text);
            nanny.hoursOfWork[4] = new Day(thrusday_start.Text, thrusday_finish.Text);
            nanny.hoursOfWork[5] = new Day(friday_start.Text, friday_finish.Text);
        }
    }
}
