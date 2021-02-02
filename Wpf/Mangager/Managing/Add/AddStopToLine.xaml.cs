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
using BLApi;
//aa

namespace Wpf.Mangager.Managing.Add
{
    /// <summary>
    /// Interaction logic for AddStopToLine.xaml
    /// </summary>
    public partial class AddStopToLine : Window
    {
        BO.Line managingLine = new BO.Line();
        BO.Stop managingStop = new BO.Stop();
        int numberInLine = 0;
        BLApi.IBL bl;

        /// <summary>
        /// constractor of the window
        /// </summary>
        public AddStopToLine(BO.Stop stop)
        {
            InitializeComponent();
            managingStop = stop;

            bl = BLApi.Factory.GetBL("1");
            lines.DataContext = bl.GetAllLines();
        }

        /// <summary>
        /// Defines actions to be performed when the user enters input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Line_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            managingLine = (BO.Line)lines.SelectedItem;
            for(int i  = 1; i<= managingLine.Stops.Count();i++)
            {
                number_in_lines.Items.Add(i);
            }
        }

        /// <summary>
        /// Defines actions to be performed when the user enters input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberInLine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            numberInLine = (int)number_in_lines.SelectedItem;

            submit.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Defines actions to be performed when a  button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (managingLine.Id == 0)
            {
                this.Close();
                return;
            }
            bl.AddStopInLine(managingLine.Id, managingStop.StopCode, numberInLine);
            MessageBox.Show("stop to line added successfully");
            this.Close();
        }
    }
}
