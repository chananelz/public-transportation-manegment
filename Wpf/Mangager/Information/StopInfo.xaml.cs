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

        public StopInfo(BO.Stop infoStop)
        {
            InitializeComponent();
            stopInfo.DataContext = infoStop;
            BLApi.IBL bl;
            bl = BLApi.Factory.GetBL("1");
            LineListS.ItemsSource = /*bl.GetAllLinesByStopCode(infoStop.StopCode).ToList()*/infoStop.Lines;
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
