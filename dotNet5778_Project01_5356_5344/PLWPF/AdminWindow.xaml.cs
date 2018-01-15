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
         //   Interface.IsEnabled = true;
        }

        private void Motherlist_Checked(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = myBL.getListOfMother();
            Add.IsEnabled = true;
         //   Interface.IsEnabled = true;
        }

        private void Childlist_Checked(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = myBL.getListOfChild();
            Add.IsEnabled = false;
        //    Interface.IsEnabled = false;
        }

        private void Contractlist_Checked(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = myBL.getListOfContract();
            Add.IsEnabled = false;
        //    Interface.IsEnabled = false;
        }


        /// <summary>
        /// Event: double click the grid when show nanny or mother list open the update details window of those object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Nannylist.IsChecked.Value)
            {
                var details = dataGrid.CurrentItem as Nanny;
                if(details.id == 0)
                {
                    MessageBox.Show("No object was selected");
                    return;
                }
                Window update_details = new nanny_update_details(details);
                update_details.ShowDialog();
            }

            if (Motherlist.IsChecked.Value)
            {
                var details = dataGrid.CurrentItem as Mother;
                if (details.id == 0)
                {
                    MessageBox.Show("No object was selected");
                    return;
                }
                Window update_details = new mother_update_details(details);
                update_details.ShowDialog();
            }
            else return;
        }

        
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(Nannylist.IsChecked.Value)
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

        private void Interface_Click(object sender, RoutedEventArgs e)
        {
           /* if (Nannylist.IsChecked.Value)
            {
                Nanny nanny = (Nanny)dataGrid.SelectedItem;

            }*/
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
