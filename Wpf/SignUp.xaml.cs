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

namespace Wpf
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {


        private double place = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();
        bool input0 = false;
        bool input1 = false;


        string name;
        string password;


        int amount = 0;
        BackgroundWorker worker;

        BLApi.IBL bl;

        /// <summary>
        /// constractor of the window
        /// </summary>
        public SignUp()
        {
            InitializeComponent();
            busFunc();
            ProgressBar();
            bl = BLApi.Factory.GetBL("1");
        }

        /// <summary>
        /// Start up the "report progress" Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProgressBar()
        {
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWor;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            if (worker.IsBusy != true)
                worker.RunWorkerAsync(2);
        }

        /// <summary>
        ///  updat the "report progress" Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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

                while (amount != 2)
                {
                    System.Threading.Thread.Sleep(500);
                    worker.ReportProgress(amount * 100 / (length));
                }
            }
        }

        /// <summary>
        ///  updat the "report progress" Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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
                bl.CreateUser(name, password,0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
            new SignIn("PASSENGER").Show();
            this.Close();
        }


        private void busFunc()
        {
            place = movingBus.Margin.Left;
            SignUpPage.Focus();
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
                    Password_Click(sender, e);
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
            if (!input0)
            {
                input0 = true;

            }
            if (amount != 2)
            {
                amount++;
                var li = textRange.Text.Split('\r');
                name = li[0];
                MessageBox.Show("input submited" + textRange.Text);
                MyTextBox0.Document.Blocks.Clear();
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
                MyTextBox0.Document.Blocks.Clear();
            }
        }

        private void Password_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox1.Document.ContentStart, MyTextBox1.Document.ContentEnd);
            if (!input1)
            {
                input1 = true;

            }
            if (amount != 2)
            {
                amount++;
                var li = textRange.Text.Split('\r');
                password = li[0];
                MessageBox.Show("input submited" + textRange.Text);
                MyTextBox1.Document.Blocks.Clear();
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
                MyTextBox1.Document.Blocks.Clear();
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }

}