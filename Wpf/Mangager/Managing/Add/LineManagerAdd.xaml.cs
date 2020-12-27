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
using System.ComponentModel;



namespace Wpf.Mangager.Managing.Add
{
    /// <summary>
    /// Interaction logic for LineManagerAdd.xaml
    /// </summary>
    public partial class LineManagerAdd : Window
    {


        private double place = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();
        bool input0 = false;
        bool input1 = false;
        bool input2 = false;
        bool input3 = false;

        long number;
        string area;
        int firstStop;
        int lastStop;

        int amount = 0;
        BackgroundWorker worker;

        BLApi.IBL bl;




        public LineManagerAdd()
        {
            InitializeComponent();
            busFunc();
            bl = BLApi.Factory.GetBL("1");
            ProgressBar();

        }


        public void ProgressBar()
        {
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWor;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            if (worker.IsBusy != true)
                worker.RunWorkerAsync(4);
        }






        private void Worker_DoWor(object sender, DoWorkEventArgs e)
        {

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                worker.ReportProgress(0);
            }
            else
            {
                int length = (int)e.Argument;

                while (amount != 4)
                {
                    System.Threading.Thread.Sleep(500);
                    worker.ReportProgress(amount * 100 / (length));
                }
            }
        }


        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            int progress = e.ProgressPercentage;

            resultLabel.Content = (progress + "%");
            resultProgressBar.Value = progress;
        }



        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("work cancelled");
            }

            bl.CreateLine(number, area, firstStop, lastStop);

            MessageBox.Show("line added!");

            new PresentationLines().Show();
            this.Close();
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
                    FirstStop_Click(sender, e);
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
                    LastStop_Click(sender, e);
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
            long result = 0;
            if (long.TryParse(textRange.Text, out result))
            {
                if (!input0)
                {
                    input0 = true;

                }
                if (amount != 4)
                {
                    amount++;

                    number = result;
                    MessageBox.Show("input submited" + result);
                    MyTextBox0.Document.Blocks.Clear();
                }
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
            }
        }
        private void Area_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox1.Document.ContentStart, MyTextBox1.Document.ContentEnd);
            if (!input1)
            {
                input1 = true;

            }
            if (amount != 4)
            {
                amount++;

                area = textRange.Text;
                MessageBox.Show("input submited" + textRange.Text);
                MyTextBox1.Document.Blocks.Clear();
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
            }

        }
        private void FirstStop_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox2.Document.ContentStart, MyTextBox2.Document.ContentEnd);
            int result = 0;
            if (int.TryParse(textRange.Text, out result))
            {
                if (!input2)
                {
                    input2 = true;

                }
                if (amount != 4)
                {
                    amount++;
                    firstStop = result;
                    MessageBox.Show("input submited" + textRange.Text);
                    MyTextBox2.Document.Blocks.Clear();
                }
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
            }
        }

        private void LastStop_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox3.Document.ContentStart, MyTextBox3.Document.ContentEnd);
            int result = 0;
            if (int.TryParse(textRange.Text, out result))
            {
                if (!input3)
                {
                    input3 = true;

                }
                if (amount != 4)
                {
                    amount++;
                    lastStop = result;
                    MessageBox.Show("input submited" + textRange.Text);
                    MyTextBox3.Document.Blocks.Clear();
                }
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
            }
        }
    }
}