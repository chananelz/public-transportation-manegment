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

//chan


namespace Wpf.Mangager.Presentation
{
    /// <summary>
    /// Interaction logic for SequentialStopPresention.xaml
    /// </summary>
    public partial class SequentialStopPresention : Window
    {


        BackgroundWorker worker;
        int fIndex = -1;
        int sIndex = -1;

        public SequentialStopPresention()
        {
            InitializeComponent();
        }



        bool stopAPicked = false;
        bool stopBPicked = false;


        public BO.Line tempLine = new BO.Line();
        public BO.LineStation tempStopA = new BO.LineStation();
        public BO.LineStation tempStopB = new BO.LineStation();
        BLApi.IBL bl;



        public SequentialStopPresention(BO.Line mLine)
        {
            InitializeComponent();
            bl = BLApi.Factory.GetBL("1");
            tempLine = mLine;
            stopListBoxA.DataContext = tempLine.Stops;
            stopListBoxB.ItemsSource = tempLine.Stops;
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
                worker.RunWorkerAsync(0);
        }






        private void Worker_DoWor(object sender, DoWorkEventArgs e)
        {

            while (true)
            {
                //int length = (int)e.Argument;

                while (sIndex - fIndex != 1)
                {
                    System.Threading.Thread.Sleep(50);
                    worker.ReportProgress(2);
                }
                while (sIndex - fIndex == 1)
                {
                    System.Threading.Thread.Sleep(50);
                    worker.ReportProgress(1);
                }
            }
        }


        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            int progress = e.ProgressPercentage;
            switch (progress)
            {
                case 1:
                    submitDistanc.Visibility = Visibility.Visible;
                    submitTravelTime.Visibility = Visibility.Visible;
                    break;
                case 2:
                    submitDistanc.Visibility = Visibility.Collapsed;
                    submitTravelTime.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }

        }



        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (e.Cancelled)
            //{
            //    MessageBox.Show("work cancelled");
            //}



            //try
            //{
            //    bl.CreateBus(licenseNumber, licenseDate, kM, fuel, statusInput);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    new PresentationBusses().Show();
            //    this.Close();
            //    return;
            //}
            //MessageBox.Show("bus added!");
            //foreach (Window w in Application.Current.Windows)
            //{
            //    if (w.Name == "PresentatinBuses")
            //    {
            //        w.Close();
            //    }
            //}
            //new PresentationBusses().Show();

            //this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Distance_Click(object sender, RoutedEventArgs e)
        {
            string textRange = distance_Binding.Text;
            double result = 0;
            if (double.TryParse(textRange, out result))
            {
                bl.UpdateSequentialStopInfoDistance(tempStopA.Code, tempStopB.Code, result);
                MessageBox.Show("input submited " + result);
            }
            else
            {
                throw new Exception("not double!!");
            }
        }
        private void TravelTime_Click(object sender, RoutedEventArgs e)
        {
            string textRange = distance_Binding.Text;
            TimeSpan result = new TimeSpan();
            if (TimeSpan.TryParse(textRange, out result))
            {
                bl.UpdateSequentialStopInfoTravelTime(tempStopA.Code, tempStopB.Code, result);
                MessageBox.Show("input submited " + result);
            }
            else
            {
                throw new Exception("not double!!");
            }
        }
        private void stopListBoxA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tempStopA = (BO.LineStation)stopListBoxA.SelectedItem;
            stopALabel.DataContext = tempStopA;
            fIndex = stopListBoxA.SelectedIndex;
            stopAPicked = true;
            if (stopBPicked)
            {
                var a = new BO.SequentialStopInfo();
                a.Distance = bl.DistanceCalculate(tempLine.Number, tempStopA.Code, tempStopB.Code);
                a.TravelTime = bl.TravelTimeCalculate(tempLine.Number, tempStopA.Code, tempStopB.Code);
                distance_Binding.DataContext = a;
                travel_time_Binding.DataContext = a;
            }
        }

        private void stopListBoxB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tempStopB = (BO.LineStation)stopListBoxB.SelectedItem;
            stopBLabel.DataContext = tempStopB;
            sIndex = stopListBoxB.SelectedIndex;
            stopBPicked = true;
            if (stopAPicked)
            {
                var a = new BO.SequentialStopInfo();
                a.Distance = bl.DistanceCalculate(tempLine.Number, tempStopA.Code, tempStopB.Code);
                a.TravelTime = bl.TravelTimeCalculate(tempLine.Number, tempStopA.Code, tempStopB.Code);
                distance_Binding.DataContext = a;
                travel_time_Binding.DataContext = a;
            }
        }
    }
}