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


namespace Wpf.Passenger
{
    /// <summary>
    /// Interaction logic for OptionsForPassenger.xaml
    /// </summary>
    public partial class OptionsForPassenger : Window
    {

        private double place = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();

        /// <summary>
        /// Initializes the current window in all existing objects 
        /// </summary>
        public OptionsForPassenger()
        {
            InitializeComponent();
     
        }

 
        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bus_Click(object sender, RoutedEventArgs e)
        {
            new PresentationBusses("PASSENGER").Show();
            this.Close();
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void line_Click(object sender, RoutedEventArgs e)
        {
            new PresentationLines("PASSENGER").Show();
            this.Close();
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>ה
        private void stop_Click(object sender, RoutedEventArgs e)
        {
            new PresentationStops("PASSENGER").Show();
            this.Close();
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
            new FirstPage().Show();
            this.Close();
        }
        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gameTimer.Dispatcher.InvokeShutdown();
            this.Close();
        }
    }
}
