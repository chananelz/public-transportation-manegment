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


namespace Wpf.Mangager.Managing.Add
{
    /// <summary>
    /// Interaction logic for LineManagerAdd.xaml
    /// </summary>
    public partial class LineManagerAdd : Window
    {


        private double place = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();
        bool input0 = false;
        bool input1 = false;
        bool input2 = false;


        long number;
        string area;
        List<BO.Stop> stopListInput = new List<BO.Stop>();


        int amount = 0;
        BackgroundWorker worker;

        BLApi.IBL bl;

        public BO.Stop tempStop;



        public LineManagerAdd()
        {
            InitializeComponent();
            busFunc();
            bl = BLApi.Factory.GetBL("1");
            ProgressBar();
            StopListComboBox.ItemsSource = bl.GetAllStops().ToList();
            StopListListBox.ItemsSource = stopListInput;
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
                    worker.ReportProgress(amount * 100 / (length));
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
                bl.CreateLine(number, area, stopListInput);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("line added!");

            new PresentationLines().Show();
            this.Close();
        }

        private void busFunc()
        {
            place = movingBus.Margin.Left;
            LineManagerUpdate.Focus();
            gameTimer.Tick += gameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(0.5);
            gameTimer.Start();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            if (movingBus.Margin.Left >= -600)
                movingBus.Margin = new Thickness(movingBus.Margin.Left - 8, movingBus.Margin.Top, movingBus.Margin.Right, movingBus.Margin.Bottom);
            else
                movingBus.Margin = new Thickness(place, movingBus.Margin.Top, movingBus.Margin.Right, movingBus.Margin.Bottom);
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            new FirstPage().Show();
            this.Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            new PresentationLines().Show();
            this.Close();
        }


        private void MyTextBox_TextChanged_0(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox0.Document.ContentStart, MyTextBox0.Document.ContentEnd);
            if (textRange.Text.Length >= 3 && textRange.Text[textRange.Text.Length - 3] == '\n')
            {
                try
                {
                    Number_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void MyTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox1.Document.ContentStart, MyTextBox1.Document.ContentEnd);
            if (textRange.Text.Length >= 3 && textRange.Text[textRange.Text.Length - 3] == '\n')
            {
                try
                {
                    Area_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }


        private void Number_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox0.Document.ContentStart, MyTextBox0.Document.ContentEnd);
            long result = 0;
            if (long.TryParse(textRange.Text, out result))
            {
                if (!input0)
                {
                    input0 = true;

                }
                if (amount != 3)
                {
                    amount++;

                    number = result;
                    MessageBox.Show("input submited" + result);
                    MyTextBox0.Document.Blocks.Clear();
                }
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
            }
        }
        private void Area_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox1.Document.ContentStart, MyTextBox1.Document.ContentEnd);
            if (!input1)
            {
                input1 = true;

            }
            if (amount != 3)
            {
                amount++;

                area = textRange.Text;
                MessageBox.Show("input submited" + textRange.Text);
                MyTextBox1.Document.Blocks.Clear();
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
            }

        }
        private void StopList_Click(object sender, RoutedEventArgs e)
        {
            if (!input2)
            {
                input2 = true;
            }
            if (amount != 3)
            {
                amount++;
                MessageBox.Show("input submited");
                MyTextBox1.Document.Blocks.Clear();
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
            }

        }


        private void lineList_SelectionChanged(object sender, RoutedEventArgs e)
        {
            new Options().Show();
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new StopManagerAdd().Show();
            this.Close();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempStop = (BO.Stop)a.DataContext;
            stopListInput.Remove(tempStop);
            StopListListBox.Items.Refresh();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void StopList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BO.Stop tempStop = (BO.Stop)StopListComboBox.SelectedItem;
            stopListInput.Add(tempStop);
            StopListListBox.Items.Refresh();
        }
        private void OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void lineList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void information_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempStop = (BO.Stop)a.DataContext;
            new StopInfo(tempStop).Show();
            this.Close();
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempStop = (BO.Stop)a.DataContext;
            new StopMangaer(tempStop).Show();
            this.Close();
        }
    }
}