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


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for nanny_sign_up.xaml
    /// </summary>
    public partial class nanny_sign_up : Window
    {
        public nanny_sign_up()
        {
            InitializeComponent();
        }
        
        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void continue_Click(object sender, RoutedEventArgs e)
        {
            BE.Nanny nanny = new BE.Nanny();

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
            nanny.daysOfWork[0] = sunday.IsChecked.Value;
            nanny.daysOfWork[1] = monday.IsChecked.Value;
            nanny.daysOfWork[2] = tuesday.IsChecked.Value;
            nanny.daysOfWork[3] = wendsday.IsChecked.Value;
            nanny.daysOfWork[4] = thrusday.IsChecked.Value;
            nanny.daysOfWork[5] = friday.IsChecked.Value;

            nanny.hoursOfWork[0] = new Day(sunday_start.Text, sunday_finish.Text);
            nanny.hoursOfWork[0] = new Day(monday_start.Text, monday_finish.Text);
            nanny.hoursOfWork[0] = new Day(tuesday_start.Text, tuesday_finish.Text);
            nanny.hoursOfWork[0] = new Day(wendsday_start.Text, wendsday_finish.Text);
            nanny.hoursOfWork[0] = new Day(thrusday_start.Text, thrusday_finish.Text);
            nanny.hoursOfWork[0] = new Day(friday_start.Text, friday_finish.Text);

            nanny.doesWorkPerHour = workPerHour.IsChecked.Value;
            nanny.monthlyWage = int.Parse(nanny_salary_month.Text);
            if (workPerHour.IsChecked.Value)
                nanny.hourWage = int.Parse(nanny_salary_hour.Text);
            else nanny.hourWage = 0;

            nanny.numberOfSignedContracts = 0;




        }

        private void recommendations_GotFocus(object sender, RoutedEventArgs e)
        {
            if (this.recommendations.Text == "Enter Text...")
                this.recommendations.Text = "";
        }
    }
}
