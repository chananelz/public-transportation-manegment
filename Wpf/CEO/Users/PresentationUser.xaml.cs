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
using System.Windows.Threading;
namespace Wpf.CEO.Users
{


    public partial class PresentationUser : Window
    {


        private double place = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();
        BLApi.IBL bl;
        public BO.User tempUser;


        public PresentationUser()
        {
            InitializeComponent();
            bl = BLApi.Factory.GetBL("1");
            userList.ItemsSource = bl.GetAllPassengers().ToList();
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
            //Button a = (Button)sender;
            //tempUser = (BO.User)a.DataContext;
            //new LineInfo(tempUser).Show();
            //this.Close();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            //Button a = (Button)sender;
            //tempLine = (BO.Line)a.DataContext;
            //new LineManager(tempLine).Show();
            //this.Close();
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
            new OptionsForCEO().Show();
            this.Close();
        }
        private void lineList_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //new LineManagerAdd().Show();
            //this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempUser = (BO.User)a.DataContext;
            try
            {
                bl.DeleteUser(tempUser.UserName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            new PresentationUser().Show();
            this.Close();
        }
    }
}
