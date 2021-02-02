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
using System.Windows.Threading;




namespace Wpf.CEO.Drivers
{
    /// <summary>
    /// Interaction logic for PresentationDriver.xaml
    /// </summary>
    public partial class PresentationDriver : Window
    {


        BLApi.IBL bl;
        public BO.User tempUser;

        /// <summary>
        /// Initializes the current window in all existing objects 
        /// </summary>
        public PresentationDriver()
        {
            InitializeComponent();
            bl = BLApi.Factory.GetBL("1");
            driverList.ItemsSource = bl.GetAllDrivers().ToList();

        }



        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void information_Click(object sender, RoutedEventArgs e)
        {
            //Button a = (Button)sender;
            //tempUser = (BO.User)a.DataContext;
            //new LineInfo(tempUser).Show();
            //this.Close();
        }
        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            //Button a = (Button)sender;
            //tempLine = (BO.Line)a.DataContext;
            //new LineManager(tempLine).Show();
            //this.Close();
        }
        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void home_Click(object sender, RoutedEventArgs e)
        {
            new FirstPage().Show();
            this.Close();
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void back_Click(object sender, RoutedEventArgs e)
        {
            new OptionsForCEO().Show();
            this.Close();
        }
        private void lineList_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //new LineManagerAdd().Show();
            //this.Close();
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
        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempUser = (BO.User)a.DataContext;
            try
            {
                bl.DeleteUser(tempUser.UserName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            new PresentationDriver().Show();
            this.Close();
        }
    }
}
