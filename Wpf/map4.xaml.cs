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
using Microsoft.Maps.MapControl.WPF.Design;
using System.Xml;
using System.Net;
using System.Xml.XPath;

namespace Wpf
{

    public partial class map4 : Window
    {
        string BingMapsKey = "Jb9C8vgYnBRCqVeUq5be~8bRjVc66rCX4vuQTZkFFkw~An7hiz1GJMcbO7tJM7zejKU_slrteIlKbjgDQskBXFVjchjEQ3x7brCnLqEPw6Pi";
        BO.Stop stop = new BO.Stop();


        /// <summary>
        /// Initializes the current window in all existing objects 
        /// </summary>
        public map4(ref BO.Stop stop)
        {
            InitializeComponent();
        }



        // Geocode an address and return a latitude and longitude
        public XmlDocument Geocode(string addressQuery)
        {
            //Create REST Services geocode request using Locations API
            string geocodeRequest = "http://dev.virtualearth.net/REST/v1/Locations/" + addressQuery + "?o=xml&key=" + BingMapsKey;

            //Make the request and get the response                                          
            XmlDocument geocodeResponse = GetXmlResponse(geocodeRequest);



            return (geocodeResponse);
        }


        // Submit a REST Services or Spatial Data Services request and return the response
        private XmlDocument GetXmlResponse(string requestUrl)
        {
            System.Diagnostics.Trace.WriteLine("Request URL (XML): " + requestUrl);
            HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(String.Format("Server error (HTTP {0}: {1}).",
                    response.StatusCode,
                    response.StatusDescription));
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                return xmlDoc;
            }
        }

        //Search for POI near a point
        private void FindByText(XmlDocument xmlDoc)
        {
            //Get location information from geocode response 

            //Create namespace manager
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("rest", "http://schemas.microsoft.com/search/local/ws/rest/v1");

            //Get all geocode locations in the response 
            XmlNodeList locationElements = xmlDoc.SelectNodes("//rest:Location", nsmgr);

            //Get the geocode location points that are used for display (UsageType=Display)
            XmlNodeList displayGeocodePoints =
                    locationElements[0].SelectNodes(".//rest:GeocodePoint/rest:UsageType[.='Display']/parent::node()", nsmgr);
            string latitude = displayGeocodePoints[0].SelectSingleNode(".//rest:Latitude", nsmgr).InnerText;
            string longitude = displayGeocodePoints[0].SelectSingleNode(".//rest:Longitude", nsmgr).InnerText;
           

            

            //Center the map at the geocoded location and display the results
            myMap.Center = new Location(Convert.ToDouble(latitude), Convert.ToDouble(longitude));
            myMap.ZoomLevel = 20;
            //DisplayResults(nearbyPOI)

        }




        //Add a pushpin with a label to the map
        private void AddPushpinToMap(double latitude, double longitude, string pinLabel)
        {
            Location location = new Location(latitude, longitude);
            Pushpin pushpin = new Pushpin();
            pushpin.Content = pinLabel;
            pushpin.Location = location;
            myMap.Children.Add(pushpin);
        }



        private void MyTextBox0_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                try
                {
                    Search_Click(sender, e);
                }
                catch
                {
                    MessageBox.Show("something wrong happened please try again", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }


        private void MapWithPushpins_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Disables the default mouse double-click action.
            e.Handled = true;

            // Determin the location to place the pushpin at on the map.

            //Get the mouse click coordinates
            Point mousePosition = e.GetPosition(myMap);
            //Convert the mouse coordinates to a locatoin on the map
            Location pinLocation = myMap.ViewportPointToLocation(mousePosition);

            stop.Latitude = pinLocation.Latitude;
            stop.Longitude = pinLocation.Longitude;

        }

        //Search for POI elements when the Search button is clicked
        private void Search_Click(object sender, RoutedEventArgs e)
        {
         


            //Get latitude and longitude coordinates for specified location
            XmlDocument searchResponse = Geocode(SearchNearBy.Text);

            //Find and display points of interest near the specified location
            FindByText(searchResponse);
        }



    }
}