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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public PrinterUserControl CourentPrinter;
        public Queue<PrinterUserControl> queue;

        // main
        public MainWindow()
        {
            InitializeComponent();

            // initialize queue and courent printer
            queue = new Queue<PrinterUserControl>();
            foreach (Control item in printersGrid.Children)
            {
                if (item is PrinterUserControl)
                {
                    PrinterUserControl printer = item as PrinterUserControl;
                    printer.PageMissing += OnPageMissing;
                    printer.InkEmpty += OnInkEmpty;
                    queue.Enqueue(printer);
                }
            }

            CourentPrinter = queue.Dequeue();
        }

        // print button
        private void clickToPrint(object sender, RoutedEventArgs e)
        {
            CourentPrinter.print();
        }

        // define in the publisher methods with the same name and type.
        public void OnPageMissing(object obj, PrinterEventArgs e)
        {
            // 1. print messeage to user
            MessageBox.Show("ERROR at: " + e.dateTime.ToString() + '\n' + e.printerName + " error message: "
                + e.printerMessage, "\0", MessageBoxButton.OK, MessageBoxImage.Error);

            // 2. add pages to printer
            CourentPrinter.addPages();
            CourentPrinter.pageLabel.Foreground = Brushes.Black;

            // 3. continue to next printer
            moveToNextPrinter();

        }


        public void OnInkEmpty(object obj, PrinterEventArgs e)
        {
  
            if (e.isCritical)
            {
                // 1.print messeage to user
                MessageBox.Show("ERROR at: " + e.dateTime.ToString() + '\n' + e.printerName + " error message: "
                    + e.printerMessage, "\0", MessageBoxButton.OK, MessageBoxImage.Error);

                // 2. add pages to printer
                CourentPrinter.addInk();
                CourentPrinter.inkLabel.Foreground = Brushes.Black; 

                // 3. continue to next printer
                moveToNextPrinter();

            }
            else // not critical
            {
                MessageBox.Show(e.dateTime.ToString() + '\n' + e.printerName + " warning message: " 
                    + e.printerMessage, "\0", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // move to next printer and set courent printer in the end of queue.
        public void moveToNextPrinter()
        {
            PrinterUserControl temp = CourentPrinter;
            CourentPrinter = queue.Dequeue();
            queue.Enqueue(temp);
        }

    }
}
