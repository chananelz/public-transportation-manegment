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

namespace Wpf.Mangager.Managing
{
    /// <summary>
    /// Interaction logic for StopMangaer.xaml
    /// </summary>
    public partial class StopMangaer : Window
    {
        

        string name;
        double longitude;
        double latitude;

        BO.Stop managingStop;

        BLApi.IBL bl;

        public StopMangaer(BO.Stop stop)
        {
            InitializeComponent();
            managingStop = new BO.Stop();
            managingStop = stop;
            bl = BLApi.Factory.GetBL("1");

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
            string textRange = MyTextBox0.Text;
            name = textRange;
            try
            {
                bl.UpdateStopName(name, managingStop.StopCode);
                MessageBox.Show("input submited" + textRange);
                MyTextBox0.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MyTextBox0.Clear();
            }
        }
       
        private void Longitude_Click(object sender, RoutedEventArgs e)
        {
            string textRange = MyTextBox1.Text;
            double result = 0;
            if (double.TryParse(textRange, out result) && result > 0)
            {
                longitude = result;
                try
                {
                    bl.UpdateStopLongitude(result, managingStop.StopCode);
                    MessageBox.Show("input submited" + result);
                    MyTextBox1.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MyTextBox1.Clear();
                }
            }
            else
            {
                MessageBox.Show("wrong input!!!!");
                MyTextBox2.Clear();
            }
        }
        private void Latitude_Click(object sender, RoutedEventArgs e)
        {
            string textRange = MyTextBox2.Text;
            double result = 0;
            if (double.TryParse(textRange, out result) && result > 0)
            {
                latitude = result;
                try
                {
                    bl.UpdateStopLatitude(result, managingStop.StopCode);
                    MessageBox.Show("input submited" + result);
                    MyTextBox2.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
