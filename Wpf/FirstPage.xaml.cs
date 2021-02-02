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
using System.ComponentModel;

using BLApi;
using System.Diagnostics;
using System.Threading;

//netanchan

namespace Wpf
{

    

    /// <summary>
    /// Interaction logic for FirstPage.xaml
    /// </summary>
    public partial class FirstPage : Window
    {
        BackgroundWorker worker;
        BLApi.IBL bl;
        TimeSpan timeSpan = new TimeSpan();

        int speedInput = 1;


        /// <summary>
        /// Initializes the current window in all existing objects 
        /// </summary>
        public FirstPage()
        {
            InitializeComponent();

            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWor;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            bl = BLApi.Factory.GetBL("1");
            //busFunc();
            TimeSpan ts = new TimeSpan(0,0,0);
            TimeSpan toAdd = new TimeSpan(0,5,0);
            for (int i = 0; i< 48*5; i ++)
            {
                TimeList.Items.Add(ts);
                ts = ts.Add(toAdd);
            }
            //myMedia.Play();
        }



        #region background worker simulation
        /// <summary>
        /// This function manages the progress of the ProgressBar control according to the input from the user
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

                bl.Initialize(sender,timeSpan,speedInput);


                while(!worker.CancellationPending)
                {
                }

                e.Cancel = true;
                //while(true)
                //{
                //    System.Threading.Thread.Sleep(100000);
                //}

            }
        }



        /// <summary>
        /// This function is responsible for the changes derived from the control progress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            BO.DigitalScreen digitalScreen = e.UserState as BO.DigitalScreen;



            TimeSpan t = digitalScreen.CurrentTime;
            watchTime.Text = t.ToString().Substring(0,8);



            //ThreadPool.QueueUserWorkItem((o) =>
            //{
            //    Dispatcher.Invoke((Action)(() => watchTime.DataContext = digitalScreen));
            //});
            //System.Threading.Thread.Sleep(5000);
        }


        ///<summary>
        /// This function is responsible for the activities that are activated at the end of the process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("work cancelled", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                watchTime.Clear();
            }
        }

        /// <summary>
        /// start simulation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (worker.IsBusy)
            {
                MessageBox.Show("press stop first!");
                return;
            }
            int.TryParse(speedTextBox.Text, out speedInput);
            worker.RunWorkerAsync(5);
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (worker.IsBusy)
            {
                worker.CancelAsync();
                return;
            }
           
        }

       

        #endregion




        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void user_Click(object sender, RoutedEventArgs e)
        {
            new SignIn("PASSENGER").Show();
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void driver_Click(object sender, RoutedEventArgs e)
        {
            new SignIn("DRIVER").Show();
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ceo_Click(object sender, RoutedEventArgs e)
        {
            new SignIn("CEO").Show();
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Map3_Click(object sender, RoutedEventArgs e)
        {
            var ab = new map3();
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();

        }

       

        private void TimeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            timeSpan = (TimeSpan)TimeList.SelectedItem;
        }

        private void videoStart(object sender, RoutedEventArgs e)
        {
            //myMedia.Play();
        }
    }
}
