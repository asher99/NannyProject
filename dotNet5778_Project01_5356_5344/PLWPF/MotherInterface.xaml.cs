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
    /// Interaction logic for MoterInterface.xaml
    /// </summary>
    public partial class MoterInterface : Window
    {
        static IBL myBL = BL_Factory.Get_BL;

        Mother thisMother;

        /// <summary>
        /// window constructor.
        /// </summary>
        /// <param name="mother"></param>
        public MoterInterface(Mother mother)
        {
            InitializeComponent();
            thisMother = mother;
            dataGrid.ItemsSource = null;
            dataGrid.IsEnabled = true;
        }

        /// <summary>
        /// exit window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Event: when user choosing option - open the right window / dataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Options_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Options.SelectedIndex)
            {
                case 0: updateDetails();
                    break;
                case 1:
                    //dataGrid.ItemsSource = myBL.getListOfContractByMother(thisMother); not implement yet
                    break;
                case 2:
                    addChildToMother();
                    break;
                case 3:
                    Header.Opacity = 0;
                    dataGrid.ItemsSource = myBL.getListOfChildByMother(thisMother);
                    break;
                case 4: show_potentialNannys();
                    break;
                case 5: deleteChild();
                    break;
                case 6: deleteUser();
                    break;
            }

        }


        /// <summary>
        /// show all potential nanny
        /// </summary>
        private void show_potentialNannys()
        {
            dataGrid.ItemsSource = myBL.potentialNannys(thisMother);

            Header.Opacity = 1;
            Header.Text = "To Sign Contract, Double Click the nanny row:";
        }

        /// <summary>
        /// Event: when double click on a nanny row - open the sign contract window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Options.SelectedIndex == 4)
            {
                Nanny option = dataGrid.CurrentItem as Nanny;
                if (option == null || option.firstName == null)
                    MessageBox.Show("No Nanny was selected!");
                else
                {
                    Window signContract = new SignContractWindow(thisMother, option);
                    signContract.ShowDialog();
                }
            }
            else if(Options.SelectedIndex == 5)
            {
                Child option = dataGrid.CurrentItem as Child;
                if (option == null)
                    MessageBox.Show("No Child was selected!");
                else
                {
                    // giving last chance
                    MessageBoxResult whatNow = MessageBox.Show("Are You Sure you want to delete child data?", "", MessageBoxButton.OKCancel);
                    switch (whatNow)
                    {
                        case MessageBoxResult.Cancel: return;
                    }

                    myBL.deleteChild(option);
                    MessageBox.Show("Child information was deleted", "Delete", MessageBoxButton.OK);
                    dataGrid.ItemsSource = myBL.getListOfChildByMother(thisMother).ToList();

                }
            }
        }

        /// <summary>
        /// A window with mother details opened and make it possible to make change.
        /// </summary>
        private void updateDetails()
        {
            Header.Opacity = 0;
            Window update = new mother_update_details(thisMother);
            update.ShowDialog();
        }

        /// <summary>
        /// adding child to mother is done through a special window.
        /// </summary>
        private void addChildToMother()
        {
            Header.Opacity = 0;
            Window NewChildWindow = new newChildWindow(thisMother.id);
            NewChildWindow.ShowDialog();
        }

        /// <summary>
        ///  delete Mother
        /// </summary>
        private void deleteUser()
        {
            Header.Opacity = 0;
            // giving last chance
            MessageBoxResult whatNow = MessageBox.Show("Are You Sure you want to delete your user?", "", MessageBoxButton.OKCancel);
            switch (whatNow)
            {
                case MessageBoxResult.Cancel: return;
            }

            // delete children - all contracts are deleted in the "deleteChild(Child)" method.
            dataGrid.ItemsSource = null;
            foreach (Child son in myBL.getListOfChildByMother(thisMother).ToList())
            {
                myBL.deleteChild(son);
            }

            // delete mother
            myBL.deleteMother(thisMother);


            MessageBox.Show("GoodBye", "", MessageBoxButton.OK);
            Close();
        }


        private void deleteChild()
        {
            Header.Opacity = 1;
            Header.Text = "To Delete Child, Double Click the child row:";
            dataGrid.ItemsSource = myBL.getListOfChildByMother(thisMother).ToList();
        }
    }
}
