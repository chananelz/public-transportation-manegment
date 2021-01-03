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
            bl = BLApi.Factory.GetBL("1");
            StopListComboBox.ItemsSource = bl.GetAllStops().ToList();
            StopListListBox.ItemsSource = stopListInput;
        }





 


        //private void MyTextBox0_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Return)
        //    {
        //        try
        //        {
        //            Number_Click(sender, e);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);

        //        }
        //    }
        //}
        private void MyTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
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



     

       

        //private void Number_Click(object sender, RoutedEventArgs e)
        //{
        //    string textRange = MyTextBox0.Text;
        //    long result = 0;
        //    if (long.TryParse(textRange, out result) && result > 0)
        //    {
        //        number = result;
        //        try
        //        {
        //            bl.UpdateLineNumber(result, managingLine.Id);  
        //            MessageBox.Show("input submited   " + result+ "  click on X to exit");
        //            foreach (Window w in Application.Current.Windows)
        //            {
        //                if (w.Name == "PresentationLines1")
        //                {
        //                    w.Close();
        //                }
        //            }
        //            new PresentationLines().Show();
        //            this.Topmost = true;

        //            MyTextBox0.Clear();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("wrong input!!!!");
        //        MyTextBox0.Clear();
        //    }
        //}
        private void Area_Click(object sender, RoutedEventArgs e)
        {
            string textRange = MyTextBox1.Text;
            area = textRange;
            try
            {
                bl.UpdateLineArea(area, managingLine.Id);
                MessageBox.Show("input submited" + area +"  click on X to exit");
                MyTextBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MyTextBox1.Clear();
            }
        }
        private void StopList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (stopListInput.Count == 0)
                {
                    MessageBox.Show("please add at least one stop");
                    return;
                }
                bl.UpdateLineStations(stopListInput, managingLine.Id);
                
                MessageBox.Show("input updated successfully!"+  "  click on X to exit");
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
            new PresentationLines().Show();
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
