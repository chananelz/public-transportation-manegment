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
using BLApi;
//

namespace Wpf.Mangager.threading
{
    /// <summary>
    /// Interaction logic for StartTravel.xaml
    /// </summary>
    public partial class StartTravel : Window
    {
        public BO.Line tempLine;
        public StartTravel()
        {
            InitializeComponent();
            BLApi.IBL bl;
            bl = BLApi.Factory.GetBL("1");
            lineListBox.ItemsSource = bl.GetAllLines().ToList();
            DriverListBox.ItemsSource = bl.GetAllUsers(user => user.Permission == BO.authority.Driver).ToList();
        }
        private void information_Click(object sender, RoutedEventArgs e)
        {
            BLApi.IBL bl;
            bl = BLApi.Factory.GetBL("1");
            Button a = (Button)sender;
            tempLine = (BO.Line)a.DataContext;
            new LineInfo(tempLine).Show();
        }
    }
}