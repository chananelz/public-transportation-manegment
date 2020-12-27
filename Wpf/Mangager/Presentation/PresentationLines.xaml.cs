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


        public PresentationLines()
        {
            InitializeComponent();
            bl = BLApi.Factory.GetBL("1");
            lineList.ItemsSource = bl.GetAllLines().ToList();
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

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void information_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempLine = (BO.Line)a.DataContext;
            new LineInfo(tempLine).Show();
            this.Close();

        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempLine = (BO.Line)a.DataContext;
            new LineManager(tempLine).Show();
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
        private void lineList_SelectionChanged(object sender, RoutedEventArgs e)
        {
           
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new LineManagerAdd().Show();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempLine = (BO.Line)a.DataContext;
            try
            {
                bl.DeleteLine(tempLine.Id);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            new PresentationLines().Show();
            this.Close();
        }
    }
}
