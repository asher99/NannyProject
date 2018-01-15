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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        static IBL myBL = BL_Factory.Get_BL;

        /// <summary>
        /// build admin window. set the default on nanny list
        /// </summary>
        public AdminWindow()
        {
            InitializeComponent();
            var myList = myBL.GroupOfNannysByAgeOfKid(myBL.getListOfNanny(), true, false);
            // var myList = displayList();
            Nannylist.IsChecked = true;
        }




        /// <summary>
        /// multiple events for the right list to show.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Nannylist_Checked(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = myBL.getListOfNanny();
            Add.IsEnabled = true;
            Interface.IsEnabled = true;
        }

        private void Motherlist_Checked(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = myBL.getListOfMother();
            Add.IsEnabled = true;
            Interface.IsEnabled = true;
        }

        private void Childlist_Checked(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = myBL.getListOfChild();
            Add.IsEnabled = false;
            Interface.IsEnabled = false;
        }

        private void Contractlist_Checked(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = myBL.getListOfContract();
            Add.IsEnabled = false;
            Interface.IsEnabled = false;
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Nannylist.IsChecked.Value)
            {
                Window add = new nanny_sign_up();
                add.ShowDialog();
            }

            if (Motherlist.IsChecked.Value)
            {
                Window add = new newMotherWindow();
                add.ShowDialog();
            }

            if (Childlist.IsChecked.Value)
            {
                MessageBox.Show("adding child must be through mother. select mother and click \"go to interface\"", "", MessageBoxButton.OK);
            }

            if (Contractlist.IsChecked.Value)
            {
                MessageBox.Show("adding contract must be through mother. select mother and click \"go to interface\"", "", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Enter a Nanny/Mother interface from the Admin window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Interface_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Nannylist.IsChecked.Value)
                {
                    if (dataGrid.SelectedItem != null)
                    {
                        Nanny selectedNanny = (Nanny)dataGrid.SelectedItem;
                        Window nanny_interface = new NannyInterface(selectedNanny);
                        nanny_interface.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No nanny was selected!", "Error");
                        return;
                    }
                }
                if (Motherlist.IsChecked.Value)
                {
                    if (dataGrid.SelectedItem != null)
                    {
                        Mother selectedMother = (Mother)dataGrid.SelectedItem;
                        Window mother_interface = new MoterInterface(selectedMother);
                        mother_interface.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No mother was selected!", "Error");
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("No object was selected", "Error!");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (Nannylist.IsChecked.Value)
                    nanny_delete();
                if (Motherlist.IsChecked.Value)
                    mother_delete();
                if (Childlist.IsChecked.Value)
                    child_delete();
                if (Contractlist.IsChecked.Value)
                    contract_delete();
            }
            catch
            {
                MessageBox.Show("No object was selected", "Error!");
            }

        }

        private void nanny_delete()
        {
            if (dataGrid.SelectedItem != null)
            {
                Nanny selectedNanny = (Nanny)dataGrid.SelectedItem;
                myBL.deleteNanny(selectedNanny);
                dataGrid.ItemsSource = myBL.getListOfNanny();
            }
            else
            {
                MessageBox.Show("No nanny was selected!", "Error");
                return;
            }
        }

        private void mother_delete()
        {
            if (dataGrid.SelectedItem != null)
            {
                Mother selectedMother = (Mother)dataGrid.SelectedItem;
                myBL.deleteMother(selectedMother);
                dataGrid.ItemsSource = myBL.getListOfMother();
            }
            else
            {
                MessageBox.Show("No mother was selected!", "Error");
                return;
            }
        }

        private void child_delete()
        {
            if (dataGrid.SelectedItem != null)
            {
                Child selectedChild = (Child)dataGrid.SelectedItem;
                myBL.deleteChild(selectedChild);
                dataGrid.ItemsSource = myBL.getListOfChild();
            }
            else
            {
                MessageBox.Show("No child was selected!", "Error");
                return;
            }
        }

        private void contract_delete()
        {
            if (dataGrid.SelectedItem != null)
            {
                Contract selectedContract = (Contract)dataGrid.SelectedItem;
                myBL.deleteContract(selectedContract);
                dataGrid.ItemsSource = myBL.getListOfContract();
            }
            else
            {
                MessageBox.Show("No contract was selected!", "Error");
                return;
            }
        }

        /*
private void Interface_Click(object sender, RoutedEventArgs e)
{
   if (Nannylist.IsChecked.Value)
   {
       var someObject = dataGrid.CurrentItem as Nanny;
       if (someObject.id == 0)
           throw new Exception("INVALID ROW SELECTION");
       Window interf = new NannyInterface(someObject);
       interf.ShowDialog();
   }

   if (Motherlist.IsChecked.Value)
   {
       var someObject = dataGrid.CurrentItem as Mother;
       if (someObject.id == 0)
           throw new Exception("INVALID ROW SELECTION");
       Window interf = new MoterInterface(someObject);
       interf.ShowDialog();
   }

   if (Childlist.IsChecked.Value)
   {
       MessageBox.Show("there are interfaces only for Mother and Nanny", "", MessageBoxButton.OK);
   }

   if (Contractlist.IsChecked.Value)
   {
       MessageBox.Show("there are interfaces only for Mother and Nanny", "", MessageBoxButton.OK);
   }
}

private void Delete_Click(object sender, RoutedEventArgs e)
{
   try
   {
       if (Nannylist.IsChecked.Value)
       {
           var someObject = dataGrid.CurrentItem as Nanny;
           if (someObject.id == 0)
               throw new Exception("INVALID ROW SELECTION");

           myBL.deleteNanny(someObject);

       }

       if (Motherlist.IsChecked.Value)
       {
           var someObject = dataGrid.CurrentItem as Mother;
           if (someObject.id == 0)
               throw new Exception("INVALID ROW SELECTION");

           myBL.deleteMother(someObject);

       }

       if (Childlist.IsChecked.Value)
       {
           var someObject = dataGrid.CurrentItem as Child;
           if (someObject.id == 0)
               throw new Exception("INVALID ROW SELECTION");
           myBL.deleteChild(someObject);
       }

       if (Contractlist.IsChecked.Value)
       {
           var someObject = dataGrid.CurrentItem as Contract;
           if (someObject.childId == 0)
               throw new Exception("INVALID ROW SELECTION");

           myBL.deleteContract(someObject);
       }
   }
   catch(Exception err)
   {
       MessageBox.Show(err.Message);
   }
}*/
    }
}
