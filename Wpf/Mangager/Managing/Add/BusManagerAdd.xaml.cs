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


namespace Wpf.Mangager.Managing.Add.myImages
{
    /// <summary>
    /// Interaction logic for BusManagerAdd.xaml
    /// </summary>
    public partial class BusManagerAdd : Window
    {
        private double place = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();
        bool input0 = false;
        bool input1 = false;
        bool input2 = false;
        bool input3 = false;
        bool input4 = false;

        long licenseNumber;
        DateTime licenseDate;
        float kM;
        float fuel;
        int statusInput;

        int amount = 0;
        BackgroundWorker worker;

        BLApi.IBL bl;

        public BusManagerAdd()
        {
            InitializeComponent();
            busFunc();
            ProgressBar();
            bl = BLApi.Factory.GetBL("1");

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
                worker.RunWorkerAsync(5);
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

                while (amount != 5)
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

          

            try
            {
                bl.CreateBus(licenseNumber, licenseDate, kM, fuel, statusInput);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                new PresentationBusses().Show();
                this.Close();
                return;
            }
            MessageBox.Show("bus added!");

            new PresentationBusses().Show();
            this.Close();
        }


        private void busFunc()
        {
            place = movingBus.Margin.Left;
            BusManagerAddPage.Focus();
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
        private void MyTextBox_TextChanged_4(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox4.Document.ContentStart, MyTextBox4.Document.ContentEnd);
            if (textRange.Text.Length >= 3 && textRange.Text[textRange.Text.Length - 3] == '\n')
            {
                try
                {
                    Status_Click(sender, e);
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
            long result = 0;
            if (long.TryParse(textRange.Text, out result))
            {
                if (!input0)
                {
                    input0 = true;
                    amount++;
                   
                }
                if (amount != 5)
                {
                    licenseNumber = result;
                    MessageBox.Show("input submited" + result);
                    MyTextBox0.Document.Blocks.Clear();
                }
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
                MyTextBox0.Document.Blocks.Clear();
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


            stDay = inputValues[0];
            stMonth = inputValues[1];
            stYear = inputValues[2];

            if (int.TryParse(stDay, out day) && int.TryParse(stMonth, out month) && int.TryParse(stYear, out year))
            {
                if (!input1)
                {
                    input1 = true;
                    amount++;
                   
                }
                if (amount != 5)
                {
                    DateTime temp = new DateTime(year, month, day);
                    licenseDate = temp;
                    MessageBox.Show("input submited" + stInput);
                    MyTextBox1.Document.Blocks.Clear();
                }
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
                MyTextBox1.Document.Blocks.Clear();
            }
        }

        private void Travel_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox2.Document.ContentStart, MyTextBox2.Document.ContentEnd);
            float result = 0;
            if (float.TryParse(textRange.Text, out result) && result > 0)
            {
                if (!input2)
                {
                    input2 = true;
                    amount++;
                    
                }
                if (amount != 5)
                {
                    MessageBox.Show("input submited" + result);
                    kM = result;
                    MyTextBox2.Document.Blocks.Clear();
                }
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
                MyTextBox2.Document.Blocks.Clear();
            }
        }

        private void Fuel_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox3.Document.ContentStart, MyTextBox3.Document.ContentEnd);
            float result = 0;
            if (float.TryParse(textRange.Text, out result) && result > 0)
            {
                if (!input3)
                {
                    input3 = true;
                    amount++;
                    
                }
                if (amount != 5)
                {
                    fuel = result;
                    MessageBox.Show("input submited" + result);
                    MyTextBox3.Document.Blocks.Clear();
                }
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
                MyTextBox3.Document.Blocks.Clear();
            }
        }
        private void Status_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox4.Document.ContentStart, MyTextBox4.Document.ContentEnd);
            int result = 0;
            if (int.TryParse(textRange.Text, out result) && result > 0)
            {
                if (!input4)
                {
                    input4 = true;
                    amount++;
                    
                }
                if (amount != 5)
                {
                    statusInput = result;
                    MessageBox.Show("input submited" + result);
                    MyTextBox4.Document.Blocks.Clear();
                }
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
                MyTextBox3.Document.Blocks.Clear();
            }
        }
    }
}
