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
using dotNet5781_03_B_6077_5711;
using System.ComponentModel;
using System.Diagnostics;
//netanel bashan 0323056077
//chananel zaguri 206275711

//this program manege bus collection for all that this implies: treatment , travel refueling. 
//this program also illustrate the real word


namespace dotNet5781_03_B_6077_5711
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public  partial  class MainWindow : Window
    {
        valid_Bus_List Bus_List_Page = new valid_Bus_List();
        Bus_Input Bus_Input_Page = new Bus_Input();
        superBusInfo SuperBusInfo = new superBusInfo();
        Refuling refuling = new Refuling();
        Treatment treatment = new Treatment();
        public static SUPER_BUS_LIST M_SUPER_BUS_LIST = new SUPER_BUS_LIST();



      
        public MainWindow()
        {
            InitializeComponent();
          
            
        }

        /// <summary>
        /// event that responsible about a Button called "Button_Click"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            while (Main.NavigationService.CanGoBack)
            {
                Main.NavigationService.GoBack();
            }
            //Main.Content = Bus_List_Page;
            
              Main.Navigate(Bus_List_Page);
        }

        /// <summary>
        /// event that responsible about a textBox called "TextChanged"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        /// <summary>
        /// event that responsible about a Button called "Button_Click_1"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// event that responsible about a Button called "Add_New_Bus_Button"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_New_Bus_Button(object sender, RoutedEventArgs e)
        {
            while (Main.NavigationService.CanGoBack)
            {
                Main.NavigationService.GoBack();
            }

           // Main.Content = Bus_Input_Page;
            Main.Navigate(Bus_Input_Page);
        }

        /// <summary>
        /// event that responsible about a textBox called "Button_Click_2"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            while (Main.NavigationService.CanGoBack)
            {
                Main.NavigationService.GoBack();
            }

            // Main.Content = Bus_Input_Page;
            Main.Navigate(refuling);
        }

        /// <summary>
        /// event that responsible about a Button called "Button_Click_3"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            while (Main.NavigationService.CanGoBack)
            {
                Main.NavigationService.GoBack();
            }

            // Main.Content = Bus_Input_Page;
            Main.Navigate(treatment);
        }
    }
}
