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
    /// Interaction logic for MoterInterface.xaml
    /// </summary>
    public partial class MoterInterface : Window
    {
        static IBL myBL = BL_Factory.Get_BL;

        Mother thisMother;
        float current_nanny_distance = 0;

        /// <summary>
        /// window constructor.
        /// </summary>
        /// <param name="mother"></param>
        public MoterInterface(Mother mother)
        {
            InitializeComponent();

            headLabel.Content = "Welcome Back " + mother.firstName + "!";
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
                case 0: //update details
                    option.IsEnabled = false;
                    option_describe.Opacity = 0;
                    updateDetails();
                    break;
                case 1: //view contracts
                    dataGrid.ItemsSource = myBL.getListOfContractByMother(thisMother).ToList();
                    option.IsEnabled = false;
                    option_describe.Opacity = 0;
                    break;
                case 2: // add child
                    option.IsEnabled = false;
                    option_describe.Opacity = 0;
                    addChildToMother();
                    break;
                case 3: // view children (also update children data)
                    option.IsEnabled = true;
                    option.Content = "Update Childern Data";
                    option.Opacity = 1;
                    option_describe.Opacity = 1;
                    option_describe.Content = "Select a Child to update his information";
                    dataGrid.ItemsSource = myBL.getListOfChildByMother(thisMother).ToList();
                    break;
                case 4: // show potential nanny
                    option.IsEnabled = true;
                    option.Content = "Sign Contract!";
                    option.Opacity = 1;
                    option_describe.Content = "Select a Nanny to sign Contract";
                    option_describe.Opacity = 1;
                    show_potentialNannys();
                    break;
                case 5: // delete child
                    option.IsEnabled = true;
                    option.Content = "Delete";
                    option.Opacity = 1;
                    option_describe.Content = "Select a Child to delete his information";
                    option_describe.Opacity = 1;
                    deleteChild();
                    break;
                case 6: // delete mother
                    deleteUser();
                    break;
            }

        }


        /// <summary>
        /// show all potential nanny
        /// </summary>
        private void show_potentialNannys()
        {
            dataGrid.ItemsSource = myBL.potentialNannys(thisMother);
        }

       

        /// <summary>
        /// A window with mother details opened and make it possible to make change.
        /// </summary>
        private void updateDetails()
        {
            option.IsEnabled = false;
            option_describe.Opacity = 0;
            Window update = new mother_update_details(thisMother);
            update.ShowDialog();
        }

        /// <summary>
        /// adding child to mother is done through a special window.
        /// </summary>
        private void addChildToMother()
        {
            Window NewChildWindow = new newChildWindow(thisMother.id);
            NewChildWindow.ShowDialog();
        }

        /// <summary>
        ///  delete Mother
        /// </summary>
        private void deleteUser()
        {
            // giving last chance
            MessageBoxResult whatNow = MessageBox.Show("Are You Sure you want to delete your user?\n Deleting your User will also Delete your children data!", "", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
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

        /// <summary>
        /// set datagrid tp show all mother's children
        /// </summary>
        private void deleteChild()
        {
            dataGrid.ItemsSource = myBL.getListOfChildByMother(thisMother).ToList();
        }

        /// <summary>
        /// Event: click - determine if the click need to delete/sign and perform the needed action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void option_Click(object sender, RoutedEventArgs e)
        {
            switch (option.Content as string)
            {
                case "Delete":
                    Child option = dataGrid.SelectedItem as Child;
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
                    break;
                case "Sign Contract!":
                    Nanny selectedNanny = dataGrid.SelectedItem as Nanny;
                    if (selectedNanny == null || selectedNanny.firstName == null)
                        MessageBox.Show("No Nanny was selected!");
                    else
                    {
                        Window signContract = new SignContractWindow(thisMother, selectedNanny, current_nanny_distance);
                        signContract.ShowDialog();
                    }
                    break;
                case "Update Childern Data":
                    Child selectedChild = dataGrid.SelectedItem as Child;
                    if (selectedChild != null)
                    {
                        Window updateChild = new child_update_details(selectedChild);
                        updateChild.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No Child was selected!");
                    }
                    break;
            }
            
        }


        /// <summary>
        /// Event: display distance from a nanny every time the user select one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Options.SelectedIndex == 4)
            {
                Nanny selected_nanny = dataGrid.SelectedItem as Nanny;
                if (selected_nanny == null)
                    return;

                Thread myThread = new Thread(() => { current_nanny_distance = myBL.distanceBetweenAddresses(thisMother.address, selected_nanny.address); });
                myThread.Start();
                myThread.Join();

                option_describe.Content = "Your Distance from " + selected_nanny.familyName + ' ' + selected_nanny.firstName + " is: "
                    + current_nanny_distance.ToString() + " Km";

                option_describe.Opacity = 1;
            }
            else return;
        }

    }
}
