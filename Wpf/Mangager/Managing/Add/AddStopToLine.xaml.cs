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
//aaa

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
        public AddStopToLine(BO.Stop stop)
        {
            InitializeComponent();
            managingStop = stop;

            bl = BLApi.Factory.GetBL("1");
            lines.DataContext = bl.GetAllLines();
        }

        private void Line_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            managingLine = (BO.Line)lines.SelectedItem;
            for(int i  = 1; i<= managingLine.Stops.Count();i++)
            {
                number_in_lines.Items.Add(i);
            }
        }
        private void NumberInLine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            numberInLine = (int)number_in_lines.SelectedItem;

            submit.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bl.AddStopInLine(managingLine.Id, managingStop.StopCode, numberInLine);
            MessageBox.Show("stop to line added successfully");
            this.Close();
        }
    }
}
