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
using Wpf.Mangager.Presentation;

namespace Wpf.Mangager.threading
{
    public partial class StartTravelLine : Window
    {

        public BO.Line tempLine = new BO.Line();
        public BO.User tempDriver = new BO.User();
        public BO.Bus tempBus = new BO.Bus();
        BLApi.IBL bl;



        public StartTravelLine(BO.Line mLine)
        {
            InitializeComponent();
            bl = BLApi.Factory.GetBL("1");
            busListBox.ItemsSource = bl.GetAllBussesReadyForDrive().ToList();
            DriverListBox.ItemsSource = bl.GetAllUsers(user => user.Permission == BO.authority.Driver).ToList();
        }
        private void information_Click(object sender, RoutedEventArgs e)
        {
            BLApi.IBL bl;
            bl = BLApi.Factory.GetBL("1");
            Button a = (Button)sender;
            tempLine = (BO.Line)a.DataContext;
            //new LineInfo(tempLine).Show();
        }
        private void informationUser_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("didn't get to this yet!");
        }
        private void home_Click(object sender, RoutedEventArgs e)
        {
            new FirstPage().Show();
            this.Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            new FirstPage().Show();
            this.Close();
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void busListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tempBus = (BO.Bus)busListBox.SelectedItem;
            busLabel.DataContext = tempBus;
        }

        private void DriverListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tempDriver = (BO.User)DriverListBox.SelectedItem;
            driverLabel.DataContext = tempDriver;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.CreateBusTravel(tempBus.LicenseNumber, tempLine.Id, DateTime.Now, DateTime.Now, 0, DateTime.Now, DateTime.Now, tempDriver.UserName);

            }
            catch { }
            foreach (Window w in Application.Current.Windows)
            {
                if (w.Name == "PresentatinBuses")
                {
                    w.Close();
                }
            }
            bl.UpdateBusStatus(0, tempBus.LicenseNumber);
            MessageBox.Show("bus started the travel successfully");

            this.Close();
        }
    }
}
