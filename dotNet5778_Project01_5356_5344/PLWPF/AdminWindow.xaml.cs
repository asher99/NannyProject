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
    /// Interaction logic for loginAdminWindow.xaml
    /// </summary>
    public partial class loginAdminWindow : Window
    {
        static IBL myBL = BL_Factory.Get_BL;

        public loginAdminWindow()
        {
            InitializeComponent();
            var myList = myBL.getListOfNanny();
           // var myList = displayList();
            dataGrid.ItemsSource = myList;
        }
        
        private IEnumerable<Nanny> displayList()
        {
            if (Nannylist.IsChecked == true)
            {
                return myBL.getListOfNanny();
            }
/*
            if (Motherlist.IsChecked == true)
            {
                return myBL.getListOfMother();
            }

            if (Childlist.IsChecked == true)
            {
                return myBL.getListOfChild();
            }

            if (Contractlist.IsChecked == true)
            {
                return myBL.getListOfContract();
            }
  */
            return null; 
        }
    }
}
