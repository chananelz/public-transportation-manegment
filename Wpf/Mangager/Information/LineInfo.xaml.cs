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
    /// Interaction logic for LineInfo.xaml
    /// </summary>
    public partial class LineInfo : Window
    {
        private double place = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();
        public LineInfo(BO.Line infoLine)
        {
            InitializeComponent();
          
            BLApi.IBL bl;
            bl = BLApi.Factory.GetBL("1");
            try
            {
                lineInfo.DataContext = infoLine;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            StopList.ItemsSource = infoLine.Stops;
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
            new PresentationLines().Show();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void busList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //    private void busList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //    {
        //        busList.DataContext = ((BO.Line)sender).stops;
        //}
    }
}
