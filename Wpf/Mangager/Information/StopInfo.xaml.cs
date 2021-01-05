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


namespace Wpf.Mangager.Information
{
    /// <summary>
    /// Interaction logic for StopInfo.xaml
    /// </summary>
    public partial class StopInfo : Window
    {
        /// <summary>
        /// constractor of the window
        /// </summary>
        public StopInfo(BO.Stop infoStop)
        {
            InitializeComponent();
            stopInfo.DataContext = infoStop;
            BLApi.IBL bl;
            bl = BLApi.Factory.GetBL("1");
            LineListS.ItemsSource = /*bl.GetAllLinesByStopCode(infoStop.StopCode).ToList()*/infoStop.Lines;
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
            new PresentationStops().Show();
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
        /// Defines actions to be performed when the user enters input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineListS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //private void LineListS_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        //{
        //    LineListS.
        //}
    }
}
