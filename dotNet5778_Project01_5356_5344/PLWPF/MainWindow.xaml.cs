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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static IBL myBL = BL_Factory.Get_BL;

        /// <summary>
        /// window constructor. including example objects definition.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            exampleObject();
        }

        /// <summary>
        /// Event: when clicking on the button - go to the asked window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goToMotherPage(object sender, RoutedEventArgs e)
        {
            Window motherPage = new MotherWindow();
            motherPage.ShowDialog();
        }

        /// <summary>
        /// Event: when clicking on the button - go to the asked window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goToNannyPage(object sender, RoutedEventArgs e)
        {
            Window nannyPage = new NannyWindow();
           nannyPage.ShowDialog();
        }

        /// <summary>
        /// Event: when clicking on the button - go to the asked window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void admin_login(object sender, RoutedEventArgs e)
        {  
            Window login = new loginAdminWindow();
            login.ShowDialog();
        }

        /// <summary>
        /// define an example object for the program
        /// </summary>
        private void exampleObject()
        {
            //Nanny objects:
            #region Rachel Nanny
            Nanny Rachel = new Nanny();
            Rachel.firstName = "Rachel";
            Rachel.familyName = "Berkovitz";
            Rachel.id = 1;
            Rachel.address = "Ha-Rav Uzi'el 20, Jerusalem";
            Rachel.phoneNumber = "0524846653";
            Rachel.birthday = new DateTime(1990, 7, 20);
            Rachel.floorNumber = 2;
            Rachel.hasElevator = false;

            Rachel.seniority = 3;
            Rachel.maxOfKids = 5;
            Rachel.maxAgeOfKid = 36;
            Rachel.minAgeOfKid = 12;
            Rachel.hasGovVacationDays = true;
            Rachel.Recommendations = "Very Nice Nanny";

            Rachel.daysOfWork = new bool[6];
            Rachel.daysOfWork[0] = true;
            Rachel.daysOfWork[1] = true;
            Rachel.daysOfWork[2] = true;
            Rachel.daysOfWork[3] = true;
            Rachel.daysOfWork[4] = true;
            Rachel.daysOfWork[5] = false;

            Rachel.hoursOfWork[0] = new Day("8:00", "15:00");
            Rachel.hoursOfWork[1] = new Day("8:00", "15:00");
            Rachel.hoursOfWork[2] = new Day("8:00", "15:00");
            Rachel.hoursOfWork[3] = new Day("8:00", "15:00");
            Rachel.hoursOfWork[4] = new Day("8:00", "15:00");
            Rachel.hoursOfWork[5] = new Day("8:00", "15:00");

            Rachel.doesWorkPerHour = false;
            Rachel.monthlyWage = 900;
            Rachel.hourWage = 0;

            myBL.addNanny(Rachel);
            #endregion

            #region Sarit
            Nanny Sarit = new Nanny();
            Sarit.firstName = "Sarit";
            Sarit.familyName = "Nave";
            Sarit.id = 2;
            Sarit.address = "Kiryat ha-Yovel Street, Jerusalem";
            Sarit.phoneNumber = "0524847554";
            Sarit.birthday = new DateTime(1999, 10, 11);
            Sarit.floorNumber = 5;
            Sarit.hasElevator = true;

            Sarit.seniority = 0;
            Sarit.maxOfKids = 5;
            Sarit.maxAgeOfKid = 36;
            Sarit.minAgeOfKid = 12;
            Sarit.hasGovVacationDays = false;
            Sarit.Recommendations = "lack experience";

            Sarit.daysOfWork = new bool[6];
            Sarit.daysOfWork[0] = true;
            Sarit.daysOfWork[1] = true;
            Sarit.daysOfWork[2] = true;
            Sarit.daysOfWork[3] = true;
            Sarit.daysOfWork[4] = true;
            Sarit.daysOfWork[5] = false;

            Sarit.hoursOfWork[0] = new Day("9:00", "18:00");
            Sarit.hoursOfWork[1] = new Day("9:00", "18:00");
            Sarit.hoursOfWork[2] = new Day("9:00", "18:00");
            Sarit.hoursOfWork[3] = new Day("9:00", "18:00");
            Sarit.hoursOfWork[4] = new Day("9:00", "18:00");
            Sarit.hoursOfWork[5] = new Day("9:00", "14:00");

            Sarit.doesWorkPerHour = true;
            Sarit.monthlyWage = 1000;
            Sarit.hourWage = 30;

            myBL.addNanny(Sarit);
            #endregion

            //Mother objects:
            #region Dana
            Mother Dana = new Mother();
            Dana.firstName = "Dana";
            Dana.familyName = "Friedman";
            Dana.id = 3;
            Dana.phoneNumber = "0502245665";
            Dana.address = "Ha-Zikaron Street, Jerusalem";
            Dana.addressRadius = "2000";
            Dana.comments = "looking for someone that work till late";
            Dana.wantsATrialMeeting = true;
            Dana.daysOfNanny = new bool[6];
            Dana.daysOfNanny[0] = true;
            Dana.daysOfNanny[1] = false;
            Dana.daysOfNanny[2] = true;
            Dana.daysOfNanny[3] = false;
            Dana.daysOfNanny[4] = false;
            Dana.daysOfNanny[5] = false;

            Dana.hoursByNanny = new Day[6];
            Dana.hoursByNanny[0] = new Day("12:00", "17:30");
            Dana.hoursByNanny[1] = new Day("12:00", "17:30");
            Dana.hoursByNanny[2] = new Day("12:00", "17:30");
            Dana.hoursByNanny[3] = new Day("12:00", "17:30");
            Dana.hoursByNanny[4] = new Day("12:00", "17:30");
            Dana.hoursByNanny[5] = new Day("12:00", "17:30");

            myBL.addMother(Dana);
            #endregion

            #region Talia
            Mother Talia = new Mother();
            Talia.firstName = "Talia";
            Talia.familyName = "Cohen";
            Talia.id = 4;
            Talia.phoneNumber = "0542231365";
            Talia.address = "Ha-Khida Street, Jerusalem";
            Talia.addressRadius = "4000";
            Talia.comments = "i need some one for daily caring";
            Talia.wantsATrialMeeting = true;
            Talia.daysOfNanny = new bool[6];
            Talia.daysOfNanny[0] = true;
            Talia.daysOfNanny[1] = true;
            Talia.daysOfNanny[2] = true;
            Talia.daysOfNanny[3] = true;
            Talia.daysOfNanny[4] = true;
            Talia.daysOfNanny[5] = false;

            Talia.hoursByNanny = new Day[6];
            Talia.hoursByNanny[0] = new Day("8:00", "13:00");
            Talia.hoursByNanny[1] = new Day("8:00", "13:00");
            Talia.hoursByNanny[2] = new Day("8:00", "13:00");
            Talia.hoursByNanny[3] = new Day("8:00", "13:00");
            Talia.hoursByNanny[4] = new Day("8:00", "13:00");
            Talia.hoursByNanny[5] = new Day("8:00", "10:00");

            myBL.addMother(Talia);
            #endregion

            //Child objects: 
            #region Yosi
            Child Yosi = new Child();
            Yosi.name = "Yosi";
            Yosi.id = 5;
            Yosi.momsId = 3;
            Yosi.birthday = new DateTime(2016,5,2);
            Yosi.hasSpecialNeeds = false;
            Yosi.specialNeeds = " ";

            myBL.addChild(Yosi);
            #endregion

            #region Dan
            Child Dan = new Child();
            Dan.name = "Dan";
            Dan.id = 6;
            Dan.momsId = 4;
            Dan.birthday = new DateTime(2015, 4, 13);
            Dan.hasSpecialNeeds = false;
            Dan.specialNeeds = " ";

            myBL.addChild(Dan);
            #endregion

            #region Miri
            Child Miri = new Child();
            Miri.name = "Miri";
            Miri.id = 7;
            Miri.momsId = 4;
            Miri.birthday = new DateTime(2016, 11, 29);
            Miri.hasSpecialNeeds = true;
            Miri.specialNeeds = "Need a lot attention";

            myBL.addChild(Miri);
            #endregion

            // Contract objects:
            #region contracts
            Contract A = new Contract(Rachel, Yosi, true);
            myBL.addContract(A);
            #endregion
        }
    }
}
