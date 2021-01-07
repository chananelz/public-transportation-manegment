﻿using System;
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

        /// <summary>
        /// Initializes the current window in all existing objects 
        /// </summary>
        public StopMangaer(BO.Stop stop)
        {
            InitializeComponent();
            managingStop = new BO.Stop();
            managingStop = stop;
            bl = BLApi.Factory.GetBL("1");
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
                    Name_Click(sender, e);
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
                    Longitude_Click(sender, e);
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
                    Latitude_Click(sender, e);
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
        private void Name_Click(object sender, RoutedEventArgs e)
        {
            string textRange = MyTextBox0.Text;
          
            name = textRange;
            try
            {
                bl.UpdateStopName(name, managingStop.StopCode);
                MessageBox.Show("input submited" + textRange + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);

                MyTextBox0.Clear();
            }
            catch (BO.BODOStopBadIdException ex)
            {
                MessageBox.Show(ex.Message , "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                MyTextBox0.Clear();
                return;
            }
        }

        /// <summary>
        /// This function is responsible for the process of receiving and checking the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Longitude_Click(object sender, RoutedEventArgs e)
        {
            string textRange = MyTextBox1.Text;
            double result = 0;
            if (double.TryParse(textRange, out result))
            {
             
                longitude = result;
                try
                {
                    bl.UpdateStopLongitude(result, managingStop.StopCode);
                    MessageBox.Show("input submited" + result + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);

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
                MessageBox.Show("wrong input!!!!", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                MyTextBox1.Clear();
            }
        }

        /// <summary>
        /// This function is responsible for the process of receiving and checking the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    MessageBox.Show("input submited" + result + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);
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
                if (w.Name == "PresentationStops")
                {
                    w.Close();
                }
            }
            new PresentationStops().Show();

            this.Close();
        }
    }
}
