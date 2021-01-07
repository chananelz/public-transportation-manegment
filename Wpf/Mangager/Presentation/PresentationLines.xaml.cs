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
using Wpf.Mangager.threading;


namespace Wpf.Mangager.Presentation
{
    /// <summary>
    /// Interaction logic for PresentationLines.xaml
    /// </summary>
    public partial class PresentationLines : Window
    {
        private double place = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();
        BLApi.IBL bl;
        public BO.Line tempLine;

        /// <summary>
        /// Initializes the current window in all existing objects 
        /// </summary>
        public PresentationLines()
        {
            InitializeComponent();
            bl = BLApi.Factory.GetBL("1");
            lineList.ItemsSource = bl.GetAllLines().ToList();
            busFunc();

        }

        /// <summary>
        ///Initializes the moving bus at the bottom of the screen
        /// </summary>
        private void busFunc()
        {
            place = movingBus.Margin.Left;
            FirstPage.Focus();
            gameTimer.Tick += gameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(0.5);
            gameTimer.Start();
        }

        /// <summary>
        /// Defines the movement of the moving bus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameTimerEvent(object sender, EventArgs e)
        {
            if (movingBus.Margin.Left >= -600)
                movingBus.Margin = new Thickness(movingBus.Margin.Left - 8, movingBus.Margin.Top, movingBus.Margin.Right, movingBus.Margin.Bottom);
            else
                movingBus.Margin = new Thickness(place, movingBus.Margin.Top, movingBus.Margin.Right, movingBus.Margin.Bottom);
        }

        /// <summary>
        /// Defines actions to be performed when the user select box frome the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void information_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempLine = (BO.Line)a.DataContext;
            var ab = new LineInfo(tempLine);
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            
            Button a = (Button)sender;
            tempLine = (BO.Line)a.DataContext;
            var ab = new LineManager(tempLine);
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();
            
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void home_Click(object sender, RoutedEventArgs e)
        {
            new FirstPage().Show();
            this.Close();
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void back_Click(object sender, RoutedEventArgs e)
        {
            new OptionsForDriver().Show();
            this.Close();
        }

        /// <summary>
        /// Defines actions to be performed when the user select box frome the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lineList_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var ab = new LineManagerAdd();
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartTravel_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempLine = (BO.Line)a.DataContext;
            var ab = new StartTravelLine(tempLine);
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();
        }


        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempLine = (BO.Line)a.DataContext;
            try
            {
                bl.DeleteLine(tempLine.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            new PresentationLines().Show();
            this.Close();
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lineLocation_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempLine = (BO.Line)a.DataContext;
            var ab = new map2(tempLine.Number);
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeqStopInfo_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempLine = (BO.Line)a.DataContext;
            var ab = new SequentialStopPresention(tempLine);
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();
        }
    }
}
