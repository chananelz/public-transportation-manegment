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
using System.ComponentModel;
using System.Threading;




namespace Wpf.Mangager.Presentation
{
    /// <summary>
    /// Interaction logic for board.xaml
    /// </summary>
    public partial class board : Window
    {
        BO.Stop stop = new BO.Stop();


        public board(BO.Stop myStop)
        {
            InitializeComponent();
            stop = myStop;
            LineListS.ItemsSource = myStop.Lines;
            boardList.ItemsSource = stop.Boards;



            BackgroundWorker update = new BackgroundWorker();
            update.DoWork += DoWorkLineUpdate;
            update.ProgressChanged += Worker_ProgressChangedUpdate;
            update.RunWorkerCompleted += Worker_RunWorkerCompletedUpdate;
            update.WorkerReportsProgress = true;
            update.WorkerSupportsCancellation = true;
            update.RunWorkerAsync();
            Thread.Sleep(1000);
        }





        private void DoWorkLineUpdate(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(1000);
                LineListS.ItemsSource = stop.Lines;
                boardList.ItemsSource = stop.Boards;
            }
        }


        /// <summary>
        /// This function is responsible for the changes derived from the control progress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_ProgressChangedUpdate(object sender, ProgressChangedEventArgs e)
        {
        }


        ///<summary>
        /// This function is responsible for the activities that are activated at the end of the process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_RunWorkerCompletedUpdate(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void busList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
