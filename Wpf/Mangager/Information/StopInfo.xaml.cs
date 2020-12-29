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
    /// Interaction logic for StopInfo.xaml
    /// </summary>
    public partial class StopInfo : Window
    {
        private double place = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();
        public StopInfo(BO.Stop infoStop)
        {
            InitializeComponent();
            stopInfo.DataContext = infoStop;
            BLApi.IBL bl;
            bl = BLApi.Factory.GetBL("1");
            LineListS.ItemsSource = infoStop.lines;
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

        private void home_Click(object sender, RoutedEventArgs e)
        {
            new FirstPage().Show();
            this.Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            new PresentationStops().Show();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LineListS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //private void LineListS_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        //{
        //    LineListS.
        //}
    }
}
