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
using BLImp;
//aa


namespace Wpf.Mangager.Managing.Add.myImages
{
    /// <summary>
    /// Interaction logic for BusManagerAdd.xaml
    /// </summary>
    public partial class BusManagerAdd : Window
    {
       
        bool input0 = false;
        bool input1 = false;
        bool input2 = false;
        bool input3 = false;
        bool input4 = false;
        BLImp.Validator valid = new Validator();


        long licenseNumber;
        DateTime licenseDate;
        float kM;
        float fuel;
        int statusInput;

        int amount = 0;
        BackgroundWorker worker;

        BLApi.IBL bl;

        /// <summary>
        /// Initializes the current window in all existing objects 
        /// </summary>
        public BusManagerAdd()
        {
            InitializeComponent();
            ProgressBar();



            bl = BLApi.Factory.GetBL("1");
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
                worker.RunWorkerAsync(5);
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

                while (amount != 5)
                {
                    System.Threading.Thread.Sleep(500);
                    worker.ReportProgress(amount * 100 / (length));
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
                MessageBox.Show("work cancelled", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }

          

            try
            {
                bl.GetBus(licenseNumber);
            }
            catch(BO.BODOBadBusIdException ex) 
            {
                if (ex.Message == "bus is not valid!!")
                {
                    MessageBoxResult res = MessageBox.Show("LicenseNumber already exists Would you like to validate it??", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (res == MessageBoxResult.No) 
                        return;
                    else
                        bl.CreateBus(licenseNumber, licenseDate, kM, fuel, statusInput);

                }
                else
                {
                    try
                    {
                        bl.CreateBus(licenseNumber, licenseDate, kM, fuel, statusInput);
                    }
                    catch(BO.BODOBadBusIdException ex1)
                    {
                        MessageBox.Show(ex1.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                        worker.RunWorkerAsync(5);
                        return;
                    }
                }
            }

            //catch (BO.BODOBadBusIdException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    new PresentationBusses().Show();
            //    this.Close();
            //    return;
            //}
            MessageBox.Show("bus added!");
            foreach (Window w in Application.Current.Windows)
            {
                if (w.Name == "PresentatinBuses")
                {
                    w.Close();
                }
            }
            new PresentationBusses("DRIVER").Show();

            this.Close();
        }






        /// <summary>
        /// This function is responsible for the process of receiving and checking the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyTextBox0_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                try
                {
                    LicenseNumber_Click(sender, e);
                }
                catch 
                {
                    MessageBox.Show("something wrong happened please try again", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               
            }
        }


        /// <summary>
        /// This function is responsible for the process of receiving and checking the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                try
                {
                    LicenseDate_Click(sender, e);
                }
                catch 
                {
                    MessageBox.Show("something wrong happened please try again", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }

        /// <summary>
        /// This function is responsible for the process of receiving and checking the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                try
                {
                    Travel_Click(sender, e);
                }
                catch
                {
                    MessageBox.Show("something wrong happened please try again", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }

        /// <summary>
        /// This function is responsible for the process of receiving and checking the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                try
                {
                    Fuel_Click(sender, e);
                }
                catch 
                {
                    MessageBox.Show("something wrong happened please try again", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }

        /// <summary>
        /// This function is responsible for the process of receiving and checking the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyTextBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                try
                {
                    Status_Click(sender, e);
                }
                catch 
                {
                    MessageBox.Show("something wrong happened please try again", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }





        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LicenseNumber_Click(object sender, RoutedEventArgs e)
        {
            string textRange = MyTextBox0.Text;
            long result = 0;
            if (long.TryParse(textRange, out result))
            {
                try
                {                   
                    valid.GoodPositiveLicenseNumber(result);
                }
                catch (BO.BOBusException)
                {
                    MessageBox.Show("Wrong LicenseNumber format", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                    MyTextBox0.Clear();
                    return;
                }
                try
                {
                    valid.GoodLicenseDigits(result);
                }
                catch (BO.BOBadBusIdException)
                {
                    MessageBox.Show("amount of digits not enough!", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                    MyTextBox0.Clear();
                    return;
                }
                if (input1)
                {
                    try
                    {
                        valid.GoodLicense(result,licenseDate);
                    }
                    catch (BO.BOBadBusIdException)
                    {
                        MessageBox.Show("licesne and date time don't match until 2018 7 digits from then and on 8 digits", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                        MyTextBox0.Clear();
                    }
                }

               
                if (amount != 5)
                {
                    licenseNumber = result;
                    MessageBox.Show("input submited  " + result + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);
                    LicenseNumberLabel.Content = result;
                    MyTextBox0.Clear();
                    if (!input0)
                    {
                        input0 = true;
                        amount++;

                    }
                }
            }
            else
            {
                MessageBox.Show("wrong input!!!", " Operation Failure ", MessageBoxButton.OK, MessageBoxImage.Error);
                MyTextBox0.Clear();
            }
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LicenseDate_Click(object sender, RoutedEventArgs e)
        {

            int year;
            int day;
            int month;


            string stInput;
            string stYear;
            string stDay;
            string stMonth;



            stInput = MyTextBox1.Text;
            string[] inputValues = stInput.Split('/');
            if (inputValues.Length != 3)
            {
                MessageBox.Show("Wrong date format", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                MyTextBox1.Clear();
                return;
            }


            stDay = inputValues[0];
            stMonth = inputValues[1];
            stYear = inputValues[2];

            if (int.TryParse(stDay, out day) && int.TryParse(stMonth, out month) && int.TryParse(stYear, out year))
            {
               
                try
                {
                    valid.GoodTimeformat(day, month, year);
                    licenseDate = new DateTime(year, month, day);
                }
                catch 
                {
                    MessageBox.Show("Wrong date format", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                    MyTextBox1.Clear();
                    return;
                }
                if (input0)
                {
                    try
                    {
                        valid.GoodLicense(licenseNumber,licenseDate);
                    }
                    catch(BO.BOBadBusIdException)
                    {
                        MessageBox.Show("licesne and date time don't match until 2018 7 digits from then and on 8 digits", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                        MyTextBox1.Clear();
                    }
                }
               
                if (amount != 5)
                {
                    DateTime temp = new DateTime(year, month, day);
                    licenseDate = temp;
                   
                    MessageBox.Show("input submited  " + stInput + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);

                    DateTimeLabel.Content = temp;
                    MyTextBox1.Clear();
                    if (!input1)
                    {
                        input1 = true;
                        amount++;

                    }
                }

            }
            else
            {
                MessageBox.Show("wrong input!!!", " Operation Failure ", MessageBoxButton.OK, MessageBoxImage.Error);
                MyTextBox1.Clear();
            }
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Travel_Click(object sender, RoutedEventArgs e)
        {
            string textRange = MyTextBox2.Text;
            float result = 0;
            if (float.TryParse(textRange, out result))
            {
                try
                {
                    valid.GoodPositiveflout(result);
                }
                catch (BO.BOBusException)
                {
                    MessageBox.Show("negative number", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                    MyTextBox2.Clear();
                    return;
                }
                
                if (amount != 5)
                {
                    MessageBox.Show("input submited  " + result + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);
                    KMLabel.Content = result;
                    kM = result;
                    MyTextBox2.Clear();
                    if (!input2)
                    {
                        input2 = true;
                        amount++;

                    }
                }
            }
            else
            {
                MessageBox.Show("wrong input!!!", " Operation Failure ", MessageBoxButton.OK, MessageBoxImage.Error);
                MyTextBox2.Clear();
            }
        }
        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Fuel_Click(object sender, RoutedEventArgs e)
        {
            string textRange = MyTextBox3.Text;
            float result = 0;
            if (float.TryParse(textRange, out result))
            {
                try
                {
                    valid.GoodPositiveflout(result);
                }
                catch (BO.BOBusException ex)
                {
                    MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                    MyTextBox3.Clear();
                    return;
                }
                try
                {
                    valid.GoodFuel(result);
                }
                catch (BO.BOBusException ex)
                {
                    MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                    MyTextBox3.Clear();
                    return;
                }

                if ( amount != 5)
                {
                    fuel = result;
                    MessageBox.Show("input submited  " + result + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);
                    FuelLabel.Content = result;
                    MyTextBox3.Clear();
                    if (!input3)
                    {
                        input3 = true;
                        amount++;

                    }
                }
            }
            else
            {
                MessageBox.Show("wrong input!!!", " Operation Failure ", MessageBoxButton.OK, MessageBoxImage.Error);
                MyTextBox3.Clear();
            }
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Status_Click(object sender, RoutedEventArgs e)
        {
            string textRange = MyTextBox4.Text;
            int result = 0;
            if (int.TryParse(textRange, out result))
            {
                try
                {
                    valid.GoodPositiveStatus(result);
                }
                catch (BO.BOBusException)
                {
                    MessageBox.Show("Wrong status format" + "\n" + "-  Click: 0 for a traveling,\n-  Click:  1 for a ready for drive, \n-  Click: 2 for a treating,  \n - Click: 3 for a refuling", " Operation Failure " , MessageBoxButton.OK, MessageBoxImage.Error);
                    MyTextBox4.Clear();
                    return;
                }
                
                if (amount != 5)
                {
                    statusInput = result;
                    MessageBox.Show("input submited  " + result + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);
                    StatusLabel.Content = result; 
                    MyTextBox4.Clear();
                    if (!input4)
                    {
                        input4 = true;
                        amount++;

                    }
                }
            }
            else
            {
                MessageBox.Show("wrong input!!!" , " Operation Failure ", MessageBoxButton.OK, MessageBoxImage.Error);
                MyTextBox4.Clear();
            }
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" status format" + "\n" + "-  Click: 0 for a traveling,\n-  Click:  1 for a ready for drive, \n-  Click: 2 for a treating,  \n - Click: 3 for a refuling", " Information ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Info_Click2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Enter a number between 0-1200 that indicates the amount of fuel", " Information ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Info_Click3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Enter a number above 0 that indicates the amount of kilometers traveled by the bus", " Information ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Info_Click4(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Enter day month year with '/' between the input ", " Information ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Info_Click5(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("If the year of license date is after 2018 enter 8-digit number \n else enter 7-digit number ", " Information ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //private void Calendar_SelectedDatesChanged(object sender, RoutedEventArgs e)
        //{
        //    var calendar = sender as Calendar;
        //    if (calendar.SelectedDate.HasValue)
        //    {

        //        DateTime date = calendar.SelectedDate.Value;
        //        this.Title = date.ToShortDateString();
        //    }

        //    DateTime myDate = MyCalendar.SelectedDate.Value;

        //    int year = myDate.Year;
        //    int day = myDate.Day;
        //    int month = myDate.Month;

        //    licenseDate = new DateTime(year, month, day);
        //    try
        //    {
        //        valid.GoodLicense(licenseNumber, licenseDate);
        //    }
        //    catch (BO.BOBadBusIdException)
        //    {
        //        MessageBox.Show("licesne and date time don't match until 2018 7 digits from then and on 8 digits", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
        //        MyTextBox1.Clear();
        //    }
        //    if (amount != 5)
        //    {
        //        DateTime temp = new DateTime(year, month, day);
        //        licenseDate = temp;

        //        MessageBox.Show("input submited  " + myDate.ToString() + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);

        //        if (!input1)
        //        {
        //            input1 = true;
        //            amount++;

        //        }
        //    }

        //}
     
    }
}



 