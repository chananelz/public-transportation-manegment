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
using System.ComponentModel;
using System.Diagnostics;

namespace dotNet5781_03_B_6077_5711
{
    /// <summary>
    /// Interaction logic for Refuling.xaml
    /// </summary>
    public partial class Refuling : Page
    {
        static int amount = 0;
        /// <summary>
        /// Manege the backgroundWorker
        /// </summary>
        public Refuling()
        {
            if (valid_Bus_List.currentDisplayBusLine.m_BusLine != 0)
            {
                amount++;
                if (!valid_Bus_List.currentDisplayBusLine.refuling.IsBusy)
                {
                    //valid_Bus_List.currentDisplayBusLine.m_InRefueling = true;
                    //valid_Bus_List.currentDisplayBusLine.m_InTravel = false;
                    //valid_Bus_List.currentDisplayBusLine.m_InTretment = false;
                    valid_Bus_List.currentDisplayBusLine.refuling.DoWork += Worker_DoWor;
                }
                valid_Bus_List.currentDisplayBusLine.refuling.ProgressChanged += Worker_ProgressChanged;
                valid_Bus_List.currentDisplayBusLine.refuling.RunWorkerCompleted += Worker_RunWorkerCompleted;
                valid_Bus_List.currentDisplayBusLine.refuling.WorkerReportsProgress = true;
                valid_Bus_List.currentDisplayBusLine.refuling.WorkerSupportsCancellation = true;
            }
           
           
        }
        /// <summary>
        ///  Start up the "report progress" Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_DoWor(object sender, DoWorkEventArgs e)
        {

            var bw = sender as BackgroundWorker;
            for (int i = 1; i <= 12; i++)
            {
                if (bw.CancellationPending == true)
                {
                    e.Cancel = true;
                   // valid_Bus_List.currentDisplayBusLine.m_InRefueling = false;
                    break;
                }
                else
                {
                    //valid_Bus_List.currentDisplayBusLine.m_InRefueling = true;
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(1000);
                    if (bw.WorkerReportsProgress)
                    {
                        bw.ReportProgress(i);
                    }
                }
            }
        }
        /// <summary>
        /// updat the "report progress" Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage;
            if (this != null)
            {
                if (progress % 6 != 0)
                    this.resultLabel.Content = (progress * 10 + " minutes");
                else
                    this.resultLabel.Content = (progress / 6 + " hours");
                this.resultProgressBar.Value = progress * 100 / 12;
            }
        }
        /// <summary>
        /// End of the "report progress" Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            valid_Bus_List.currentDisplayBusLine.m_ReadyForDrive = true;
            valid_Bus_List.currentDisplayBusLine.m_InRefueling = false;
            if (e.Cancelled == true)
            {
                // e.Result throw System.InvalidOperationException
                resultLabel.Content = "Canceled!";
                System.Threading.Thread.Sleep(1000);
                this.resultProgressBar.Value = 0;
                return;
            }
            else if (e.Error != null)
            {
                // e.Result throw System.Reflection.TargetInvocationException
                resultLabel.Content = "Error: " + e.Error.Message; // Exception Message
            }
           // valid_Bus_List.currentDisplayBusLine.m_InRefueling = false;
            valid_Bus_List.currentDisplayBusLine.m_fuel = 0;
            resultLabel.Content = "full tank";
            MessageBox.Show("full tank");
            
            
        }
        /// <summary>
        /// event that responsible about a Button called "StartButton_Click"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (valid_Bus_List.currentDisplayBusLine.m_BusLine != 0 && valid_Bus_List.currentDisplayBusLine.refuling != null && !valid_Bus_List.currentDisplayBusLine.refuling.IsBusy)
                {
                    valid_Bus_List.currentDisplayBusLine.refuling.RunWorkerAsync(12); // Start the asynchronous operation.
                    valid_Bus_List.currentDisplayBusLine.m_ReadyForDrive = false;
                    valid_Bus_List.currentDisplayBusLine.m_InRefueling = true;
                }
                    
                else
                    throw new operationException("can't refule!");
            }
            catch (operationException exception)
            {
                MessageBox.Show(exception.Message);

            }
        }
        /// <summary>
        ///  event that responsible about a Button called "CancelButton_Click"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (valid_Bus_List.currentDisplayBusLine.m_BusLine != 0 && valid_Bus_List.currentDisplayBusLine.refuling != null  && valid_Bus_List.currentDisplayBusLine.refuling.WorkerSupportsCancellation == true)
            {
                valid_Bus_List.currentDisplayBusLine.refuling.CancelAsync(); // Cancel the asynchronous operation.
            }
        }
    }
}
