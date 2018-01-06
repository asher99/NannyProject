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
    /// Interaction logic for SignContractWindow.xaml
    /// </summary>
    public partial class SignContractWindow : Window
    {
        static IBL myBL = BL_Factory.Get_BL;

        public SignContractWindow(Mother mother, Nanny nanny)
        {
            InitializeComponent();
            dataGrid.ItemsSource = myBL.checkAgeOfKids(myBL.getListOfChildByMother(mother), nanny);
        }
    }
}
