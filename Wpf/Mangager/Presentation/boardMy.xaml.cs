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

namespace Wpf.Mangager.Presentation
{
    /// <summary>
    /// Interaction logic for boardMy.xaml
    /// </summary>
    public partial class boardMy : Window
    {
        BO.Stop stop = new BO.Stop();
        public boardMy(BO.Stop myStop)
        {
            stop = myStop;
            InitializeComponent();
            List<BO.Board> toPrintL = new List<BO.Board>();
            foreach (var num in myStop.Lines)
            {
                toPrintL.Add(new BO.Board(num.Number, 555));

            }

            LineListS.DataContext = toPrintL;
        }
    }
}
