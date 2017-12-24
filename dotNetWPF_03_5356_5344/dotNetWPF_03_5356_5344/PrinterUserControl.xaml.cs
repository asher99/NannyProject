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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dotNetWPF_03_5356_5344
{

    // class PrinterEventArgs. determine data that sends with the event.
    public class PrinterEventArgs : EventArgs
    {
        public readonly bool isCritical;
        public readonly DateTime dateTime;
        public readonly string printerMessage;
        public readonly string printerName;


        // constructor
        public PrinterEventArgs(bool ic, string strMessage, string strName)
        {
            isCritical = ic;
            dateTime = DateTime.Now;
            printerMessage = strMessage;
            printerName = strName;
        }
    };

    /// <summary>
    /// Interaction logic for PrinterUserControl.xaml
    /// </summary>
    public partial class PrinterUserControl : UserControl
    {
        // static fields. those parameters used in all printers.
        public static int NumberOfPrinter = 1;
        public static Random randomUserControl = new Random();
        public static int pagesToPrint;

        // constructor
        public PrinterUserControl()
        {
            InitializeComponent();
            printerNameLabel.Content = "Printer " + NumberOfPrinter.ToString();
            // update NumberOfPrinter of the new printer
            NumberOfPrinter++;
        }

        // emulate printing.
        public void print()
        {
            // initailize number of pages to print for this print
            pagesToPrint = randomUserControl.Next(10, MAX_PRINT_INK);

            // do we have enough pages? IF FALSE: rise the event pageMissing.
            if (!(pageCountSlider.Value > pagesToPrint))
            {
                OnPageMissing();
                return;
            }

            // if we gone through the two tests, emulate printing.
            pageCountSlider.Value = pageCountSlider.Value - pagesToPrint;
            inkCountProgressBar.Value = inkCountProgressBar.Value - pagesToPrint * RATIO_INK_TO_PAGE;

            // after we print: is Ink about to end?
            if (inkCountProgressBar.Value <= 15)
            {
                OnInkEmpty();
                return;
            }

            return;
        }

        // add random amount of pages to a printer
        public void addPages()
        {
            int numOfPages = randomUserControl.Next(MIN_ADD_PAGES, MAX_PAGES - (int)pageCountSlider.Value);
            pageCountSlider.Value += numOfPages;
        }

        // add random amount of ink to a printer
        public void addInk()
        {
            double numOfInk = randomUserControl.Next((int)MIN_ADD_INK, MAX_INK - (int)inkCountProgressBar.Value);
            inkCountProgressBar.Value += numOfInk;
        }

        // const parameters
        const int MAX_INK = 100;
        const double MIN_ADD_INK = 16.1;
        const int MAX_PRINT_INK = 30;

        const int MAX_PAGES = 400;
        const int MIN_ADD_PAGES = 10;
        const int MAX_PRINT_PAGES = 30;

        const double RATIO_INK_TO_PAGE = 0.25;

        // events
        public event EventHandler<PrinterEventArgs> PageMissing;
        public event EventHandler<PrinterEventArgs> InkEmpty;

        // get methods
        public string printerName() { return (string)printerNameLabel.Content; }
        public double InkCount() { return inkCountProgressBar.Value; }
        public int PageCount() { return (int)pageCountSlider.Value; }

        // set methods
        public void printerName(string str) { printerNameLabel.Content = str; }
        public void InkCount(int num) { inkCountProgressBar.Value = num; }
        public void PageCount(int num) { pageCountSlider.Value = num; }


        // On page missing - rise the event PageMissing as critical event!.
        protected virtual void OnPageMissing()
        {

            pageLabel.Foreground = Brushes.Red;
            double pageNeeded = -(pageCountSlider.Value - pagesToPrint);
            if (PageMissing != null) // check subscribers
                PageMissing(this, new PrinterEventArgs
                    (true, "you lack " + pageNeeded.ToString()
                    + " pages\n", (string)printerNameLabel.Content));
        }

        // On ink empty - rise the event InkEmpty and determine if this is a critical event.
        protected virtual void OnInkEmpty()
        {
            double amountOfInk = inkCountProgressBar.Value;

            if (amountOfInk <= 15 && amountOfInk >= 10)
            {
                inkLabel.Foreground = Brushes.Yellow;
                if (InkEmpty != null)
                    InkEmpty(this, new PrinterEventArgs
                        (false, "amount of ink: " + amountOfInk.ToString()
                        + "\n", (string)printerNameLabel.Content));
            }
            else if (amountOfInk >= 1 && amountOfInk < 10)
            {
                inkLabel.Foreground = Brushes.Orange;
                if (InkEmpty != null)
                    InkEmpty(this, new PrinterEventArgs
                        (false, "amount of ink: " + amountOfInk.ToString()
                        + "\n", (string)printerNameLabel.Content));
            }
            else if (amountOfInk < 1)
            {
                inkLabel.Foreground = Brushes.Red;
                if (InkEmpty != null)
                    InkEmpty(this, new PrinterEventArgs
                        (true, "amount of ink: " + "THERE IS NO INK LEFT!"
                        + "\n", (string)printerNameLabel.Content));
            }
        }

        // enlarges label of printer name when hovered on
        private void EnlargeLabel(object sender, MouseEventArgs e)
        {
            printerNameLabel.FontSize = 20;
        }

        // goes back to size when mouse croser moves
        private void BackToSize(object sender, MouseEventArgs e)
        {
            printerNameLabel.FontSize = 16;
        }

        // shows the amount of ink when entering the progress bar with mouse
        private void inkProgressBar_MouseEnter(object sender, MouseEventArgs e)
        {
            inkCountProgressBar.ToolTip = inkCountProgressBar.Value + "%";
        }

    };



}
