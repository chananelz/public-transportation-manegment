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

namespace Wpf.Mangager.Managing.Add
{
    /// <summary>
    /// Interaction logic for StopManagerAdd.xaml
    /// </summary>
    public partial class StopManagerAdd : Window
    {

        bool input0 = false;
        bool input1 = false;
        bool input2 = false;


        int amount = 0;
        BackgroundWorker worker;


        double latitude;
        double longitude;
        string stopName;
        BLApi.IBL bl;




        public StopManagerAdd()
        {
            InitializeComponent();
            bl = BLApi.Factory.GetBL("1");

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
                worker.RunWorkerAsync(3);

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

                while (amount != 3)
                {
                    System.Threading.Thread.Sleep(500);
                    worker.ReportProgress(amount * 100 / (length ));
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
                bl.CreateStop(latitude, longitude, stopName);
            }


           
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                new PresentationStops().Show();
                this.Close();
                return;
            }
            MessageBox.Show("stop added!");
            foreach (Window w in Application.Current.Windows)
            {
                if (w.Name == "PresentatinStops1")
                {
                    w.Close();
                }
            }
            new PresentationLines().Show();
            this.Topmost = true;

            this.Close();
        }


        


       





        private void MyTextBox0_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
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


        private void MyTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                try
                {
                    Longitude_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void MyTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                try
                {
                    Latitude_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

      

       





        private void Name_Click(object sender, RoutedEventArgs e)
        {


            if (!input0)
            {
                input0 = true;
               
            }
            if (amount != 3)
            {
                amount++;

                string textRange =  MyTextBox0.Text;
                stopName = textRange;
                MessageBox.Show("input submited" + textRange);
                MyTextBox0.Clear();
            }

            else
            {
                MessageBox.Show("wrong input!!!!");
                MyTextBox2.Clear();
            }
        }
     
        private void Longitude_Click(object sender, RoutedEventArgs e)
        {
            string textRange = MyTextBox1.Text;
            int result = 0;
            if (int.TryParse(textRange, out result))
            {
                if (!input1)
                {
                    input1 = true;
                    
                }
                if (amount != 3)
                {
                    amount++;
                    longitude = result;
                    MessageBox.Show("input submited" + result);
                    MyTextBox1.Clear();
                }

            }
            else
            {
                MessageBox.Show("wrong input!!!!");
                MyTextBox1.Clear();
            }
        }
        private void Latitude_Click(object sender, RoutedEventArgs e)
        {
            string textRange = MyTextBox2.Text;
            int result = 0;
            if (int.TryParse(textRange, out result))
            {
                if (!input2)
                {
                    input2 = true;
                   
                }
                if (amount != 3)
                {
                    amount++;
                    latitude = result;
                    MessageBox.Show("input submited" + result);
                    MyTextBox2.Clear();
                }

            }
            else
            {
                MessageBox.Show("wrong input!!!!");
                MyTextBox2.Clear();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }

}
