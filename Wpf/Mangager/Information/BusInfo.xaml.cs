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
using Wpf.Mangager.Presentation;
using System.Windows.Threading;
using BLImp;

namespace Wpf.Mangager.Information
{
    /// <summary>
    /// Interaction logic for BusInfo.xaml
    /// </summary>
    public partial class BusInfo : Window
    {
        
        public BO.Line tempLine;


        /// <summary>
        /// constractor of the window
        /// </summary>
        public BusInfo(BO.Bus infoBus)
        {
            InitializeComponent();
            busInfo.DataContext = infoBus;
            licenseDate1.Content = infoBus.LicenseDate.ToShortDateString();
            BLApi.IBL bl;
            bl = BLApi.Factory.GetBL("1");
            LineListB.DataContext = infoBus.LineList;
            if(infoBus.LineList == null)
            {
                information.Visibility = Visibility.Collapsed;
            }
        }


        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void home_Click(object sender, RoutedEventArgs e)
        {
            new FirstPage().Show();
            this.Close();
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void back_Click(object sender, RoutedEventArgs e)
        {
            new PresentationBusses().Show();
            this.Close();
        }
        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void information_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempLine = (BO.Line)a.DataContext;
            var ab = new LineInfo(tempLine);
            ab.Height = 350;
            ab.Width = 250;
            ab.Show();
            
        }
        /// <summary>
        /// Defines actions to be performed when the user enters input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineListB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
