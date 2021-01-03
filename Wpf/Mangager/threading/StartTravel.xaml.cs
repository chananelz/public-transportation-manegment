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
using BLApi;
using Wpf.Mangager.Presentation;

//

namespace Wpf.Mangager.threading
{
    /// <summary>
    /// Interaction logic for StartTravel.xaml
    /// </summary>
    public partial class StartTravel : Window
    {
        
        public BO.Line tempLine = new BO.Line();
        public BO.User tempDriver = new BO.User();
        public BO.Bus tempBus = new BO.Bus();
        BLApi.IBL bl;

        public StartTravel(BO.Bus mBus)
        {
            InitializeComponent();
            tempBus = mBus;
            bl = BLApi.Factory.GetBL("1");
            lineListBox.ItemsSource = bl.GetAllLines().ToList();
            DriverListBox.ItemsSource = bl.GetAllUsers(user => user.Permission == BO.authority.Driver).ToList();
        }
        private void information_Click(object sender, RoutedEventArgs e)
        {
            BLApi.IBL bl;
            bl = BLApi.Factory.GetBL("1");
            Button a = (Button)sender;
            tempLine = (BO.Line)a.DataContext;
            new LineInfo(tempLine).Show();
        }
        private void informationUser_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("didn't get to this yet!");
        }
     
        
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void StartTravel_Click(object sender, RoutedEventArgs e)
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
            new PresentationBusses().Show();

            this.Close();
        }

        private void current(object sender, RoutedEventArgs e)
        {
            //foreach(CheckBox check in )
        }

        private void lineListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tempLine = (BO.Line)lineListBox.SelectedItem;
            lineLabel.DataContext = tempLine;
        }

        private void DriverListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tempDriver = (BO.User)DriverListBox.SelectedItem;
            driverLabel.DataContext = tempDriver;
        }
    }
}