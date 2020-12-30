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
//

namespace Wpf.Mangager.threading
{
    /// <summary>
    /// Interaction logic for StartTravel.xaml
    /// </summary>
    public partial class StartTravel : Window
    {
        private double place = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();
        public BO.Line tempLine;
        public StartTravel()
        {
            InitializeComponent();
            BLApi.IBL bl;
            bl = BLApi.Factory.GetBL("1");
            lineListBox.ItemsSource = bl.GetAllLines().ToList();
            DriverListBox.ItemsSource = bl.GetAllUsers(user => user.Permission == BO.authority.Driver).ToList();
            busFunc();
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}