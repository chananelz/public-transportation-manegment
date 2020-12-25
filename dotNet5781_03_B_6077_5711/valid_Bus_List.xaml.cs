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
using dotNet_5781_02_6077_5711;
using dotNet5781_03_B_6077_5711;
using System.ComponentModel;
using System.Diagnostics;


namespace dotNet5781_03_B_6077_5711
{
    
    /// <summary>
    /// Interaction logic for valid_Bus_List.xaml
    /// </summary>
    public partial class valid_Bus_List : Page
    {
        public static int temp = 0;
        public static SUPER_BUS currentDisplayBusLine = new SUPER_BUS();
        public valid_Bus_List()
        {
            InitializeComponent();
            InitializeBusList(MainWindow.M_SUPER_BUS_LIST);
           
        }




        /// <summary>
        /// initialize combo box with busses
        /// </summary>
        /// <param name="myBusCollection"></param>
        public void InitializeBusList(SUPER_BUS_LIST M_SUPER_BUS_LIST)
        {
            foreach (SUPER_BUS super_Bus in M_SUPER_BUS_LIST.comprehensiveCollection)
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = super_Bus.ToString();
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
        /// event that responsible about a listBox called "SelectionChanged"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void busList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string str = busList.SelectedItem?.ToString();
            if (str != null)
            {
                currentDisplayBusLine = MainWindow.M_SUPER_BUS_LIST.FinDSuperBusByFullName(str);
                lbBusLineStations.DataContext = currentDisplayBusLine.Stations;
                areaTextChange.DataContext = currentDisplayBusLine.m_Area;
                areaTextChange.Text = currentDisplayBusLine.m_Area;
                if (currentDisplayBusLine.m_fuel < 1200 && currentDisplayBusLine.m_time_Treat >= DateTime.Now && currentDisplayBusLine.m_sum_Tr_Treat < 20000)
                {
                    currentDisplayBusLine.m_ReadyForDrive = true;
                }


                if (currentDisplayBusLine.refuling == null)
                    valid_Bus_List.currentDisplayBusLine.refuling = new BackgroundWorker();
                if(currentDisplayBusLine.treating == null)
                    valid_Bus_List.currentDisplayBusLine.treating = new BackgroundWorker();
                //currentDisplayBusLine.refuling.RunWorkerAsync(12);
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
        /// <summary>
        /// event that responsible about a Button called "Get_Info"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Get_Info(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("superBusInfo.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        /// <summary>
        ///  event that responsible about a Button called "Start_Info"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Info(object sender, RoutedEventArgs e)
        {
            if (valid_Bus_List.currentDisplayBusLine.m_yearStart == 0)
            {
                MessageBox.Show("please choose bus");
                return;
            }
            if (!(currentDisplayBusLine.m_InTretment || currentDisplayBusLine.m_InRefueling || currentDisplayBusLine.m_InTravel))
            {
               
                Uri uri = new Uri("StartTravel.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
            else
            {
                MessageBox.Show("Please wait");
            }
    
        }

        /// <summary>
        ///  event that responsible about a Button called "Refuling_Button"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refuling_Button(object sender, RoutedEventArgs e)
        {
            if (valid_Bus_List.currentDisplayBusLine.m_yearStart == 0)
            {
                MessageBox.Show("please choose bus");
                return;
            }
            if (valid_Bus_List.currentDisplayBusLine.m_fuel == 0)
            {
                MessageBox.Show("full tank");
                return;
            }
            if (!(currentDisplayBusLine.m_InTretment || currentDisplayBusLine.m_InRefueling || currentDisplayBusLine.m_InTravel))
            {
                NoValideBus.Items.Add(currentDisplayBusLine.m_BusLine);
                Uri uri = new Uri("Refuling.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
            else
            {
                MessageBox.Show("Please wait");
            }
           
        }

        /// <summary>
        /// event that responsible about a Button called "Treatment_Button"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Treatment_Button(object sender, RoutedEventArgs e)
        {
            if (valid_Bus_List.currentDisplayBusLine.m_yearStart == 0)
            {
                MessageBox.Show("please choose bus");
                return;
            }
            if (!(currentDisplayBusLine.m_InTretment || currentDisplayBusLine.m_InRefueling || currentDisplayBusLine.m_InTravel))
            {
                Uri uri = new Uri("Treatment.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
                
            }
            else
            {
                MessageBox.Show("Please wait");
            }
        }

        /// <summary>
        /// give a information about specific bus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dClick(object sender, MouseButtonEventArgs e)
        {
            Uri uri = new Uri("superBusInfo.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
            
        }

       
        /// <summary>
        /// refesh the page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refresh(object sender, MouseEventArgs e)
        {
            if (temp == 0)
            {
                busList.Items.Clear();
                InitializeBusList(MainWindow.M_SUPER_BUS_LIST);
                temp++;
            }
            
        }

        /// <summary>
        /// NoValideBus initialization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void initialization(object sender, MouseEventArgs e)
        {
            NoValideBus.Items.Clear();
            
            foreach (SUPER_BUS super_Bus in MainWindow.M_SUPER_BUS_LIST.m_comprehensiveCollection)
            {
                if (super_Bus.m_InRefueling || super_Bus.m_InTravel || super_Bus.m_InTretment)
                {
                    ListBoxItem itm = new ListBoxItem();
                    itm.Content = super_Bus.m_BusLine.ToString() + " " + super_Bus.m_direction  ;
                    NoValideBus.Items.Add(itm);
                }
            }
        }
    }
}