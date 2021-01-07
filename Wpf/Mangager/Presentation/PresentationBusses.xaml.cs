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
using Wpf.Mangager.threading;
using System.Windows.Threading;
using BLApi;
using Wpf.Mangager.Managing.Add.myImages;

// 

namespace Wpf.Mangager.Presentation
{
    /// <summary>
    /// Interaction logic for PresentationBusses.xaml
    /// </summary>
    public partial class PresentationBusses : Window
    {
        private double place = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();
        BLApi.IBL bl;
        public BO.Bus tempBus;

        /// <summary>
        /// Initializes the current window in all existing objects 
        /// </summary>
        public PresentationBusses()
        {
            InitializeComponent();
            bl = BLApi.Factory.GetBL("1");
            var a = bl.GetAllBusses().ToList();
            foreach (BO.Bus bus in a)
            {
                if (bus.Status == BO.status.READY_FOR_DRIVE)
                    bus.Show = "Visible";
                else bus.Show = "Collapsed";
            }

            busList.ItemsSource = a;
            // stackPanel.DataContext = busList.ItemsSource;
            busFunc();
        }

        /// <summary>
        ///Initializes the moving bus at the bottom of the screen
        /// </summary>
        private void busFunc()
        {

            place = movingBus.Margin.Left;
            FirstPage.Focus();
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
        private void information_Click(object sender, RoutedEventArgs e)
        {

            Button a = (Button)sender;
            tempBus = (BO.Bus)a.DataContext;
            var ab = new BusInfo(tempBus);
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void update_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempBus = (BO.Bus)a.DataContext;
            var ab = new BusManager(tempBus);
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();

        }
        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick(object sender, RoutedEventArgs e)
        {

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
            new OptionsForDriver().Show();
            this.Close();
        }

        // <summary>
        /// Defines actions to be performed when the user select box frome the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void busList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {


            Button a = (Button)sender;
            tempBus = (BO.Bus)a.DataContext;
            var ab = new BusManagerAdd();
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();
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
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempBus = (BO.Bus)a.DataContext;
            bl.DeleteBus(tempBus.LicenseNumber);
            new PresentationBusses().Show();
            this.Close();
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refule_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempBus = (BO.Bus)a.DataContext;
            bl.UpdateBusFuel(0, tempBus.LicenseNumber);
            new PresentationBusses().Show();
            this.Close();
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Treatment_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempBus = (BO.Bus)a.DataContext;
            bl.UpdateBusFuel(0, tempBus.LicenseNumber);//not implemented
            new PresentationBusses().Show();
            this.Close();
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startDrive_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempBus = (BO.Bus)a.DataContext;
            var ab = new StartTravel(tempBus);
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();
        }
    }
}
