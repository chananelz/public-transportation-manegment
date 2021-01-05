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
using BLImp;

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
        BLImp.Validator valid = new Validator();


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
                catch 
                {
                    MessageBox.Show("something wrong happened please try again", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

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
                catch 
                {
                    MessageBox.Show("something wrong happened please try again", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

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
                catch 
                {
                    MessageBox.Show("something wrong happened please try again", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }




     
        private void Name_Click(object sender, RoutedEventArgs e)
        {
            string textRange = MyTextBox0.Text;
            //try
            //{
            //    BLImp.Validator.GetGoodString(textRange);
            //}
            //catch (ArgumentNullException ex)
            //{
            //    MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}
            name = textRange;
            try
            {
                bl.UpdateStopName(name, managingStop.StopCode);
                MessageBox.Show("input submited" + textRange +  "      to exit click X");
                foreach (Window w in Application.Current.Windows)
                {
                    if (w.Name == "PresentationStops")
                    {
                        w.Close();
                    }
                }
                new PresentationStops().Show();

                this.Close();
                MyTextBox0.Clear();
            }
            catch (BO.BODOStopBadIdException ex)
            {
                MessageBox.Show(ex.Message , "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                MyTextBox0.Clear();
                return;
            }
        }
       
        private void Longitude_Click(object sender, RoutedEventArgs e)
        {
            string textRange = MyTextBox1.Text;
            double result = 0;
            if (double.TryParse(textRange, out result))
            {
                //try
                //{
                //    BLImp.Validator.GetGoodLongitude(result);
                //}
                //catch (ArgumentOutOfRangeException ex)
                //{
                //    MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                //    MyTextBox1.Clear();
                //    return;
                //}
                longitude = result;
                try
                {
                    bl.UpdateStopLongitude(result, managingStop.StopCode);
                    MessageBox.Show("input submited" + result + "   to exit click X");
                    MyTextBox1.Clear();
                }
                catch (BO.BODOStopBadIdException ex)
                {
                    MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                    MyTextBox1.Clear();
                    return;
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
            double result = 0;
            if (double.TryParse(textRange, out result))
            {
                try
                {
                    valid.GetGoodLatitude(result);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                    MyTextBox2.Clear();
                    return;
                }
                latitude = result;
                try
                {
                    bl.UpdateStopLatitude(result, managingStop.StopCode);
                    MessageBox.Show("input submited" + result +"   to exit click X");
                    MyTextBox2.Clear();
                }
                catch (BO.BODOStopBadIdException ex)
                {
                    MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                    MyTextBox1.Clear();
                    return;
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
            new PresentationStops().Show();
            this.Close();
        }
    }
}
