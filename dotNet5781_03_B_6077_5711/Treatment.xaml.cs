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
using System.ComponentModel;//for background worker
using System.Diagnostics;//for stop watch

namespace dotNet5781_03_B_6077_5711
{
    /// <summary>
    /// Interaction logic for Treatment.xaml
    /// </summary>
    public partial class Treatment : Page
    {
        BackgroundWorker refulingWorker_1;
        BackgroundWorker TreatmentWorker;
        /// <summary>
        /// manage the treatment page
        /// </summary>
        public Treatment()
        {
            InitializeComponent();
            if (valid_Bus_List.currentDisplayBusLine.m_BusLine != 0)
            {
                if (!valid_Bus_List.currentDisplayBusLine.refuling.IsBusy)
                {
                   // valid_Bus_List.currentDisplayBusLine.m_InRefueling = true;
                    valid_Bus_List.currentDisplayBusLine.refuling.DoWork += Worker_DoWork;

                    //valid_Bus_List.currentDisplayBusLine.m_InTretment = true;
                    valid_Bus_List.currentDisplayBusLine.treating.DoWork += WorkerT_DoWork;
                }
                valid_Bus_List.currentDisplayBusLine.refuling.ProgressChanged += Worker_ProgressChanged;
                valid_Bus_List.currentDisplayBusLine.refuling.RunWorkerCompleted += Worker_RunWorkerCompleted;
                valid_Bus_List.currentDisplayBusLine.refuling.WorkerReportsProgress = true;
                valid_Bus_List.currentDisplayBusLine.refuling.WorkerSupportsCancellation = true;

                valid_Bus_List.currentDisplayBusLine.treating.ProgressChanged += WorkerT_ProgressChanged;
                valid_Bus_List.currentDisplayBusLine.treating.RunWorkerCompleted += WorkerT_RunWorkerCompleted;
                valid_Bus_List.currentDisplayBusLine.treating.WorkerReportsProgress = true;
                valid_Bus_List.currentDisplayBusLine.treating.WorkerSupportsCancellation = true;
            }
        }



        //****************************************    FOR REFULING ******************************************************
        /// <summary>
        /// Start up the "ReportProgress" Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var bw = sender as BackgroundWorker;

            if (valid_Bus_List.currentDisplayBusLine != null)
            {
               // valid_Bus_List.currentDisplayBusLine.m_InTravel = false;   
               // valid_Bus_List.currentDisplayBusLine.m_InRefueling = true;
            }

            // BackgroundWorker worker = sender as BackgroundWorker;

            for (int i = 1; i <= 12; i++)
            {
                if (bw.CancellationPending == true)
                {
                   // valid_Bus_List.currentDisplayBusLine.m_InRefueling = false;
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(1000); 
                    bw.ReportProgress(i);
                }
            }

        }

        /// <summary>
        /// updat the "ReportProgress" Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage;
            if (progress % 6 != 0)
                RefulingResultLabel.Content = (progress * 10 + " minutes");
            else
                RefulingResultLabel.Content = (progress / 6 + " hours");
            RefulingResultProgressBar.Value = progress * 100 / 12;
        }

        /// <summary>
        /// End of the "report progress" Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            valid_Bus_List.currentDisplayBusLine.m_InRefueling = false;
            valid_Bus_List.currentDisplayBusLine.m_InTretment = true;

            if (e.Cancelled == true)
            {
                // e.Result throw System.InvalidOperationException
                RefulingResultLabel.Content = "Canceled!";
                return;
            }
            else if (e.Error != null)
            {
                // e.Result throw System.Reflection.TargetInvocationException
                RefulingResultLabel.Content = "Error: " + e.Error.Message; // Exception Message
                return;
            }

            valid_Bus_List.currentDisplayBusLine.m_fuel = 0;
            RefulingResultLabel.Content = "full tank";
            RefulingResultProgressBar.Value = 0;
            MessageBox.Show("full tank");
        }

        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$ CANCEL BUTTONS $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
        /// <summary>
        /// event that responsible about a Button called "StartButton"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            valid_Bus_List.currentDisplayBusLine.m_InRefueling = true;
            valid_Bus_List.currentDisplayBusLine.m_InTretment = true;
            valid_Bus_List.currentDisplayBusLine.m_ReadyForDrive = false;
            if (valid_Bus_List.currentDisplayBusLine.m_BusLine != 0 && valid_Bus_List.currentDisplayBusLine.refuling != null && !valid_Bus_List.currentDisplayBusLine.refuling.IsBusy && valid_Bus_List.currentDisplayBusLine.treating != null && !valid_Bus_List.currentDisplayBusLine.treating.IsBusy)
            {
                valid_Bus_List.currentDisplayBusLine.refuling.RunWorkerAsync(12); // Start the asynchronous operation.
                valid_Bus_List.currentDisplayBusLine.treating.RunWorkerAsync(12); // Start the asynchronous operation.
            }
        }

        /// <summary>
        /// event that responsible about a Button called "CancelButton"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (refulingWorker_1.WorkerSupportsCancellation == true && TreatmentWorker.WorkerSupportsCancellation)
            {
                refulingWorker_1.CancelAsync(); // Cancel the asynchronous operation.
                TreatmentWorker.CancelAsync(); // Cancel the asynchronous operation.
            }
        }

        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$





        //#################################   FOR TREATMENT ###################################################
        /// <summary>
        ///  Start up the "report progress" Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkerT_DoWork(object sender, DoWorkEventArgs e)
        {
            var bw = sender as BackgroundWorker;
            for (int i = 1; i <= 144; i++)
            {
                if (bw.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(1000);                                       
                    bw.ReportProgress(i);
                }
            }
        }

        /// <summary>
        /// updat the "report progress" Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkerT_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage;
            if (progress % 6 != 0)
                TreatmentResultLabel.Content = (progress * 10 + " minutes");
            else
                TreatmentResultLabel.Content = (progress / 6 + " hours");
            TreatmentResultProgressBar.Value = progress * 100 / 144;
        }

        /// <summary>
        /// End of the "report progress" Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkerT_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            valid_Bus_List.currentDisplayBusLine.m_InTretment = false;
            valid_Bus_List.currentDisplayBusLine.m_ReadyForDrive = true;
            if (e.Cancelled == true)
            {
                // e.Result throw System.InvalidOperationException
                TreatmentResultLabel.Content = "Canceled!";
                return;
            }
            else if (e.Error != null)
            {
                // e.Result throw System.Reflection.TargetInvocationException
                TreatmentResultLabel.Content = "Error: " + e.Error.Message; // Exception Message
                return;
            }
            TreatmentResultLabel.Content = "treatment over";
            TreatmentResultProgressBar.Value = 0;
            MessageBox.Show("the treatment of bus number"+ valid_Bus_List.currentDisplayBusLine.m_BusLine.ToString() +" is over");
          //  valid_Bus_List.currentDisplayBusLine.m_InTretment = false;
            valid_Bus_List.currentDisplayBusLine.m_time_Treat = DateTime.Today;

            valid_Bus_List.currentDisplayBusLine.m_time_Treat = valid_Bus_List.currentDisplayBusLine.m_time_Treat.AddYears(1);
            valid_Bus_List.currentDisplayBusLine.m_sum_Tr_Treat = 0;

            //Uri uri = new Uri("valid_Bus_List.xaml", UriKind.Relative);
            //NavigationService.Navigate(uri);
        }

    }
}