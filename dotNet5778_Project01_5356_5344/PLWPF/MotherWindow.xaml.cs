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
    /// Interaction logic for MotherWindow.xaml
    /// </summary>
    public partial class MotherWindow : Window
    {
        /// <summary>
        /// window constructor
        /// </summary>
        public MotherWindow()
        {
            MinHeight = 250;
            MinWidth = 300;
            MaxHeight = 250;
            MaxWidth = 300;
            InitializeComponent();
        }

        /// <summary>
        /// Event: when clicking on the button - go to the asked window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newMother_Click(object sender, RoutedEventArgs e)
        {
            Window newMother = new newMotherWindow();
            Close();
            newMother.ShowDialog();
        }

        /// <summary>
        /// Event: when clicking on the button - go to the asked window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MotherUserEnter(object sender, RoutedEventArgs e)
        {
            Window userEntry = new MotherUserEntry();
            Close();
            userEntry.ShowDialog();
        }

        /// <summary>
        /// Event: when clicking on the button - go to the asked window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backToMainMenu(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
