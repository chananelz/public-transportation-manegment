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
using Microsoft.Maps.MapControl.WPF;


namespace Wpf
{
    /// <summary>
    /// Interaction logic for map2.xaml
    /// </summary>
    public partial class map2 : Window
    {
        BLApi.IBL bl;
        long lineNumber;

        public map2(long lineNumberInput)
        {
            InitializeComponent();
            lineNumber = lineNumberInput;
            bl = BLApi.Factory.GetBL("1");
            addNewPolyline();
        }
        void addNewPolyline()
        {
            MapPolyline polyline = new MapPolyline();
            polyline.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
            polyline.StrokeThickness = 5;
            polyline.Opacity = 0.2;
            polyline.Locations = new LocationCollection() ;
            foreach (BO.Stop stop in bl.GetAllStopsByLineNumber(lineNumber))
            {

                Location pinLocation = new Location();
                pinLocation.Latitude = stop.Latitude;
                pinLocation.Longitude = stop.Longitude;

                Pushpin pin = new Pushpin();
                pin.Location = pinLocation;

                myMap.Children.Add(pin);
                polyline.Locations.Add(pin.Location);
            }

            myMap.Children.Add(polyline);
        }
    }
}
