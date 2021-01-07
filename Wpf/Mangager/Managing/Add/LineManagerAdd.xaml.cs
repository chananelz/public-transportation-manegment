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
using Wpf.Mangager.Information;
using BLImp;


namespace Wpf.Mangager.Managing.Add
{
    /// <summary>
    /// Interaction logic for LineManagerAdd.xaml
    /// </summary>
    public partial class LineManagerAdd : Window
    {


       
        bool input0 = false;
        bool input1 = false;
        bool input2 = false;

        BLImp.Validator valid = new Validator();


        long number;
        string area;
        List<BO.Stop> stopListInput = new List<BO.Stop>();


        int amount = 0;
        BackgroundWorker worker;

        BLApi.IBL bl;

        public BO.Stop tempStop;


        /// <summary>
        /// constractor of the window
        /// </summary>
        public LineManagerAdd()
        {
            InitializeComponent();
            bl = BLApi.Factory.GetBL("1");
            ProgressBar();
            StopListComboBox.ItemsSource = bl.GetAllStops().ToList();
            StopListListBox.ItemsSource = stopListInput;
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
                worker.RunWorkerAsync(3);
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

                while (amount != 3)
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
                bl.CreateLine(number, area, stopListInput);
                MessageBoxResult res = MessageBox.Show("Would you like to add another bus in the opposite direction??", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.No) ;

                else
                {
                    bl.CreateOppositeDirectionLine(number, area, stopListInput);
                }
            }
            catch (BO.BODOBadLineIdException ex)
            {
                MessageBox.Show(ex.Message  , "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                worker.RunWorkerAsync(3);
                amount = 0;
                return;
            }
            MessageBox.Show("line added!", "input", MessageBoxButton.OK, MessageBoxImage.Information);
            foreach (Window w in Application.Current.Windows)
            {
                if (w.Name == "PresentationLines1")
                {
                    w.Close();
                }
            }

            new PresentationLines().Show();
            this.Close();
        }





        /// <summary>
        /// Defines actions to be performed when the user enters input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyTextBox0_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                try
                {
                    Number_Click(sender, e);
                }
                catch
                {
                    MessageBox.Show("something wrong happened please try again", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Defines actions to be performed when the user enters input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                try
                {
                    Area_Click(sender, e);
                }
                catch
                {
                    MessageBox.Show("something wrong happened please try again", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Defines actions to be performed when the user enters input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                try
                {
                    StopList_Click(sender, e);
                }
                catch
                {
                    MessageBox.Show("something wrong happened please try again", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        /// <summary>
        /// Defines actions to be performed when the user enters input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            string textRange = MyTextBox0.Text;
            long result = 0;
            if (long.TryParse(textRange, out result))
            {
                try
                {
                    valid.GoodLinePositiveLong(result);
                }
                catch (BO.BOBadLineIdException ex)
                {
                    MessageBox.Show("Wrong LicenseNumber format : " + ex.Message , "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                    MyTextBox0.Clear();
                    return;
                }
                
                if (amount != 3)
                {

                    number = result;
                    MessageBox.Show("input submited  " + textRange + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);
                    NumberLabel.Content = result;
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
                MessageBox.Show("wrong input!!!!", "input", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Area_Click(object sender, RoutedEventArgs e)
        {
            string textRange = MyTextBox1.Text;
           
            if (amount != 3)
            {

                area = textRange;
                
                MessageBox.Show("input submited  " + textRange + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);

                AreaLabel.Content = area;
                MyTextBox1.Clear();
                if (!input1)
                {
                    input1 = true;
                    amount++;

                }
            }
            else
            {
                MessageBox.Show("wrong input!!!!", "input", MessageBoxButton.OK, MessageBoxImage.Information);
               
            }

        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopList_Click(object sender, RoutedEventArgs e)
        {
           
            if (amount != 3)
            {
                if (stopListInput.Count == 0)
                {
                    MessageBox.Show("Please select at least one station", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("input submited  "  + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (!input2)
                    {
                        input2 = true;
                        amount++;
                    }
                }
            }
            else
            {
                MessageBox.Show("wrong input!!!!", "input", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }


        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lineList_SelectionChanged(object sender, RoutedEventArgs e)
        {
            new OptionsForDriver().Show();
            this.Close();
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new StopManagerAdd().Show();
            this.Close();
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempStop = (BO.Stop)a.DataContext;
            stopListInput.Remove(tempStop);
            StopListListBox.Items.Refresh();
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BO.Stop tempStop = (BO.Stop)StopListComboBox.SelectedItem;
            stopListInput.Add(tempStop);
            StopListListBox.Items.Refresh();
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick(object sender, RoutedEventArgs e)
        {

        }


        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lineList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void information_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempStop = (BO.Stop)a.DataContext;
            new StopInfo(tempStop).Show();
            this.Close();
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempStop = (BO.Stop)a.DataContext;
            new StopMangaer(tempStop).Show();
            this.Close();
        }
     
    }
}