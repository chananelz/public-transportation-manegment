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
using System.Windows.Navigation;
using System.Windows.Shapes;
using dotNet5781_01_6077_5711;
using dotNet_5781_02_6077_5711;
using System.Windows.Threading;
//netanel bashan 0323056077
//chananel zaguri 206275711


namespace dotNet5781_03_6077_5711
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string updateArea;
        private BusRoute currentDisplayBusLine;
        BusCollection myBusCollection = new BusCollection();
        private double place = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            place = movingBus.Margin.Left;
            Assignment_3_A.Focus();
            gameTimer.Tick += gameTimerEvent;
            gameTimer.Interval = TimeSpan.FromSeconds(0.5);
            gameTimer.Start();
            List<BusStop> myUniqueStops = new List<BusStop>();
            Program_6077_5711_02.initializeBusRoute(ref myBusCollection, ref myUniqueStops);
            InitializeBusList(myBusCollection);
            this.DataContext = updateArea;
        }

        /// <summary>
        /// controll  a moving bus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameTimerEvent(object sender, EventArgs e)
        {
            if (movingBus.Margin.Left >= -148)
                movingBus.Margin = new Thickness(movingBus.Margin.Left - 8, movingBus.Margin.Top, movingBus.Margin.Right, movingBus.Margin.Bottom);
            else
                movingBus.Margin = new Thickness(place, movingBus.Margin.Top, movingBus.Margin.Right, movingBus.Margin.Bottom);
        }
        /// <summary>
        /// initialize combo box with busses
        /// </summary>
        /// <param name="myBusCollection"></param>
        public void InitializeBusList(BusCollection myBusCollection)
        {
            foreach (BusRoute myRoute in myBusCollection)
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = myRoute.ToString();
                busList.Items.Add(newItem);
            }
        }
        /// <summary>
        ///  event that responsible about a TextBox called "TextChanged"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        /// <summary>
        /// event that responsible about a ComboBox called "SelectionChanged"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        /// <summary>
        ///  event that responsible about a TextBox called "TextChanged_1"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
        /// <summary>
        /// event that responsible about a listBox called "SelectionChanged"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void busList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            string str = busList.SelectedItem?.ToString();
            if (str!=null)
            {
                currentDisplayBusLine = myBusCollection.FindBusRouteByFullName(str);
                lbBusLineStations.DataContext = currentDisplayBusLine.Stations;
                areaTextChange.DataContext = currentDisplayBusLine.m_Area;
                areaTextChange.Text = currentDisplayBusLine.m_Area ;
                Console.WriteLine("HELLO WORLD");
            }
        }
        /// <summary>
        /// event that responsible about a textBox called "TextChanged"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }
    }
}
