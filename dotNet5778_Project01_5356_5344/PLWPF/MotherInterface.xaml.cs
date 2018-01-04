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

        public MoterInterface(Mother mother)
        {
            InitializeComponent();
            thisMother = mother;
        }

    }
}
