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
using Wpf.Mangager.Information;
using Wpf.Mangager.Managing;
using System.Windows.Threading;
using Wpf.Mangager.Managing.Add;
using Wpf.Passenger;
using Wpf.CEO;


namespace Wpf.Mangager.Presentation
{
    /// <summary>
    /// Interaction logic for PresentationStops.xaml
    /// </summary>
    public partial class PresentationStops : Window
    {
        private double place = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();
        BLApi.IBL bl;
        public BO.Stop tempStop;
        public IEnumerable<BO.Stop> a;

        string au;


        /// <summary>
        /// Initializes the current window in all existing objects 
        /// </summary>
        public PresentationStops(string auInput)
        {
            InitializeComponent();
            bl = BLApi.Factory.GetBL("1");

            a = bl.GetAllStops().ToList();

            au = auInput;

            if (au == "PASSENGER")
            {
                foreach (BO.Stop stop in a)
                {
                    stop.Show = BO.status.REFULING;
                }
            }
            else
            {
                foreach (BO.Stop stop in a)
                {
                    stop.Show = BO.status.READY_FOR_DRIVE;
                }
            }
            stopList.ItemsSource = a;

        }


        /// <summary>
        /// Defines actions to be performed when the user select box frome the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void information_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempStop = (BO.Stop)a.DataContext;
            var ab = new StopInfo(tempStop);
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();

        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempStop = (BO.Stop)a.DataContext;
            var ab = new StopMangaer(tempStop);
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();

        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void home_Click(object sender, RoutedEventArgs e)
        {
            new FirstPage().Show();
            this.Close();
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (au == "DRIVER")
                new OptionsForDriver().Show();
            else if (au == "PASSENGER")
                new OptionsForPassenger().Show();
            else
                new OptionsForCEO().Show();
            this.Close();
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lineList_SelectionChanged(object sender, RoutedEventArgs e)
        {
            new OptionsForDriver().Show();
            this.Close();
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var ab = new StopManagerAdd();
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();
        }
        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempStop = (BO.Stop)a.DataContext;
            try
            {
                bl.DeleteStop(tempStop.StopCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            new PresentationStops(au).Show();
            this.Close();
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddStopToLine_Click(object sender, RoutedEventArgs e) //aaa
        {
            
            Button a = (Button)sender;
            tempStop = (BO.Stop)a.DataContext;
            var ab = new AddStopToLine(tempStop);
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();
            
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Location_Click(object sender, RoutedEventArgs e) //aaa
        {

            Button a = (Button)sender;
            tempStop = (BO.Stop)a.DataContext;
            var ab = new map(tempStop.Longitude,tempStop.Latitude);
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();
        }

        private void board_click(object sender, RoutedEventArgs e) //aaa
        {

            Button a = (Button)sender;
            tempStop = (BO.Stop)a.DataContext;
            var ab = new board(tempStop);
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();
        }
       

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
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
