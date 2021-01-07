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
using System.Windows.Threading;
using BLApi;

//netanchan

namespace Wpf
{
    /// <summary>
    /// Interaction logic for FirstPage.xaml
    /// </summary>
    public partial class FirstPage : Window
    {
        private double place = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();

        /// <summary>
        /// Initializes the current window in all existing objects 
        /// </summary>
        public FirstPage()
        {
            InitializeComponent();
            busFunc();

        }

        /// <summary>
        ///Initializes the moving bus at the bottom of the screen
        /// </summary>
        private void busFunc()
        {
            place = movingBus.Margin.Left;
            FirstPage1.Focus();
            gameTimer.Tick += gameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(0.5);
            gameTimer.Start();
        }

        /// <summary>
        /// Defines the movement of the moving bus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void gameTimerEvent(object sender, EventArgs e)
        {
            if (movingBus.Margin.Left >= -600)
                movingBus.Margin = new Thickness(movingBus.Margin.Left - 8, movingBus.Margin.Top, movingBus.Margin.Right, movingBus.Margin.Bottom);
            else
                movingBus.Margin = new Thickness(place, movingBus.Margin.Top, movingBus.Margin.Right, movingBus.Margin.Bottom);
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void user_Click(object sender, RoutedEventArgs e)
        {
            new SignIn("PASSENGER").Show();
            this.Close();
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void driver_Click(object sender, RoutedEventArgs e)
        {
            new SignIn("DRIVER").Show();
            this.Close();
        }
        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ceo_Click(object sender, RoutedEventArgs e)
        {
            new SignIn("CEO").Show();
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
        private void Map3_Click(object sender, RoutedEventArgs e)
        {
            var ab = new map4();
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();

        }
    }
}
