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
using BLApi;

namespace Wpf.Mangager.Managing.Add
{
    /// <summary>
    /// Interaction logic for StopManagerAdd.xaml
    /// </summary>
    public partial class StopManagerAdd : Window
    {

        private double place = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();
        bool input0 = false;
        bool input1 = false;
        bool input2 = false;


        int amount = 0;
        BackgroundWorker worker;


        double latitude;
        double longitude;
        string stopName;
        BLApi.IBL bl;




        public StopManagerAdd()
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
                worker.RunWorkerAsync(3);

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

                while (amount != 3)
                {
                    System.Threading.Thread.Sleep(500);
                    worker.ReportProgress(amount * 100 / (length ));
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


            try
            {
                bl.CreateStop(latitude, longitude, stopName);
            }


           
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                new PresentationStops().Show();
                this.Close();
                return;
            }
            MessageBox.Show("stop added!");

            new PresentationStops().Show();
            this.Close();
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
                    Longitude_Click(sender, e);
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


            if (!input0)
            {
                input0 = true;
               
            }
            if (amount != 3)
            {
                amount++;

                TextRange textRange = new TextRange(MyTextBox0.Document.ContentStart, MyTextBox0.Document.ContentEnd);
                stopName = textRange.Text;
                MessageBox.Show("input submited" + textRange.Text);
                MyTextBox0.Document.Blocks.Clear();
            }

            else
            {
                MessageBox.Show("wrong input!!!!");
                MyTextBox2.Document.Blocks.Clear();
            }
        }
     
        private void Longitude_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox1.Document.ContentStart, MyTextBox1.Document.ContentEnd);
            int result = 0;
            if (int.TryParse(textRange.Text, out result))
            {
                if (!input1)
                {
                    input1 = true;
                    
                }
                if (amount != 3)
                {
                    amount++;
                    longitude = result;
                    MessageBox.Show("input submited" + result);
                    MyTextBox1.Document.Blocks.Clear();
                }

            }
            else
            {
                MessageBox.Show("wrong input!!!!");
                MyTextBox2.Document.Blocks.Clear();
            }
        }
        private void Latitude_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox2.Document.ContentStart, MyTextBox2.Document.ContentEnd);
            int result = 0;
            if (int.TryParse(textRange.Text, out result))
            {
                if (!input2)
                {
                    input2 = true;
                   
                }
                if (amount != 3)
                {
                    amount++;
                    latitude = result;
                    MessageBox.Show("input submited" + result);
                    MyTextBox2.Document.Blocks.Clear();
                }

            }
            else
            {
                MessageBox.Show("wrong input!!!!");
                MyTextBox2.Document.Blocks.Clear();
            }
        }
    }

}
