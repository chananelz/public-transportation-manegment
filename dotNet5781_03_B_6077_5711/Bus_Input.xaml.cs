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
using dotNet_5781_02_6077_5711;
using System.Windows.Threading;

namespace dotNet5781_03_B_6077_5711
{
    /// <summary>
    /// Interaction logic for Bus_Input.xaml
    /// </summary>
    public partial class Bus_Input : Page
    {
        bool input_0 = false;
        bool input_1 = false;
        bool input_2 = false;
        bool input_3 = false;
        bool input_4 = false;
        bool input_5 = false;
        bool input_6 = false;

        int amount = 0;
        BackgroundWorker worker;
        SUPER_BUS inputBus = new SUPER_BUS();
        /// <summary>
        /// get a bus from the user
        /// </summary>
        public Bus_Input()
        {
            InitializeComponent();
            ProgressBar();

        }

        /// <summary>
        /// This function initializes the control called - ProgressBar.
        /// </summary>
        public void ProgressBar()
        {
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWor;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            if (worker.IsBusy != true)
                worker.RunWorkerAsync(12);
        }




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
                int length = (int)e.Argument;

                while (amount != 7)
                {
                    System.Threading.Thread.Sleep(500);
                    worker.ReportProgress(amount * 200 / (length + 1));
                }
            }
        }

        /// <summary>
        /// This function is responsible for the changes derived from the control progress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            int progress = e.ProgressPercentage;

            resultLabel.Content = (progress + "%");
            resultProgressBar.Value = progress;
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
                MessageBox.Show("work cancelled");
            }

            input_0 = false;
            input_1 = false;
            input_2 = false;
            input_3 = false;
            input_4 = false;
            input_5 = false;
            input_6 = false;
            MyTextBox0.Document.Blocks.Clear();
            MyTextBox1.Document.Blocks.Clear();
            MyTextBox2.Document.Blocks.Clear();
            MyTextBox3.Document.Blocks.Clear();
            MyTextBox4.Document.Blocks.Clear();
            MyTextBox5.Document.Blocks.Clear();
            MyTextBox6.Document.Blocks.Clear();
            resultProgressBar.Value = 0;
            resultLabel.Content = (0 + "%");
            amount = 0;
            Uri uri = new Uri("valid_Bus_List.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);

            worker.RunWorkerAsync(12);
            return;
        }

        /// <summary>
        ///  Get license number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">the event argument</param>
        private void MyTextBox_TextChanged_0(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox0.Document.ContentStart, MyTextBox0.Document.ContentEnd);
            if (textRange.Text.Length >= 3 && textRange.Text[textRange.Text.Length - 3] == '\n')
            {
                try
                {
                    Button_Click_0(sender, e);
                }
                catch (SuperBusException exception)
                {
                    MessageBox.Show(exception.Message);

                }

            }
        }
        /// <summary>
        /// Get year start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">the event argument</param>
        private void MyTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox1.Document.ContentStart, MyTextBox1.Document.ContentEnd);
            if (textRange.Text.Length >= 3 && textRange.Text[textRange.Text.Length - 3] == '\n')
            {
                try
                {
                    Button_Click_1(sender, e);
                }
                catch (SuperBusException exception)
                {
                    MessageBox.Show(exception.Message);

                }
            }
        }
        /// <summary>
        /// Get the sumTravel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">the event argument</param>
        private void MyTextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox2.Document.ContentStart, MyTextBox2.Document.ContentEnd);
            if (textRange.Text.Length >= 3 && textRange.Text[textRange.Text.Length - 3] == '\n')
            {
                try
                {
                    Button_Click_2(sender, e);
                }
                catch (SuperBusException exception)
                {
                    MessageBox.Show(exception.Message);

                }

            }
        }
        /// <summary>
        /// Get the last treatment day
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">the event argument</param>
        private void MyTextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox3.Document.ContentStart, MyTextBox3.Document.ContentEnd);
            if (textRange.Text.Length >= 3 && textRange.Text[textRange.Text.Length - 3] == '\n')
            {
                try
                {
                    Button_Click_3(sender, e);
                }
                catch (SuperBusException exception)
                {
                    MessageBox.Show(exception.Message);

                }
                catch (ArgumentOutOfRangeException exception)
                {
                    MyTextBox3.Document.Blocks.Clear();
                    MessageBox.Show("OutOfRange");
                }
            }
        }
        /// <summary>
        /// Get the sum travel since treatment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">the event argument</param>
        private void MyTextBox_TextChanged_4(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox4.Document.ContentStart, MyTextBox4.Document.ContentEnd);
            if (textRange.Text.Length >= 3 && textRange.Text[textRange.Text.Length - 3] == '\n')
            {
                try
                {
                    Button_Click_4(sender, e);
                }
                catch (SuperBusException exception)
                {
                    MessageBox.Show(exception.Message);

                }
            }
        }
        /// <summary>
        /// Get the fuel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">the event argument</param>
        private void MyTextBox_TextChanged_5(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox5.Document.ContentStart, MyTextBox5.Document.ContentEnd);
            if (textRange.Text.Length >= 3 && textRange.Text[textRange.Text.Length - 3] == '\n')
            {
                try
                {
                    Button_Click_5(sender, e);
                }
                catch (SuperBusException exception)
                {
                    MessageBox.Show(exception.Message);

                }
            }
        }
        /// <summary>
        ///ProgressBar of the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }


        /// <summary>
        /// submit for lisence number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">the event argument</param>
        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox0.Document.ContentStart, MyTextBox0.Document.ContentEnd);
            int result = 0;
            if (int.TryParse(textRange.Text, out result) && (result >= 1000000 && result < 10000000 && inputBus.m_yearStart <= 2018) || result >= 10000000 && result < 100000000 && (inputBus.m_yearStart > 2018 || inputBus.m_yearStart == 0))
            {
                if (!input_0)
                {
                    input_0 = true;
                    amount++;
                    inputBus.m_licenseNum = result;
                    if (amount != 6)
                        MessageBox.Show("input submited  " + result + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else

            {
                // MessageBox.Show("wrong input!!!!");
                throw new SuperBusException("wrong input!!!!");
            }
        }
        /// <summary>
        /// submit for year start 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">the event argument</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox1.Document.ContentStart, MyTextBox1.Document.ContentEnd);
            int result = 0;
            if (int.TryParse(textRange.Text, out result) && (result > 2018 && (inputBus.m_licenseNum == -1 || (inputBus.m_licenseNum >= 10000000 && inputBus.m_licenseNum < 100000000)) || (result <= 2018 && (inputBus.m_licenseNum == -1 || (inputBus.m_licenseNum >= 1000000 && inputBus.m_licenseNum < 10000000)))))
            {
                if (!input_1)
                {
                    input_1 = true;
                    amount++;
                    inputBus.m_yearStart = result;
                    if (amount != 6)
                        MessageBox.Show("input submited  " + result + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                throw new SuperBusException("wrong input!!!!");
            }
        }

        /// <summary>
        ///  Get the sumTravel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">the event argument</param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox2.Document.ContentStart, MyTextBox2.Document.ContentEnd);
            float result = 0;
            if (float.TryParse(textRange.Text, out result) && result > 0)
            {
                if (!input_2)
                {
                    input_2 = true;
                    amount++;
                    inputBus.m_sum_Tr = result;
                    if (amount != 6)
                        MessageBox.Show("input submited  " + result + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                throw new SuperBusException("wrong input!!!!");
            }
        }
        /// <summary>
        /// date time for last treatment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">the event argument</param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int year;
            int day;
            int month;


            string stInput;
            string stYear;
            string stDay;
            string stMonth;



            stInput = new TextRange(MyTextBox3.Document.ContentStart, MyTextBox3.Document.ContentEnd).Text;
            string[] inputValues = stInput.Split('/');

            if (inputValues.Length != 3)
            {
                throw new SuperBusException("wrong input!!!!");
            }

            stDay = inputValues[0];
            stMonth = inputValues[1];
            stYear = inputValues[2];




            if (int.TryParse(stDay, out day) && int.TryParse(stMonth, out month) && int.TryParse(stYear, out year))
            {
                DateTime temp = new DateTime(year, month, day);
                if (!input_3)
                {
                    input_3 = true;
                    amount++;
                    inputBus.m_time_Treat = temp;



                    if (amount != 6)
                        MessageBox.Show("input submited  " + stInput + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);

                }

            }
            else
            {
                throw new SuperBusException("wrong input!!!!");
            }
        }
        /// <summary>
        /// sum travel since treatment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">the event argument</param>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox4.Document.ContentStart, MyTextBox4.Document.ContentEnd);
            float result = 0;
            if (float.TryParse(textRange.Text, out result) && result > 0)
            {
                if (!input_4)
                {
                    input_4 = true;
                    amount++;
                    inputBus.m_sum_Tr_Treat = result;
                    if (amount != 6)
                        MessageBox.Show("input submited  " + result + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                throw new SuperBusException("wrong input!!!!");
            }
        }
        /// <summary>
        /// fuel submition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">the event argument</param>
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox5.Document.ContentStart, MyTextBox5.Document.ContentEnd);
            float result = 0;
            if (float.TryParse(textRange.Text, out result) && result > 0)
            {
                if (!input_5)
                {
                    input_5 = true;
                    amount++;
                    inputBus.m_fuel = result;
                    if (amount != 6)
                    {
                        MessageBox.Show("input submited  " + result + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                throw new SuperBusException("wrong input!!!!");
            }
        }

        /// <summary>
        /// busline input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox6.Document.ContentStart, MyTextBox6.Document.ContentEnd);
            float result = 0;
            if (float.TryParse(textRange.Text, out result) && result > 0)
            {
                if (!input_6)
                {
                    input_6 = true;
                    amount++;
                    inputBus.m_BusLine = (int)result;
                    if (amount != 6)
                        MessageBox.Show("input submited  " + result + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                throw new SuperBusException("wrong input!!!!");
            }

            List<BusStop> myUniqueStops = new List<BusStop>();
            Program_6077_5711_02.initializeBus((BusRoute)inputBus, MainWindow.M_SUPER_BUS_LIST, myUniqueStops);
            inputBus.m_BusLine = (int)result;
            inputBus.m_direction = "A";
            MainWindow.M_SUPER_BUS_LIST.comprehensiveCollection.Add(inputBus);
            MessageBox.Show(inputBus.m_BusLine + "A" + " is added!");
            inputBus = new SUPER_BUS();
            valid_Bus_List.temp = 0;
        }

        /// <summary>
        /// manege busline input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myTextBox_TextChanged_6(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox6.Document.ContentStart, MyTextBox6.Document.ContentEnd);
            if (textRange.Text.Length >= 3 && textRange.Text[textRange.Text.Length - 3] == '\n')
            {
                try
                {
                    Button_Click_6(sender, e);
                }
                catch (SuperBusException exception)
                {
                    MessageBox.Show(exception.Message);

                }
            }

        }
    }



}
