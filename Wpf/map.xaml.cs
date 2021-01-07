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
using System.Windows.Controls;
using Microsoft.Maps.MapControl.WPF;


namespace Wpf
{
    /// <summary>
    /// Interaction logic for map.xaml
    /// </summary>
    public partial class map : Window
    {
        double longitude;
        double latitude;

        /// <summary>
        /// Initializes the current window in all existing objects 
        /// </summary>
        public map(double longitudeInput, double latitudeInput)
        {
            InitializeComponent();
            myMap.Focus();
            //MapLayer.SetPosition()
            //Set map to Aerial mode with labels
            longitude = longitudeInput;
            latitude = latitudeInput;
            showLoc();

        }

        /// <summary>
        /// show Location
        /// </summary>
        private void showLoc()
        {

            Location pinLocation = new Location();
            pinLocation.Latitude = latitude;
            pinLocation.Longitude = longitude;

            Pushpin pin = new Pushpin();
            pin.Location = pinLocation;

            myMap.Children.Add(pin);
        }

    }
}
