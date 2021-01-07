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
using System.Reflection;



namespace Wpf
{
    /// <summary>
    /// Interaction logic for map3.xaml
    /// </summary>
    public partial class map3 : Window
    {


        BLApi.IBL bl;
        long lineNumber;

        /// <summary>
        /// Initializes the current window in all existing objects 
        /// </summary>
        public map3()
        {
            InitializeComponent();

            bl = BLApi.Factory.GetBL("1");
            foreach (string area in bl.GetAllAreas().ToList())
                areaList.Items.Add(area);
            areaList.Items.Add("all areas");
        }
        static string GetColorName(Color col)
        {
            PropertyInfo colorProperty = typeof(Colors).GetProperties()
                .FirstOrDefault(p => Color.AreClose((Color)p.GetValue(null), col));
            return colorProperty != null ? colorProperty.Name : "unnamed color";
        }

        /// <summary>
        /// add new lines on the map
        /// </summary>
        /// <param name="area"></param>
        void addNewPolyline(string area)
        {
            MapPolyline polyline;
            Random r = new Random(DateTime.Now.Millisecond);
            Color[] colorArray = new Color[10]{ System.Windows.Media.Colors.Red, System.Windows.Media.Colors.Green, System.Windows.Media.Colors.Blue
                                                    ,System.Windows.Media.Colors.White,System.Windows.Media.Colors.Black,System.Windows.Media.Colors.Purple
                                                    ,System.Windows.Media.Colors.Orange,System.Windows.Media.Colors.Yellow,System.Windows.Media.Colors.Gray
                                                    ,System.Windows.Media.Colors.Gold };
           
            var a = bl.GetAllLineGroupByArea().ToList();
           
            int j = 0;
            for (int i = 0; i < a.Count(); i++)
            {
                if (area == "all areas" || a[i].First().Area == area)
                {
                    Color colorPolyLine = new Color();
                    Color colorPin = new Color();
                    colorPin = colorArray[i % 10];
                    foreach (BO.Line line in a[i].ToList())
                    {
                        polyline = new MapPolyline();
                        polyline.StrokeThickness = 5;
                        polyline.Opacity = 1;
                        colorPolyLine = colorArray[j % 10];
                        polyline.Stroke = new System.Windows.Media.SolidColorBrush(colorPolyLine);

                        polyline.Locations = new LocationCollection();

                        foreach (BO.Stop stop in bl.GetAllStopsByLineNumber(line.Number))
                        {


                            Location pinLocation = new Location();
                            pinLocation.Latitude = stop.Latitude;
                            pinLocation.Longitude = stop.Longitude;

                            Pushpin pin = new Pushpin();
                            pin.Background = new SolidColorBrush(colorPin);
                            pin.Location = pinLocation;

                            myMap.Children.Add(pin);
                            polyline.Locations.Add(pin.Location);
                        }
                        myMap.Children.Add(polyline);
                        j++;
                    }
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Area_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            myMap.Children.Clear();
            addNewPolyline((string)areaList.SelectedItem);
        }
    }
}
