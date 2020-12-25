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
using Wpf.Mangager.Managing.Add;

namespace Wpf.Mangager.Managing
{
    /// <summary>
    /// Interaction logic for LineManager.xaml
    /// </summary>
    public partial class LineManager : Window
    {
        private double place = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();
        public LineManager()
        {
            InitializeComponent();
            busFunc();

        }

        private void busFunc()
        {
            place = movingBus.Margin.Left;
            LineManagerUpdate.Focus();
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
            new PresentationLines().Show();
            this.Close();
        }


        private void MyTextBox_TextChanged_0(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox0.Document.ContentStart, MyTextBox0.Document.ContentEnd);
            if (textRange.Text.Length >= 3 && textRange.Text[textRange.Text.Length - 3] == '\n')
            {
                try
                {
                    Number_Click(sender, e);
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
                    Area_Click(sender, e);
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
                    Stops_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void Number_Click(object sender, RoutedEventArgs e)
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
                MessageBox.Show("wrong input!!!!");
            }
        }
        private void Area_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox1.Document.ContentStart, MyTextBox1.Document.ContentEnd);
            MessageBox.Show("input submited" + textRange.Text);
            MyTextBox1.Document.Blocks.Clear();
        }
        private void Stops_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox2.Document.ContentStart, MyTextBox2.Document.ContentEnd);
            MessageBox.Show("input submited" + textRange);
            MyTextBox2.Document.Blocks.Clear();
        }
    }
}
