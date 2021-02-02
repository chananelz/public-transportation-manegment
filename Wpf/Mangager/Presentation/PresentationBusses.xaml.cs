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
using System.Xml;
using System.Net;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Design;
using Wpf.Passenger;
using Wpf.CEO;
using System.Globalization;


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
        public IEnumerable<BO.Bus> a;
        string au;

        /// <summary>
        /// Initializes the current window in all existing objects 
        /// </summary>
        public PresentationBusses(string auInput)
        {
            InitializeComponent();
            bl = BLApi.Factory.GetBL("1");
            a = bl.GetAllBusses().ToList();
            busOptions.Items.Add("TRAVELING");
            busOptions.Items.Add("READY_FOR_DRIVE");
            busOptions.Items.Add("TREATING");
            busOptions.Items.Add("REFULING");

            au = auInput;

            //foreach (BO.Bus bus in a)
            //{
            //    if (bus.Status == BO.status.READY_FOR_DRIVE)
            //        bus.Show = "Visible";
            //    else bus.Show = "Collapsed";
            //}

            if (au == "PASSENGER")
            {
                foreach (BO.Bus bus in a)
                {
                    bus.Show = BO.status.REFULING;
                }
            }
            else
            {
                foreach (BO.Bus bus in a)
                {
                    bus.Show = BO.status.READY_FOR_DRIVE;
                }
            }



            busList.DataContext = a;

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
            if (au == "DRIVER")
                new OptionsForDriver().Show();
            else if (au == "PASSENGER")
                new OptionsForPassenger().Show();
            else
                new OptionsForCEO().Show();
            this.Close();
        }

        // <summary>
        /// Defines actions to be performed when the user select box frome the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void busList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //switch(busOptions.SelectedItem as string)
            //{
            //    case "TRAVELING":
            //        a = bl.GetAllBussesTraveling().ToList();
            //        break;
            //    case "READY_FOR_DRIVE":
            //        a = bl.GetAllBussesReadyForDrive().ToList();
            //        break;
            //    case "TREATING":
            //        a = bl.GetAllBussesTreating().ToList();
            //        break;
            //    case "REFULING":
            //        a = bl.GetAllBussesFueling().ToList();
            //        break;
            //}
            //foreach (BO.Bus bus in a)
            //{
            //    if (bus.Status == BO.status.READY_FOR_DRIVE)
            //        bus.Show = "Visible";
            //    else bus.Show = "Collapsed";
            //}
            //if (au == "PASSENGER")
            //{
            //    foreach (BO.Bus bus in a)
            //    {
            //        bus.NOT_VISIBLE_FOR_PASSENGER = "Collapsed";
            //        bus.Show = "Collapsed";
            //    }
            //}
            //busList.DataContext = a;

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
            gameTimer.Dispatcher.InvokeShutdown();
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
            busList.DataContext = bl.GetAllBusses().ToList();
            busList.Items.Refresh();
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
            new PresentationBusses(au).Show();
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
            new PresentationBusses(au).Show();
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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}