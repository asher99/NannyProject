﻿using System;
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
                    signContract.Opacity = 0;
                    dataGrid.ItemsSource = myBL.getListOfChildByMother(thisMother);
                    break;
                case 4: show_potentialNannys();
                    break;
                case 5: deleteUser();
                    break;
            }

        }


        /// <summary>
        /// show all potential naany
        /// </summary>
        private void show_potentialNannys()
        {
            dataGrid.ItemsSource = myBL.potentialNannys(thisMother);

            signContract.Opacity = 1;
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
                if (option == null)
                    MessageBox.Show("No");
                else MessageBox.Show("Yes");
            }
            else return;
        }

        /// <summary>
        /// A window with mother details opend and make it possible to make change.
        /// </summary>
        private void updateDetails()
        {
            signContract.Opacity = 0;
            Window update = new mother_update_details(thisMother);
            update.ShowDialog();
        }

        /// <summary>
        /// adding child to mother is done through a special window.
        /// </summary>
        private void addChildToMother()
        {
            signContract.Opacity = 0;
            Window NewChildWindow = new newChildWindow(thisMother.id);
            NewChildWindow.ShowDialog();
        }

        /// <summary>
        ///  delete Mother fr
        /// </summary>
        private void deleteUser()
        {
            signContract.Opacity = 0;
            // giving last chance
            MessageBoxResult whatNow = MessageBox.Show("Are You Sure you want to delete your user?", "", MessageBoxButton.OKCancel);
            switch (whatNow)
            {
                case MessageBoxResult.Cancel: return;
            }

            // delete children - all contracts are deleted in the "deleteChild(Child)" methos.
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

    }
}
