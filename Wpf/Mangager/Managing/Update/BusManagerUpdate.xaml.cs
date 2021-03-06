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
    /// Interaction logic for BusManager.xaml
    /// </summary>
    public partial class BusManager : Window
    {
       
        public BO.Bus managingBus;

        float kM;
        float fuel;
        int statusInput;

        BLApi.IBL bl;
        BLImp.Validator valid = new Validator();


        /// <summary>
        /// Initializes the current window in all existing objects 
        /// </summary>
        public BusManager(BO.Bus bus)
        {
            InitializeComponent();
            managingBus = new BO.Bus();
            managingBus = bus;
            bl = BLApi.Factory.GetBL("1");
        }





        /// <summary>
        /// This function is responsible for the process of receiving and checking the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyTextBox_TextChanged_0(object sender, TextChangedEventArgs e)
        { }

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
                    Travel_Update_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Information);

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
                    Fuel_Update_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Information);

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
                    Status_Update_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
        }

        /// <summary>
        /// This function is responsible for the process of receiving and checking the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        { }


        /// <summary>
        /// This function is responsible for the process of receiving and checking the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyTextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
           
        }

        /// <summary>
        /// This function is responsible for the process of receiving and checking the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Travel_Update_Click(object sender, RoutedEventArgs e)
        {
            string textRange = MyTextBox0.Text;
            float result = 0;
            if (float.TryParse(textRange, out result))
            {
                kM = result;
                try
                {
                    bl.UpdateBusKM(kM, managingBus.LicenseNumber);
                    MessageBox.Show("input submited  " + result + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);

                    MyTextBox0.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Information);
                    MyTextBox0.Clear();
                }
            }
            else
            {
                MessageBox.Show("wrong input!!!!", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                MyTextBox1.Clear();
            }
        }

        /// <summary>
        /// This function is responsible for the process of receiving and checking the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Fuel_Update_Click(object sender, RoutedEventArgs e)
        {
            string textRange = MyTextBox1.Text;
            float result = 0;
            if (float.TryParse(textRange, out result))
            {
                fuel = result;
                try
                {
                    bl.UpdateBusFuel(fuel, managingBus.LicenseNumber);
                    MessageBox.Show("input submited  " + result + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);

                    MyTextBox1.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Information);
                    MyTextBox1.Clear();
                }

            }
            else
            {
                MessageBox.Show("wrong input!!!!", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                MyTextBox1.Clear();
            }
        }

        /// <summary>
        /// This function is responsible for the process of receiving and checking the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Status_Update_Click(object sender, RoutedEventArgs e)
        {
            string textRange = MyTextBox2.Text;
            int result = 0;
            if (int.TryParse(textRange, out result))
            {
                statusInput = result;
                try
                {
                    valid.GoodPositiveStatus(result);
                }
                catch (BO.BOBusException)
                {
                    MessageBox.Show("Wrong status format" + "\n" + "-  Click: 0 for a traveling,\n-  Click:  1 for a ready for drive, \n-  Click: 2 for a treating,  \n - Click: 3 for a refuling", " Operation Failure ", MessageBoxButton.OK, MessageBoxImage.Error);

                    MyTextBox2.Clear();
                    return;
                }
                try
                {
                    bl.UpdateBusStatus(statusInput, managingBus.LicenseNumber);
                    MessageBox.Show("input submited  " + result + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);

                    MyTextBox2.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Information);
                    MyTextBox2.Clear();
                }


            }
            else
            {
                MessageBox.Show("wrong input!!!!", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                MyTextBox2.Clear();
            }
        }

        /// <summary>
        /// This function is responsible for the process of receiving and checking the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window w in Application.Current.Windows)
            {
                if (w.Name == "PresentatinBuses")
                {
                    w.Close();
                }
            }
            this.Close();
            new PresentationBusses("DRIVER").Show();
        }

        /// <summary>
        /// This function is responsible for the process of receiving and checking the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" status format" + "\n" + "-  Click: 0 for a traveling,\n-  Click:  1 for a ready for drive, \n-  Click: 2 for a treating,  \n - Click: 3 for a refuling", " Information ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// This function is responsible for the process of receiving and checking the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Info_Click2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Enter a number between 0-1200 that indicates the amount of fuel", " Information ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// This function is responsible for the process of receiving and checking the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Info_Click3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Enter a number above 0 that indicates the amount of kilometers traveled by the bus", " Information ", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
