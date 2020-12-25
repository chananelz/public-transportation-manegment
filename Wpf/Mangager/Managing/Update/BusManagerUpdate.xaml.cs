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

namespace Wpf.Mangager.Managing
{
    /// <summary>
    /// Interaction logic for BusManager.xaml
    /// </summary>
    public partial class BusManager : Window
    { 
        private double place = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();
        public BO.Bus managingBus;

        public BusManager(BO.Bus bus)
        {
            InitializeComponent();
            managingBus = new BO.Bus();
            managingBus = bus;
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
            new PresentationBusses().Show();
            this.Close();
        }



        private void MyTextBox_TextChanged_0(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox0.Document.ContentStart, MyTextBox0.Document.ContentEnd);
            if (textRange.Text.Length >= 3 && textRange.Text[textRange.Text.Length - 3] == '\n')
            {
                try
                {
                    LicenseNumber_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void MyTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox1.Document.ContentStart, MyTextBox1.Document.ContentEnd);
            if (textRange.Text.Length >= 3 && textRange.Text[textRange.Text.Length - 3] == '\n')
            {
                try
                {
                    LicenseDate_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void MyTextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox2.Document.ContentStart, MyTextBox2.Document.ContentEnd);
            if (textRange.Text.Length >= 3 && textRange.Text[textRange.Text.Length - 3] == '\n')
            {
                try
                {
                    Travel_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void MyTextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox3.Document.ContentStart, MyTextBox3.Document.ContentEnd);
            if (textRange.Text.Length >= 3 && textRange.Text[textRange.Text.Length - 3] == '\n')
            {
                try
                {
                    Fuel_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void LicenseNumber_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox0.Document.ContentStart, MyTextBox0.Document.ContentEnd);
            int result = 0;
            if (int.TryParse(textRange.Text, out result))
            {

                MessageBox.Show("input submited" + result);
                MyTextBox0.Document.Blocks.Clear();
            }
            else
            {
                throw new Exception("wrong input!!!!");
            }
        }

        private void LicenseDate_Click(object sender, RoutedEventArgs e)
        {

            int year;
            int day;
            int month;


            string stInput;
            string stYear;
            string stDay;
            string stMonth;



            stInput = new TextRange(MyTextBox1.Document.ContentStart, MyTextBox1.Document.ContentEnd).Text;
            string[] inputValues = stInput.Split('/');

            if (inputValues.Length != 3)
            {
                throw new Exception("wrong input!!!!");
            }

            stDay = inputValues[0];
            stMonth = inputValues[1];
            stYear = inputValues[2];

            if (int.TryParse(stDay, out day) && int.TryParse(stMonth, out month) && int.TryParse(stYear, out year))
            {
                DateTime temp = new DateTime(year, month, day);
                MessageBox.Show("input submited" + stInput);
                MyTextBox1.Document.Blocks.Clear();
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
            }
        }

        private void Travel_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox2.Document.ContentStart, MyTextBox2.Document.ContentEnd);
            float result = 0;
            if (float.TryParse(textRange.Text, out result) && result > 0)
            {

                MessageBox.Show("input submited" + result);
                MyTextBox2.Document.Blocks.Clear();
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
            }
        }

        private void Fuel_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox3.Document.ContentStart, MyTextBox3.Document.ContentEnd);
            float result = 0;
            if (float.TryParse(textRange.Text, out result) && result > 0)
            {

                MessageBox.Show("input submited" + result);
                MyTextBox3.Document.Blocks.Clear();
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
            }
        }
    }
}
