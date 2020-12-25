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
        public PresentationBusses()
        {
            InitializeComponent();
            bl = BLApi.Factory.GetBL("1");
            busList.ItemsSource = bl.GetAllBusses().ToList();
            // stackPanel.DataContext = busList.ItemsSource;
            busFunc();
        }

        private void busFunc()
        {
            place = movingBus.Margin.Left;
            FirstPage.Focus();
            gameTimer.Tick += gameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(0.5);
            gameTimer.Start();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            if (movingBus.Margin.Left >= -600)
                movingBus.Margin = new Thickness(movingBus.Margin.Left - 8, movingBus.Margin.Top, movingBus.Margin.Right, movingBus.Margin.Bottom);
            else
                movingBus.Margin = new Thickness(place, movingBus.Margin.Top, movingBus.Margin.Right, movingBus.Margin.Bottom);
        }

        
        private void information_Click(object sender, RoutedEventArgs e)
        {

            Button a = (Button)sender;
            tempBus = (BO.Bus)a.DataContext; 
            new BusInfo(tempBus).Show();
            this.Close();
        }
        private void management_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempBus = (BO.Bus)a.DataContext;
            new BusManager(tempBus).Show();
            this.Close();
        }
        private void OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            new FirstPage().Show();
            this.Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            new Options().Show();
            this.Close();
        }

        private void busList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
           
            new BusManagerAdd().Show();
            this.Close();
        }
    }
}
