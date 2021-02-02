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
using Wpf.Mangager.Information;
using Wpf.Mangager.Managing;
using System.Windows.Threading;
using Wpf.Mangager.Managing.Add;
using Wpf.Mangager.threading;
using Wpf.Passenger;
using Wpf.CEO;



namespace Wpf.Mangager.Presentation
{
    /// <summary>
    /// Interaction logic for PresentationLines.xaml
    /// </summary>
    public partial class PresentationLines : Window
    {
        BLApi.IBL bl;
        public BO.Line tempLine;
        public IEnumerable<BO.Line> a;
        string au;



        /// <summary>
        /// Initializes the current window in all existing objects 
        /// </summary>
        public PresentationLines(string auInput)
        {
            InitializeComponent();
            bl = BLApi.Factory.GetBL("1");
            a = bl.GetAllLines().ToList();

            au = auInput;


            if (au == "PASSENGER")
            {
                AddButton.Visibility = Visibility.Collapsed;
                foreach (BO.Line line in a)
                {
                    line.Show = BO.status.REFULING;
                }
            }
            else
            {
                foreach (BO.Line line in a)
                {
                    line.Show = BO.status.READY_FOR_DRIVE;
                }
            }




            lineList.ItemsSource = a;




            lineOptions.Items.Add("TRAVELING");
            lineOptions.Items.Add("NOT_TRAVELING");

        }

        /// <summary>
        ///Initializes the moving bus at the bottom of the screen
        /// </summary>


        /// <summary>
        /// Defines actions to be performed when the user select box frome the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void information_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempLine = (BO.Line)a.DataContext;
            var ab = new LineInfo(tempLine);
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_Click(object sender, RoutedEventArgs e)
        {

            Button a = (Button)sender;
            tempLine = (BO.Line)a.DataContext;
            var ab = new LineManager(tempLine);
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();

        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void home_Click(object sender, RoutedEventArgs e)
        {
            new FirstPage().Show();
            this.Close();
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (au == "DRIVER")
                new OptionsForDriver().Show();
            else if (au == "PASSENGER")
                new OptionsForPassenger().Show();
            else
                new OptionsForCEO().Show();
            this.Close();
        }

        /// <summary>
        /// Defines actions to be performed when the user select box frome the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lineList_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var ab = new LineManagerAdd();
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartTravel_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempLine = (BO.Line)a.DataContext;
            var ab = new StartTravelLine(tempLine);
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();
        }


        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempLine = (BO.Line)a.DataContext;
            try
            {
                bl.DeleteLine(tempLine.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Information);
            }



            var aa = bl.GetAllLines().ToList();


            if (au == "PASSENGER")
            {
                foreach (BO.Line line in aa)
                {
                    line.Show = BO.status.REFULING;
                }
            }
            else
            {
                foreach (BO.Line line in aa)
                {
                    line.Show = BO.status.READY_FOR_DRIVE;
                }
            }




            lineList.ItemsSource = aa;
            lineList.Items.Refresh();

        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lineLocation_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempLine = (BO.Line)a.DataContext;
            var ab = new map2(tempLine.Number);
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();
        }

        /// <summary>
        /// This function is responsible for the series of actions that will be performed when this button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeqStopInfo_Click(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            tempLine = (BO.Line)a.DataContext;
            var ab = new SequentialStopPresention(tempLine);
            ab.Height = 300;
            ab.Width = 600;
            ab.Show();
        }

        private void busList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (lineOptions.SelectedItem as string)
            {
                case "TRAVELING":
                    a = bl.GetAllLinesDriving().ToList();
                    break;
                case "NOT_TRAVELING":
                    a = bl.GetAllLinesNotDriving().ToList();
                    break;
            }





            if (au == "PASSENGER")
            {
                foreach (BO.Line line in a)
                {
                    line.Show = BO.status.REFULING;
                }
            }
            else
            {
                foreach (BO.Line line in a)
                {
                    line.Show = BO.status.READY_FOR_DRIVE;
                }
            }




            lineList.ItemsSource = a;
            lineList.Items.Refresh();
        }
    }
}
