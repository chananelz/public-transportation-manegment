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
using System.Windows.Navigation;
using System.Windows.Shapes;
using dotNet5781_01_6077_5711;
using System.ComponentModel;//for background worker
using System.Diagnostics;//for stop watch

namespace dotNet5781_03_B_6077_5711
{
    /// <summary>
    /// Interaction logic for StartTravel.xaml
    /// </summary>
    public partial class StartTravel : Page
    {
        BackgroundWorker Start_Travel_Worker;
        float length;
        /// <summary>
        /// Initializing StartTravel page
        /// </summary>
        public StartTravel()
        {
            InitializeComponent();
            Start_Travel_Worker = new BackgroundWorker();
            Start_Travel_Worker.DoWork += Worker_DoWork;
            Start_Travel_Worker.ProgressChanged += Worker_ProgressChanged;
            Start_Travel_Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            Start_Travel_Worker.WorkerReportsProgress = true;
            Start_Travel_Worker.WorkerSupportsCancellation = true;
        }






        //****************************************   START TRAVEL ******************************************************

        /// <summary>
        /// /// Start up the "report progress" Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {

            // BackgroundWorker worker = sender as BackgroundWorker;
            if (Start_Travel_Worker.CancellationPending)
            {
                e.Cancel = true;
                Start_Travel_Worker.ReportProgress(0);
            }

         //   valid_Bus_List.currentDisplayBusLine.m_InTravel = false;
            for (int i = 1; i <= length; i++)
            {
                    System.Threading.Thread.Sleep(1000); 
                Start_Travel_Worker.ReportProgress(i);
            }
        }

        /// <summary>
        /// Updat the "report progress" Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage;
            if (progress % 6 != 0)
                TravelResultLabel.Content = (progress * 10 + " minutes");
            else
                TravelResultLabel.Content = (progress / 6 + " hours");
            TravelProgressBar.Value = progress * 100 / 12;
        }

        /// <summary>
        /// End of the "report progress" Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TravelResultLabel.Content = ("We have arrived!");
            System.Threading.Thread.Sleep(1000);
            if (e.Error != null)
            {
                // e.Result throw System.Reflection.TargetInvocationException
                TravelResultLabel.Content = "Error: " + e.Error.Message; // Exception Message
            }
            //  valid_Bus_List.currentDisplayBusLine.m_InTravel = false;
            valid_Bus_List.currentDisplayBusLine.m_ReadyForDrive = true;
            valid_Bus_List.currentDisplayBusLine.m_InTravel = false;
            MessageBox.Show("bus number: " + valid_Bus_List.currentDisplayBusLine.m_BusLine.ToString()+ " arrived!");
            // Start_Travel_Worker.RunWorkerAsync(12);
            //Uri uri = new Uri("valid_Bus_List.xaml", UriKind.Relative);
            //NavigationService.Navigate(uri);

        }



        /// <summary>
        /// text chnaged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyTextBox_TextChanged_0(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox0.Document.ContentStart, MyTextBox0.Document.ContentEnd);
            if (textRange.Text.Length >= 3 && textRange.Text[textRange.Text.Length - 3] == '\n')
            {
                try
                {
                    Button_Click_1(sender, e);
                }
                catch (operationException exception)
                {
                    MessageBox.Show(exception.Message);

                }

            }
        }

        /// <summary>
        ///  get the distance and begin the travel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
       {
            Random r = new Random();
            float speed = r.Next(20,49);
            Double addtion = r.NextDouble();
            speed += (float)addtion;
            TextRange textRange = new TextRange(MyTextBox0.Document.ContentStart, MyTextBox0.Document.ContentEnd);
            int result = 0;
            try
            {
                Convert.ToInt16(textRange.Text);
            }
            catch (FormatException)
            {
                throw new operationException("wrong input - enter onlly number");

            }
            
            if (int.TryParse(textRange.Text, out result) && MainWindow.M_SUPER_BUS_LIST.SuperStartTravel(valid_Bus_List.currentDisplayBusLine.m_licenseNum, result))
            {
                if (valid_Bus_List.currentDisplayBusLine.m_sum_Tr + result > 20000 || valid_Bus_List.currentDisplayBusLine.m_time_Treat <= DateTime.Now)
                {
                    throw new operationException("you need treatment before this travel");

                }
                MessageBox.Show("stating travel estimated time: " + (int)((float)result / speed) + "hours  " + (int)(((((float)result / speed)- (int)((float)result / speed))*60))  + "Minutes");
                if (Start_Travel_Worker.IsBusy != true)
                {
                    length = (float)result / speed * 5;
                    valid_Bus_List.currentDisplayBusLine.m_ReadyForDrive = false;
                    valid_Bus_List.currentDisplayBusLine.m_InTravel = true;
                    Start_Travel_Worker.RunWorkerAsync(12); // Start the asynchronous operation.
                }

            }
            else
            {
                if (!int.TryParse(textRange.Text, out result))
                {
                    throw new operationException("wrong input");
                }
                if (valid_Bus_List.currentDisplayBusLine.m_fuel + result > 1200)
                {
                    throw new operationException("you need more fuel before this travel");
                  
                }
                
                
                
            }
        }
    }
}
