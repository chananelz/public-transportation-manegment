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
using System.Diagnostics;
using System.Threading;
using BLApi;




namespace Wpf.Mangager.Presentation
{
    /// <summary>
    /// Interaction logic for board.xaml
    /// </summary>
    public partial class board : Window
    {
        List<BO.Board> toPrintL = new List<BO.Board>();
      
      

        BackgroundWorker update;
        BO.Stop stop = new BO.Stop();
        bool finish = false;
        public static BO.Board nothing = null;//have to send a sender!!!!! and is always null

        //public static event EventHandler<BO.Board> BoardChanged;


        //private static void UpdateBoard(long number, long stopCode)
        //{
        //    BoardChanged?.Invoke(nothing, new BO.Board(number,stopCode));
        //}


        public board(BO.Stop myStop)
        {
         
            stop = myStop;
            InitializeComponent();
            foreach (var num in myStop.Lines)
            {
                toPrintL.Add(new BO.Board(num.Number, 555));
                
            }
           
            LineListS.DataContext = toPrintL;
            boardList.DataContext = (from line in stop.Lines
                                    let b = new BO.Board(line.Number, stop.StopCode)
                                    where b.Arrival > new TimeSpan(0)
                                    orderby b.Arrival
                                    select b).ToList();
            //board.BoardChanged += changeText;
            UpdateBoardList();
          
            
            
            update = new BackgroundWorker();
            update.DoWork += DoWorkLineUpdate;
            update.ProgressChanged += Worker_ProgressChangedUpdate;
            update.RunWorkerCompleted += Worker_RunWorkerCompletedUpdate;
            update.WorkerReportsProgress = true;
            update.WorkerSupportsCancellation = true;
            update.RunWorkerAsync();
        }


        private void changeText(object sender, BO.Board args)
        {
           
        }


        private void UpdateBoardList()
        {
          
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();
            //while (stopWatch.Elapsed < new TimeSpan(0, 0, 10)) ;
            //new board(stop).Show();
            //this.Close();
        }


        private void DoWorkLineUpdate(object sender, DoWorkEventArgs e)
        {

            while(!finish)
            {
                update.ReportProgress(1, e);
                Thread.Sleep(1000);
            }
        }


        /// <summary>
        /// This function is responsible for the changes derived from the control progress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_ProgressChangedUpdate(object sender, ProgressChangedEventArgs e)
        {
            boardList.Items.Refresh();
        }


        ///<summary>
        /// This function is responsible for the activities that are activated at the end of the process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_RunWorkerCompletedUpdate(object sender, RunWorkerCompletedEventArgs e)
        {
            update.CancelAsync();
            if (!finish)
            {
                var ab = new board(stop);
                ab.Height = 300;
                ab.Width = 600;
                ab.Show();
                this.Close();
            }
        }



        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            update.CancelAsync();
            finish = true;
            this.Close();
        }

    }
}
