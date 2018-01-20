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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for PasswordLogin.xaml
    /// </summary>
    public partial class PasswordLogin : Window
    {
        /// <summary>
        /// counter for entering attempts.
        /// </summary>
        static int counter = 0;

        /// <summary>
        /// construct window
        /// </summary>
        public PasswordLogin()
        {
            InitializeComponent();

            MaxHeight = 150;
            MaxWidth = 300;
            MinHeight = 150;
            MinWidth = 300;

        }

        /// <summary>
        /// Event - check if the input is the correct password, and if it is - entering admin interface.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (passwordBox.Password.ToString() == "12345")
                {
                    new AdminWindow().Show();
                    Close();
                }
                else
                    throw new Exception("You have entered a wrong Password!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                counter++;
                if (counter == 3)
                    Close();
            }
        }
    }
}
