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
    /// Interaction logic for MotherUserEntry.xaml
    /// </summary>
    public partial class MotherUserEntry : Window 
    {
        

        public MotherUserEntry()
        {
            InitializeComponent();
        }

        private void MotherEnter_Click(object sender, RoutedEventArgs e)
        {
            // if mother in list
            int id = Convert.ToInt32(idTextBox.DataContext);
          //  if (!MyBL.isMotherInList(id))
          //    MessageBox.Show("This Mother is not in the system.")  ;

            Window motherInfo = new MoterInfoWindow();
            Close();
            motherInfo.ShowDialog();
        }
    }
}
