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

namespace Wpf.Mangager.Managing.Add
{
    /// <summary>
    /// Interaction logic for StopManagerAdd.xaml
    /// </summary>
    public partial class StopManagerAdd : Window
    {
       
        private double place = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();
        bool input_0 = false;
        bool input_1 = false;
        bool input_2 = false;
        bool input_3 = false;
        bool input_4 = false;
        bool input_5 = false;
        bool input_6 = false;

        int amount = 0;






        public StopManagerAdd()
        {
            InitializeComponent();
            busFunc();

        }

        private void busFunc()
        {
            place = movingBus.Margin.Left;
            StopManagerAddPage.Focus();
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
            new PresentationStops().Show();
            this.Close();
        }



        private void MyTextBox_TextChanged_0(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox0.Document.ContentStart, MyTextBox0.Document.ContentEnd);
            if (textRange.Text.Length >= 3 && textRange.Text[textRange.Text.Length - 3] == '\n')
            {
                try
                {
                    Name_Click(sender, e);
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
                    Code_Click(sender, e);
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
                    Longitude_Click(sender, e);
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
                    Latitude_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }
        private void Name_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox0.Document.ContentStart, MyTextBox0.Document.ContentEnd);
            MessageBox.Show("input submited" + textRange.Text);
            MyTextBox0.Document.Blocks.Clear();
        }
        private void Code_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox1.Document.ContentStart, MyTextBox1.Document.ContentEnd);
            int result = 0;
            if (int.TryParse(textRange.Text, out result))
            {

                MessageBox.Show("input submited" + result);
                MyTextBox1.Document.Blocks.Clear();
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
            }
        }
        private void Longitude_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox2.Document.ContentStart, MyTextBox2.Document.ContentEnd);
            int result = 0;
            if (int.TryParse(textRange.Text, out result))
            {

                MessageBox.Show("input submited" + result);
                MyTextBox2.Document.Blocks.Clear();
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
            }
        }
        private void Latitude_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox3.Document.ContentStart, MyTextBox3.Document.ContentEnd);
            int result = 0;
            if (int.TryParse(textRange.Text, out result))
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
