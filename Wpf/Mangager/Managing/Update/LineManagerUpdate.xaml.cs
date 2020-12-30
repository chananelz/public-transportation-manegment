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
using Wpf.Mangager.Managing.Add;
using Wpf.Mangager.Information;

namespace Wpf.Mangager.Managing
{
    /// <summary>
    /// Interaction logic for LineManager.xaml
    /// </summary>
    public partial class LineManager : Window
    {
        private double place = 0;
        DispatcherTimer gameTimer = new DispatcherTimer();

        BLApi.IBL bl;

        long number;
        string area;
        List<BO.Stop> stopListInput = new List<BO.Stop>();

        BO.Line managingLine;
        BO.Stop tempStop;

        public LineManager(BO.Line line)
        {
            InitializeComponent();
            managingLine = new BO.Line();
            managingLine = line;
            busFunc();
            bl = BLApi.Factory.GetBL("1");
            StopListComboBox.ItemsSource = bl.GetAllStops().ToList();
            StopListListBox.ItemsSource = stopListInput;
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
            if (long.TryParse(textRange.Text, out result) && result > 0)
            {
                number = result;
                try
                {
                    bl.UpdateLineNumber(result, managingLine.Id);  
                    MessageBox.Show("input submited" + result);
                    MyTextBox0.Document.Blocks.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
                MyTextBox0.Document.Blocks.Clear();
            }
        }
        private void Area_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(MyTextBox1.Document.ContentStart, MyTextBox1.Document.ContentEnd);
            area = textRange.Text;
            try
            {
                bl.UpdateLineArea(area, managingLine.Id);
                MessageBox.Show("input submited" + area);
                MyTextBox1.Document.Blocks.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MyTextBox1.Document.Blocks.Clear();
            }
        }
        private void StopList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.UpdateLineStations(stopListInput, managingLine.Id);
                MessageBox.Show("input updated successfully!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void lineList_SelectionChanged(object sender, RoutedEventArgs e)
        {
            new OptionsForDriver().Show();
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
