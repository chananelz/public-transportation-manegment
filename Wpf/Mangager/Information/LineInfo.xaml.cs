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
    /// Interaction logic for LineInfo.xaml
    /// </summary>
    public partial class LineInfo : Window
    {
        /// <summary>
        /// constractor of the window
        /// </summary>
        public LineInfo(BO.Line infoLine)
        {
            InitializeComponent();
          
            BLApi.IBL bl;
            bl = BLApi.Factory.GetBL("1");
            try
            {
                lineInfo.DataContext = infoLine;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            StopList.ItemsSource = infoLine.Stops;
            BusesList.ItemsSource = infoLine.Buses;
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
            new PresentationLines().Show();
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
        private void busList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //    private void busList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //    {
        //        busList.DataContext = ((BO.Line)sender).stops;
        //}
    }
}
