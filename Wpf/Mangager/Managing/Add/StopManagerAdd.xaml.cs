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
using System.ComponentModel;
using BLApi;
using BLImp;
using System.Xml;
using System.Net;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Design;

namespace Wpf.Mangager.Managing.Add
{
    /// <summary>
    /// Interaction logic for StopManagerAdd.xaml
    /// </summary>
    public partial class StopManagerAdd : Window
    {

        bool input0 = false;
        bool input1 = false;
        bool input2 = false;


        int amount = 0;
        BackgroundWorker worker;

        BLImp.Validator valid = new Validator();


        double latitude;
        double longitude;
        string stopName;
        BLApi.IBL bl;
        BO.Stop check = new BO.Stop();




        /// <summary>
        /// constractor of the window
        /// </summary>
        public StopManagerAdd()
        {
            InitializeComponent();
            bl = BLApi.Factory.GetBL("1");

            ProgressBar();

        }

        /// <summary>
        /// This function initializes the control called - ProgressBar.
        /// </summary>
        public void ProgressBar()
        {
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWor;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            if (worker.IsBusy != true)
                worker.RunWorkerAsync(3);

        }




        /// <summary>
        /// This function manages the progress of the ProgressBar control according to the input from the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void Worker_DoWor(object sender, DoWorkEventArgs e)
        {

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                worker.ReportProgress(0);
            }
            else
            {
                int length = (int)e.Argument;

                while (amount != 3)
                {
                    System.Threading.Thread.Sleep(500);
                    worker.ReportProgress(amount * 100 / (length ));
                }
            }
        }

        /// <summary>
        /// This function is responsible for the changes derived from the control progress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            int progress = e.ProgressPercentage;

            resultLabel.Content = (progress + "%");
            resultProgressBar.Value = progress;
        }



        ///<summary>
        /// This function is responsible for the activities that are activated at the end of the process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("work cancelled", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            try
            {
                bl.CreateStop(latitude, longitude, stopName);
            }


           
            catch (BO.BODOStopBadIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                worker.RunWorkerAsync(3);
                return;
            }

          

            MessageBox.Show("stop added!");
            foreach (Window w in Application.Current.Windows)
            {
                if (w.Name == "PresentatinStops1")
                {
                    w.Close();
                }
            }
            new PresentationStops("DRIVER").Show();
            this.Topmost = true;

            this.Close();
        }


        /// <summary>
        /// Defines actions to be performed when the user enters input
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
        /// Defines actions to be performed when the user enters input
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
        /// Defines actions to be performed when the user enters input
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
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Name_Click(object sender, RoutedEventArgs e)
        {


           
            if (!input0 && amount != 3)
            {
               
                string textRange =  MyTextBox0.Text;
                try
                {
                    BLImp.Validator.GetGoodString(textRange);
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                amount++;
                stopName = textRange;
                MessageBox.Show("input submited  " + textRange + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);
                NameLabel.Content = stopName;
                MyTextBox0.Clear();
                if (!input0)
                {
                    input0 = true;
                    amount++;
                }
            }

            else
            {
                MessageBox.Show("wrong input!!!!", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                MyTextBox2.Clear();
            }
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Longitude_Click(object sender, RoutedEventArgs e)
        {
            string textRange = MyTextBox1.Text;
            double result = 0;
            if (double.TryParse(textRange, out result))
            {
                try
                {
                    valid.GetGoodLongitude(result);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                    MyTextBox1.Clear();
                    return;
                }
                
                if (!input1 && amount != 3)
                {
                    amount++;
                    longitude = result;
                    MessageBox.Show("input submited  " + result + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);
                    LongitudeLabel.Content = result;
                    MyTextBox1.Clear();
                    if (!input1)
                    {
                        input1 = true;

                    }
                }

            }
            else
            {
                MessageBox.Show("wrong input!!!!", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                MyTextBox1.Clear();
            }
        }
        

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
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
                    MessageBox.Show(ex.Message , "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                    MyTextBox2.Clear();
                    return;
                }
                
                
                if (!input2 && amount != 3)
                {
                    amount++;
                    latitude = result;
                    MessageBox.Show("input submited  " + result + "      to exit click X", "input", MessageBoxButton.OK, MessageBoxImage.Information);
                    LatitudeLabel.Content = result;
                    MyTextBox2.Clear();
                    if (!input2)
                    {
                        input2 = true;

                    }
                }

            }
            else
            {
                MessageBox.Show("wrong input!!!!", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                MyTextBox2.Clear();
            }
        }


        private void Location_Click(object sender, RoutedEventArgs e)
        {
            var ab = new map4(ref check);
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();
            
           
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }





        string BingMapsKey = "Jb9C8vgYnBRCqVeUq5be~8bRjVc66rCX4vuQTZkFFkw~An7hiz1GJMcbO7tJM7zejKU_slrteIlKbjgDQskBXFVjchjEQ3x7brCnLqEPw6Pi";
        BO.Stop stop = new BO.Stop();






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



        private void Search_KeyDown(object sender, KeyEventArgs e)
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
            MyTextBox1.Text = pinLocation.Longitude.ToString();
            try
            {
                Longitude_Click(sender, e);
            }
            catch
            {
                MessageBox.Show("something wrong happened please try again", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            MyTextBox2.Text = pinLocation.Latitude.ToString();
            try
            {
                Latitude_Click(sender, e);
            }
            catch
            {
                MessageBox.Show("something wrong happened please try again", "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            AddPushpinToMap(pinLocation.Latitude, pinLocation.Longitude, "Loc");

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
