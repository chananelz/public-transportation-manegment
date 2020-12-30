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
using BO;
using Wpf.CEO;
using Wpf.Mangager;
using Wpf.Passenger;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    /// 
    public class MyData
    {
        public string UserLable { get; set; }
    }
    public partial class SignIn : Window
    {
        private double place = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();
        BLApi.IBL bl;
        string Status = "";
        public SignIn(string status)
        {
            Status = status;
            InitializeComponent();

            if (status == "DRIVER" || status == "CEO")
                Sign_In.Visibility = Visibility.Collapsed;

            MyData myData = new MyData()
            {
                UserLable = status
            };
            stackPanel.DataContext = myData;

            bl = BLApi.Factory.GetBL("1");
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

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            string password = PasswordContent.Password;
            string userName = userNameTxtBox.Text;
            authority au;
            if (Status == "PASSENGER")
                au = authority.Passenger;
            else if (Status == "DRIVER")
                au = authority.Driver;
            else
                au = authority.CEO;
            try
            {
                User user = bl.Authinticate(userName, password, au);
                if (Status == "PASSENGER")
                    new OptionsForPassenger().Show();
                else if (Status == "DRIVER")
                    new OptionsForDriver().Show();
                else
                    new OptionsForCEO().Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                new SignIn(Status).Show();
                this.Close();
            }
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            new FirstPage().Show();
            this.Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            new FirstPage().Show();
            this.Close();
        }

        private void ShowPassword_Checked_Password(object sender, RoutedEventArgs e)
        {
            passwordTxtBox.Text = PasswordContent.Password;
            PasswordContent.Visibility = Visibility.Collapsed;
            passwordTxtBox.Visibility = Visibility.Visible;
        }

        private void ShowPassword_Unchecked_Password(object sender, RoutedEventArgs e)
        {
            PasswordContent.Password = passwordTxtBox.Text;
            passwordTxtBox.Visibility = Visibility.Collapsed;
            PasswordContent.Visibility = Visibility.Visible;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            new SignUp().Show();
            this.Close();
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                submit_Click(sender, e);
        }

        private void userNameTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
