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

namespace Wpf.Mangager.Presentation
{
    /// <summary>
    /// Interaction logic for SequentialStopPresention.xaml
    /// </summary>
    public partial class SequentialStopPresention : Window
    {
        public SequentialStopPresention()
        {
            InitializeComponent();
        }



        bool stopAPicked = false;
        bool stopBPicked = false;


        public BO.Line tempLine = new BO.Line();
        public BO.LineStation tempStopA = new BO.LineStation();
        public BO.LineStation tempStopB = new BO.LineStation();
        BLApi.IBL bl;



        public SequentialStopPresention(BO.Line mLine)
        {
            InitializeComponent();
            bl = BLApi.Factory.GetBL("1");
            tempLine = mLine;
            stopListBoxA.DataContext = tempLine.Stops;
            stopListBoxB.ItemsSource = tempLine.Stops;
        }
       



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void stopListBoxA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tempStopA = (BO.LineStation)stopListBoxA.SelectedItem;
            stopALabel.DataContext = tempStopA;
            stopAPicked = true;
            if (stopBPicked)
            {
                var a = new BO.SequentialStopInfo();
                a.Distance = bl.DistanceCalculate(tempLine.Number, tempStopA.Code, tempStopB.Code);
                a.TravelTime = bl.TravelTimeCalculate(tempLine.Number, tempStopA.Code, tempStopB.Code);
                distance_Binding.DataContext = a;
                travel_time_Binding.DataContext = a;
            }
        }

        private void stopListBoxB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tempStopB = (BO.LineStation)stopListBoxB.SelectedItem;
            stopBLabel.DataContext = tempStopB;
            stopBPicked = true;
            if (stopAPicked)
            {
                var a = new BO.SequentialStopInfo();
                a.Distance = bl.DistanceCalculate(tempLine.Number, tempStopA.Code, tempStopB.Code);
                a.TravelTime = bl.TravelTimeCalculate(tempLine.Number, tempStopA.Code, tempStopB.Code);
                distance_Binding.DataContext = a;
                travel_time_Binding.DataContext = a;
            }
        }
    }
}
