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
    /// Interaction logic for newChildWindow.xaml
    /// </summary>
    public partial class newChildWindow : Window
    {
        static IBL myBL = BL_Factory.Get_BL;

        Child child = new Child();

        /// <summary>
        /// window constructor. set data context to Child object. determine child's mother id.
        /// </summary>
        /// <param name="motherId"></param>
        public newChildWindow(int motherId)
        {
            InitializeComponent();

            MaxHeight = 300;
            MaxWidth = 500;
            MinHeight = 300;
            MinWidth = 500;

            ChildDetailsGrid.DataContext = child;
            child.momsId = motherId;
        }

        /// <summary>
        /// Event: when clicking on the button - go to the asked window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Event: when clicking on the button - save child details.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // check the details
                checkDetailsChild();

                // adding nanny to DS
                myBL.addChild(child);

                MessageBox.Show("Child details were added", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();

            }
            catch (Exception error_str)
            {
                MessageBox.Show(error_str.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// check if the fields in the window are legal
        /// </summary>
        private void checkDetailsChild()
        {
            if (firstNameInput.Text == "")
                throw new Exception("Name is Missing!");

            if (child_id.Text == "")
                throw new Exception("ID number is Missing!");

            if (Childsbirthday.Text == "")
                throw new Exception("Birthday is Missing!");

            if (specialNeeds.IsChecked.Value)
                if (ChildsSpecialNeeds.Text == "")
                    throw new Exception("No special needs were enters");

            if (!child_id.Text.All(Char.IsDigit))
                throw new Exception("ID number input is illegal!");

            if (!firstNameInput.Text.All(Char.IsLetter))
                throw new Exception("ID number input is illegal!");
        }
    }
}
