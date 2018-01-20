using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for GroupOfNannysByAgeOfKid.xaml
    /// </summary>
    public partial class GroupOfNannysByAgeOfKid : UserControl
    {       
        static IBL myBL = BL_Factory.Get_BL;

        private IEnumerable source;

        /// <summary>
        /// properties for the source
        /// </summary>
        public IEnumerable Source
        {
            get { return source; }
            set
            {
                source = value;
                this.listView.ItemsSource = source;
            }
        }

        /// <summary>
        ///  constructor
        /// </summary>
        public GroupOfNannysByAgeOfKid()
        {
            InitializeComponent();
        }
  
    }
}