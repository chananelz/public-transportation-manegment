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
    /// Interaction logic for superBusInf0.xaml
    /// </summary>m_ReadyForDrive
    public partial class superBusInfo : Page
    {
        BackgroundWorker worker_2;

        /// <summary>
        /// manaege the superBusInfo page
        /// </summary>
        public superBusInfo()
        {
            InitializeComponent();
            if (valid_Bus_List.currentDisplayBusLine != null)
            {
                licenseNum.Text = valid_Bus_List.currentDisplayBusLine.m_licenseNum.ToString();
                sumTr.Text = valid_Bus_List.currentDisplayBusLine.m_sum_Tr.ToString();
                sumTrTreat.Text = valid_Bus_List.currentDisplayBusLine.m_sum_Tr_Treat.ToString();
                yearSt.Text = valid_Bus_List.currentDisplayBusLine.m_yearStart.ToString();
                lastTrDate.Text = valid_Bus_List.currentDisplayBusLine.m_time_Treat.ToShortDateString();
                fueling.Text = valid_Bus_List.currentDisplayBusLine.m_InRefueling.ToString();
                treating.Text = valid_Bus_List.currentDisplayBusLine.m_InTretment.ToString();
                traveling.Text = valid_Bus_List.currentDisplayBusLine.m_InTravel.ToString();
                driving.Text = valid_Bus_List.currentDisplayBusLine.m_ReadyForDrive.ToString();

            }
            worker_2 = new BackgroundWorker();
            worker_2.DoWork += Worker_DoWor;
            worker_2.ProgressChanged += Worker_ProgressChanged;
            worker_2.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker_2.WorkerReportsProgress = true;
            worker_2.WorkerSupportsCancellation = true;
            if (worker_2.IsBusy != true)
                worker_2.RunWorkerAsync(12); // Start the asynchronous operation.
        }

        /// <summary>
        /// Start up the "report progress" Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_DoWor(object sender, DoWorkEventArgs e)
        {
            // BackgroundWorker worker = sender as BackgroundWorker;
            while (true)
            {
                if (valid_Bus_List.currentDisplayBusLine.m_Area != "")
                {
                   
                    
                    System.Threading.Thread.Sleep(500);
                    worker_2.ReportProgress((int)(100 - (valid_Bus_List.currentDisplayBusLine.m_fuel / 12)));
                    if ((int)valid_Bus_List.currentDisplayBusLine.m_fuel == 1200)
                        break;
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
            fueling.Text = valid_Bus_List.currentDisplayBusLine.m_InRefueling.ToString();
            treating.Text = valid_Bus_List.currentDisplayBusLine.m_InTretment.ToString();
            traveling.Text = valid_Bus_List.currentDisplayBusLine.m_InTravel.ToString();
            driving.Text = valid_Bus_List.currentDisplayBusLine.m_ReadyForDrive.ToString();
            lastTrDate.Text = valid_Bus_List.currentDisplayBusLine.m_time_Treat.ToShortDateString();
            sumTrTreat.Text = valid_Bus_List.currentDisplayBusLine.m_sum_Tr_Treat.ToString();
        }


        /// <summary>
        /// End of the "report progress" Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("this bus fuel is empty");
        }

        /// <summary>
        /// updat the "report progress" Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resultProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
